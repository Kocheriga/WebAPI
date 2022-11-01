using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class KlientRepository : RepositoryBase<Klient>, IKlientRepository
    {
        public KlientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Klient> GetAllKlients(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(k => k.KlientName)
            .ToList();

        public Klient GetKlient(Guid KlientsId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(KlientsId), trackChanges).SingleOrDefault();
        public void CreateKlient(Klient klient) => Create(klient);
        public IEnumerable<Klient> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();

    }
}
