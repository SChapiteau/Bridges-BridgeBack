using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bridges.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger _logger;
        private readonly ILoginService loginService;

        public LoginController(ILoggerFactory loggerFactory, ILoginService loginService)
        {            
            _logger = loggerFactory.CreateLogger<LoginController>();
            this.loginService = loginService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UtilisateurLoginDTO userParam) //Changer le parametre user
        {
            try
            {
                var token = loginService.Authenticate(userParam.Login, userParam.Password);

                if (token == null)return Unauthorized();
                
                return Ok(token);

            }
            catch(Exception ex)
            {
                _logger.LogError("LoginController.Authenticate", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        //A bouger

        //a bouger dans un user controlleur
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {            
            var user = new User { Id = Guid.NewGuid(), Firstname = "get", Login = "getall" };
            return Ok(user);
        }
    }

    public class UtilisateurLoginDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}