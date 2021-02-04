using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
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
        public void AddUser(User utilisateur)
        {
            _userService.AddUser(utilisateur);
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }
    }
}