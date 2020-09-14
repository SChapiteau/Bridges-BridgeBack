using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeCore.Entreprise;
using Bridges.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BridgeFront.Controllers
{
    [Route("api/[controller]")]
    public class EntrepriseController : Controller
    {
        readonly IAnnuaire annuaire;

        public EntrepriseController(IAnnuaire annuaire)
        {
            this.annuaire = annuaire;
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