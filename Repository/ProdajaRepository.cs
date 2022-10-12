using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
     public class ProdajaRepository : RepositoryBase<Prodaja>, Contracts.IProdajaRepository 
    {
        public ProdajaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { 
        }
    }
}
