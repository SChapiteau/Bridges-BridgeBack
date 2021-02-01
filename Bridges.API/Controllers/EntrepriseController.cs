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
    public class EntrepriseController : Controller
    {
        readonly IAnnuaire annuaire;
        private ILogger logger;
        private IConfiguration _configuration;

        public EntrepriseController(IAnnuaire annuaire, ILoggerFactory loggerFactory, IConfiguration iconfig)
        {
            this.annuaire = annuaire;
            this.logger = loggerFactory.CreateLogger<EntrepriseController>();
            _configuration = iconfig;
        }

        public string Index()
        {            
            logger.LogInformation("log information from logger");
            logger.LogWarning( _configuration["BridgesConfigAppTest"]);

            return "Annuaire";
        }

        [HttpGet]
        [Route("GetEntreprise")]
        public IEnumerable<Entreprise> GetEntreprise()
        {            
            return this.annuaire.GetAll();
        }
    }
}