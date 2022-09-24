using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private ITable1Repository _table1Repository;
        private ITable2Repository _table2Repository;

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
        public ITable1Repository Table1
        {
            get
            {
                if (_table1Repository == null)
                    _table1Repository = new Table1Repository(_repositoryContext);
                return _table1Repository;
            }
        }
        public ITable2Repository Table2
        {
            get
            {
                if (_table2Repository == null)
                    _table2Repository = new Table2Repository(_repositoryContext);
                return _table2Repository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
