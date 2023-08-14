using AutoMapper;
using Contracts;
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
            try
            {
                var employees = _repository.Employee.GetAllEmployees(trackChanges);

                //var employeesDto = employees.Select(c=> new EmployeeDto(c.Id, c.Name?? " ", string.Join(' ',c.Address, c.Country))).ToList();

                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

                return employeesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEmployees)} service method {ex}");
                throw;
            }
        }
    }
}
