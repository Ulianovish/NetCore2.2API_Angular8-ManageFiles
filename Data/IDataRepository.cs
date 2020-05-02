using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public interface IDataRepository<BairesDev> where BairesDev : class
    {
        void Add(BairesDev entity);
        void Update(BairesDev entity);
        void Delete(List<BairesDev> entity);
        Task<BairesDev> SaveAsync(BairesDev entity);
        Task<List<BairesDev>> SaveAsync(List<BairesDev> entity);
    }
}
