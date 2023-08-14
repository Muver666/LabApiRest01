using Services.Contracts;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;
using AutoMapper;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyServices> _companyService;
        private readonly Lazy<IEmployeeServices> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyServices>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeServices>(() => new EmployeeService(repositoryManager, logger, mapper));
        }

        public ICompanyServices CompanyService => _companyService.Value;

        public IEmployeeServices EmployeeService => _employeeService.Value;
    }
}











//    public sealed class ServiceManager : IServiceManager
//    {
//        private readonly Lazy<ICompanyServices> _companyService;

//        private readonly Lazy<IEmployeeServices> _employeeService;

//        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
//        {
//            _companyService = new Lazy<ICompanyServices>(() => new CompanyService(repositoryManager, logger));
//            _employeeService = new Lazy<IEmployeeServices>(() => new EmployeeService(repositoryManager, logger));
//        }
//        public ICompanyServices CompanyService => _companyService.Value;
//        public IEmployeeServices EmployeeService => _employeeService.Value;
//    }
//}
