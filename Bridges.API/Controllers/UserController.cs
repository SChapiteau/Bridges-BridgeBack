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
    public class UserController : BaseController
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
            var userRole = GetUserRole();

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

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User utilisateur)
        {
            var userRole = GetUserRole();

            try
            {
                if (userRole == UserRole.ADMIN)
                {
                    _userService.UpdateUser(utilisateur);
                    return Ok();
                }
                else
                    return Unauthorized();
            }
            catch (UserServiceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User utilisateur)
        {
            var userRole = GetUserRole();

            try
            {
                if (userRole == UserRole.ADMIN)
                {
                    _userService.DeleteUser(utilisateur);
                    return Ok();
                }
                else
                    return Unauthorized();
            }
            catch (UserServiceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {            
            var userRole = GetUserRole();
            try
            {
                if (userRole == UserRole.ADMIN)
                {
                    return Ok(_userService.GetAllUser());                    
                }
                else
                    return Unauthorized();
            }
            catch (UserServiceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }        
    }
}