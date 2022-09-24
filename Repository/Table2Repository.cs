using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
     public class Table2Repository : RepositoryBase<Table2>, ITable2Repository 
    {
        public Table2Repository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { 
        }
    }
}
