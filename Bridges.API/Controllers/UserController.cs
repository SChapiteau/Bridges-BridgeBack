using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BridgeFront;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Bridges.Services;
using Bridges.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bridges.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUSerService _userService;
        private readonly ILogger logger;

        public UserController(ILoggerFactory loggerFactory, IUSerService userService )
        {
            this.logger = loggerFactory.CreateLogger<UserController>();
            _userService = userService;
        }

        [HttpPost]        
        [Route("AddUser")]
        public IActionResult AddUser(User utilisateur)
        {
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); ;
            
            //Refecto la gestion du role
            var tokenManager = new TokenManager();            
            var userRole = tokenManager.GetClaim<UserRole>(accessToken, ClaimNames.ROLE);

            try
            {
                if (userRole == UserRole.ADMIN)
                {
                    _userService.AddUser(utilisateur);
                    return Ok();
                }
                else
                    return Unauthorized();
            }
            catch(UserServiceException)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }

        //A déplacer :
        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type ==  claimType).Value;
            return stringClaimValue;
        }
    }
}