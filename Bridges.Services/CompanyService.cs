using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using System.Collections.Generic;

namespace Bridges.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository enterpriseRepository;

        public CompanyService(ICompanyRepository enterpriseRepository)
        {
            this.enterpriseRepository = enterpriseRepository;
        }
        public IEnumerable<Company> GetAll()
        {
            return enterpriseRepository.GetAll();

        }
    }
}
