using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bridges.API.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult AjoutUtilisateur(Utilisateur utilisateur)
        {
            return View();
        }
    }
}