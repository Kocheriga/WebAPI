using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdajaRepository : RepositoryBase<Prodaja>, IProdajaRepository
    {
        public ProdajaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<PagedList<Prodaja>> GetProdajasAsync(Guid klientsId,
 ProdajaParameters prodajaParameters, bool trackChanges)
        {
            var prodajas = await FindByCondition(e => e.KlientsId.Equals(klientsId), 
           trackChanges).FilterProdajas()
            .OrderBy(e => e.Tovar)
            .ToListAsync();
            return PagedList<Prodaja>
            .ToPagedList(prodajas, prodajaParameters.PageNumber,
            prodajaParameters.PageSize);
        }


        public async Task<Prodaja> GetProdajaAsync(Guid klientsId, Guid Id, bool trackChanges) =>
            await FindByCondition(e => e.KlientsId.Equals(klientsId) && e.Id.Equals(Id),
            trackChanges).SingleOrDefaultAsync();

        public void CreateProdajaForKlient(Guid klientsId, Prodaja prodaja) 
        {
            prodaja.KlientsId = klientsId;
            Create(prodaja);
        }
        public void DeleteProdaja(Prodaja prodaja)
        {
            Delete(prodaja);
        }
    }
}
