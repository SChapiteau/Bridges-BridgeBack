using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BridgeFront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        readonly ICompanyService companyService;
        private ILogger logger;        

        public CompanyController(ICompanyService annuaire, ILoggerFactory loggerFactory)
        {
            this.companyService = annuaire;
            this.logger = loggerFactory.CreateLogger<CompanyController>();            
        }

        public string Index()
        {            
            logger.LogInformation("log information from logger");            

            return "Annuaire";
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Company> GetAllCompany()
        {            
            return this.companyService.GetAll();
        }
    }
}