﻿using Contracts;
using Entities.Models;
using Services.Contracts;
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

        public CompanyService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
                throw;
            }
        }
    }
}
