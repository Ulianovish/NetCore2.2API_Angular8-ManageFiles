using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Blog.Models;
using Blog.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.StaticFiles;

namespace Blog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BairesDevController : ControllerBase
    {
        private readonly BairesDevContext _context;
        private readonly IDataRepository<BairesDev> _repo;
        private IHostingEnvironment _hostingEnvironment;

        public BairesDevController(BairesDevContext context, IDataRepository<BairesDev> repo, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _repo = repo;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                await DeleteAllDataAsync();

                var file = Request.Form.Files[0];

                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                string fullPath = FilePath(fileName);

                if (file.Length > 0)
                {

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    await AddBairesDevServiceAsync(fullPath);

                }
                return Ok("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Upload Failed: " + ex.Message);
            }
        }


        [HttpGet]
        public IEnumerable<BairesDev> GetBairesDev()
        {
            return _context.BairesDev.OrderByDescending(p => p.Id);
        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var AllRegisters = await _context.BairesDev.ToListAsync();

            string[] newFile = new string[100];
            AllRegisters.ForEach(x => newFile[AllRegisters.IndexOf(x)] = x.PersonId);

            string FullPath = FilePath(file);
            System.IO.File.WriteAllText(FullPath, String.Join("\n", newFile));
            if (!System.IO.File.Exists(FullPath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(FullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(FullPath), file);
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Hello");
        }
        private bool BairesDevExists(int id)
        {
            return _context.BairesDev.Any(e => e.Id == id);
        }

        public string FilePath(string FileName)
        {
            string FolderName = "Upload";
            string WebRootPath = _hostingEnvironment.WebRootPath;
            string NewPath = Path.Combine(WebRootPath, FolderName);
            string FullPath = Path.Combine(NewPath, FileName);
            return FullPath;
        }

        public async Task DeleteAllDataAsync()
        {
            var AllRegisters = await _context.BairesDev.ToListAsync();

            _repo.Delete(AllRegisters);
            var save = _repo.SaveAsync(AllRegisters);
        }

        public async Task AddBairesDevServiceAsync(string FullPath)
        {
            string[] lines = System.IO.File.ReadAllLines(FullPath);
            int registros = 0;
            int loop = 0;
            while (registros < 100)
            {
                foreach (string laline in lines)
                {
                    var linesas = laline;
                    string[] items = linesas.Split('|');
                    BairesDev blogPost = new BairesDev
                    {
                        PersonId = items[0],
                        Name = items[1].ToString(),
                        LastName = items[2].ToString(),
                        CurrentRole = items[3].ToString(),
                        Country = items[4].ToString(),
                        Industry = items[5].ToString(),
                        NumberOfRecommendations = Int32.Parse(items[6]),
                        NumberOfConnections = Int32.Parse(items[7])
                    };

                    if (blogPost.NumberOfRecommendations > 0 || (loop > 0 && blogPost.NumberOfConnections > 0))
                    {
                        _repo.Add(blogPost);
                        var newRegs = await _repo.SaveAsync(blogPost);
                        CreatedAtAction("GetBairesDev", new { id = blogPost.Id }, blogPost);

                        List<string> newList = new List<string>(lines);
                        newList.Remove(laline);
                        lines = newList.ToArray();

                        registros++;
                        if (registros == 100) break;
                    }
                }
                loop++;
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

    }
}
