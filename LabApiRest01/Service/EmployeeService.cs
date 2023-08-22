using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Services.Contracts;
using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
          
                var employees = _repository.Employee.GetAllEmployees(trackChanges);

                //var employeesDto = employees.Select(c=> new EmployeeDto(c.Id, c.Name?? " ", string.Join(' ',c.Address, c.Country))).ToList();

                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

                return employeesDto;
            }

        //public EmployeeDto GetEmployee(Guid companyid, bool trackChanges)
        //{
        //    var company = _repository.Company.GetCompany(companyid, trackChanges);

        //    if (company is null)
        //    {
        //        throw new CompanyNotFoundException(companyid);
        //    }

        //    var employeesFromDb = _repository.Employee.GetEmployee(companyid, trackChanges);
        //    var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        //    return employeesDto;
        //}

        public EmployeeDto GetEmployee(Guid companyid, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyid, trackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyid);
            }
            var employeeDb = _repository.Employee.GetEmployee(companyid, id, trackChanges);
            if(employeeDb is null)
            {
                throw new EmployeeNotFoundException(id);
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employeeDb);

            return employeeDto;
        }
    }
}
