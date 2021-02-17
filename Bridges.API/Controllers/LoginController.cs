using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeFront;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bridges.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ILoginService loginService;

        public LoginController(ILoggerFactory loggerFactory, IConfiguration configuration, ILoginService loginService)
        {            
            _logger = loggerFactory.CreateLogger<LoginController>();
            _configuration = configuration;
            this.loginService = loginService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UtilisateurLoginDTO userParam) //Changer le parametre user
        {
            try
            {
                var user = loginService.Authenticate(userParam.Login, userParam.Password);
                if (user == null)return Unauthorized();

                // modifier l'appel
                var tokenManager = new TokenManager();
                var key = Encoding.ASCII.GetBytes(_configuration["secret"]);
                var token = tokenManager.CreateToken(user, key);

                return Ok(token);

            }
            catch(Exception ex)
            {
                _logger.LogError("LoginController.Authenticate", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }        
    }

    public class UtilisateurLoginDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}