using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        ITable1Repository Table1 { get; }
        ITable2Repository Table2 { get; }
        void Save();
    }
}
