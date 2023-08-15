using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class CompanyService : ICompanyServices
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
           
                var companies = _repository.Company.GetAllCompanies(trackChanges);

                //var companiesDto = companies.Select(c=> new CompanyDto(c.Id, c.Name?? " ", string.Join(' ',c.Address, c.Country))).ToList();

                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                return companiesDto;
            
        }

        public CompanyDto GetCompany(Guid companyId, bool trackChages)
        {
            var company = _repository.Company.GetCompany(companyId, trackChages);

            if (company == null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;

        }
    }
}
