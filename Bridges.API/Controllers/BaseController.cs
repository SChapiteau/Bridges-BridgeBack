using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BridgeFront;
using Bridges.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bridges.API.Controllers
{
    public class BaseController : Controller
    {
        internal UserRole GetUserRole()
        {            
            var accessToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); ;
            var tokenManager = new TokenManager();
            var userRole = tokenManager.GetClaim<UserRole>(accessToken, ClaimNames.ROLE);
            return userRole;
        }
    }
}