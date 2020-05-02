using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BairesDevContext : DbContext
    {
        public BairesDevContext (DbContextOptions<BairesDevContext> options)
            : base(options)
        {
        }

        public DbSet<BairesDev> BairesDev { get; set; }
    }
}
