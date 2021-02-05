using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Bridges.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bridges.API.Controllers
{
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
            try
            {
                _userService.AddUser(utilisateur);
                return Ok();
            }
            catch(UserServiceException ex)
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
    }
}