using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IKlientRepository _klientRepository;
        private IProdajaRepository _prodajaRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
            if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public Contracts.IKlientRepository Klient
        {
            get
            {
                if (_klientRepository == null)
                    _klientRepository = new KlientRepository(_repositoryContext);
                return _klientRepository;
            }
        }
        public Contracts.IProdajaRepository Prodaja
        {
            get
            {
                if (_prodajaRepository == null)
                    _prodajaRepository = new ProdajaRepository(_repositoryContext);
                return _prodajaRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
