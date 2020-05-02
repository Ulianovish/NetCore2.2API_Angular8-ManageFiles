using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class DataRepository<BairesDev> : IDataRepository<BairesDev> where BairesDev : class
    {
        private readonly BairesDevContext _context;

        public DataRepository(BairesDevContext context)
        {
            _context = context;
        }

        public void Add(BairesDev entity)
        {
            _context.Set<BairesDev>().Add(entity);
        }

        public void Update(BairesDev entity)
        {
            _context.Set<BairesDev>().Update(entity);
        }

        public void Delete(List<BairesDev> entity)
        {
            entity.ForEach(x => _context.Set<BairesDev>().Remove(x));
        }

        public async Task<BairesDev> SaveAsync(BairesDev entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<BairesDev>> SaveAsync(List<BairesDev> entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
