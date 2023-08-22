using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public IActionResult GetCompanies()
        {
            //throw new Exception("Exception");
            var companies = _service.CompanyService.GetAllCompanies(trackChages: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}")]

        public IActionResult GetCopmpany(Guid id)
        {
            var company = _service.CompanyService.GetCompany(id, trackChages: false);
            return Ok(company);
        }

    }
}