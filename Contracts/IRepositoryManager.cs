using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IKlientRepository Klient { get; }
        IProdajaRepository Prodaja { get; }
        void Save();
    }
}
