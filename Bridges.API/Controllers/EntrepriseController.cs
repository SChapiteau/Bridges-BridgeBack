using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeCore.Entreprise;
using Bridges.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BridgeFront.Controllers
{   
    [Route("api/[controller]")]
    public class EntrepriseController : Controller
    {
        readonly IAnnuaire annuaire;
        private ILogger logger;

        public EntrepriseController(IAnnuaire annuaire, ILoggerFactory loggerFactory)
        {
            this.annuaire = annuaire;
            this.logger = loggerFactory.CreateLogger<EntrepriseController>();
        }

        public string Index()
        {
            System.Diagnostics.Trace.TraceError("Trace Générer avec Diagnostics Trace");

            logger.LogInformation("log information from logger");

            return "Annuaire";
        }

        [HttpGet]
        [Route("GetEntreprise")]
        public IEnumerable<Entreprise> GetEntreprise()
        {
            //Faire appel a une API
            //Annuaire annuaire = new Annuaire(new EntrepriseSQLRepository()); // faire l'injection de depéndance
            return this.annuaire.GetAll();
        }
    }
}