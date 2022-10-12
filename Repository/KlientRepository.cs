using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class KlientRepository : RepositoryBase<Klient>, Contracts.IKlientRepository
    {
        public KlientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
