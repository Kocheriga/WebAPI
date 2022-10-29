using Contracts;
using Entities;
using Entities.Models;
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
        public IEnumerable<Prodaja> GetProdajas(int KlientsId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(KlientsId), trackChanges)
            .OrderBy(e => e.Tovar);
        public Prodaja GetProdaja(int KlientsId, int Id, bool trackChanges) =>
FindByCondition(e => e.KlientsId.Equals(KlientsId) && e.Id.Equals(Id),
trackChanges).SingleOrDefault();
    }
}
