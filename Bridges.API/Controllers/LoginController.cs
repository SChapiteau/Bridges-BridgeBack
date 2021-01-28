using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bridges.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam) //Changer le parametre user
        {
            var user = loginService.Authenticate(userParam.Pseudo, userParam.Password);

            if (user == null)
            {                
                return Unauthorized();             
            }

            return Ok(user);
        }

        //a bouger dans un user controlleur
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            //var users = _userService.GetAll();
            var user = new User { Id = 0, Prenom = "get", Pseudo = "getall" };
            return Ok(user);
        }
    }
}