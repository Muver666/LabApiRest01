using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositorycontext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public RepositoryManager(RepositoryContext repositorycontext)
        {
            _repositorycontext = repositorycontext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositorycontext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositorycontext));
        }
        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        public void Save() => _repositorycontext.SaveChanges();
    }
}
