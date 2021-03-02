using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridges.Core.Models;
using Bridges.Core.Models.OfferModels;
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
    public class OfferController : BaseController
    {
        private readonly ILogger _logger;        
        private readonly IOfferService _offerService;
        private readonly IUSerService _userService;

        public OfferController(ILoggerFactory loggerFactory, IOfferService offerService, IUSerService userService)
        {
            _logger = loggerFactory.CreateLogger<LoginController>();
            _offerService = offerService;
            _userService = userService;
        }

        [HttpPost("CreateOffer")]
        public IActionResult CreateOffer(Offer offer)
        {
            try
            {
                var offerTest = new Offer()
                {
                    Title = "offreTest 1",
                    CreationDate = DateTime.Now,
                    Description = "Offre créer En Back pour test",                    
                };

                var userid = GetUserId();
                offerTest.Owner = _userService.GetUserById(userid);

                if (offerTest.IsValid())
                {
                    
                    _offerService.CreateOffer(offerTest);
                    return OK();
                }
                return BadRequest();

            }
            catch(Exception ex)
            {
                _logger.LogError("LoginController.Authenticate", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        private IActionResult OK()
        {
            throw new NotImplementedException();
        }
    }
}