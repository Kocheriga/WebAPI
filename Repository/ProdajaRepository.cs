using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ProdajaRepository : RepositoryBase<Prodaja>, IProdajaRepository
    {
        public ProdajaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { 
        }
        public IEnumerable<Prodaja> GetProdajas(Guid klientsId, bool trackChanges) =>
            FindByCondition(e => e.KlientsId.Equals(klientsId), trackChanges)
            .OrderBy(e => e.Tovar);

        public Prodaja GetProdaja(Guid klientsId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.KlientsId.Equals(klientsId) && e.Id.Equals(Id),
            trackChanges).SingleOrDefault();

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
