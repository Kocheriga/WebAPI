using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Table1Repository : RepositoryBase<Table1>, ITable1Repository
    {
        public Table1Repository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
