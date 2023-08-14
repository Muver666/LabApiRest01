using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface ICompanyServices
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChages);
    }
}
