using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class KlientRepository : RepositoryBase<Klient>, IKlientRepository
    {
        public KlientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Klient>> GetAllKlientsAsync(bool trackChanges)=>
            await FindAll(trackChanges)
            .OrderBy(k => k.KlientName)
            .ToListAsync();

        public async Task<Klient> GetKlientAsync(Guid KlientsId, bool trackChanges)
        => await FindByCondition(c => c.Id.Equals(KlientsId), trackChanges)
            .SingleOrDefaultAsync();


        public void CreateKlient(Klient klient) => Create(klient);
        public async Task<IEnumerable<Klient>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        public void DeleteKlient(Klient klient)
        {
            Delete(klient);
        }
    }
}
