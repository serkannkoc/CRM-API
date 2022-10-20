
using Company2.Services;
using Company2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class auth : ControllerBase
    {
        private IConfiguration _config;
        public PreRegistrationService _preRegistrationService { get; set; }
        public AuthorizationService _authorizationService { get; set; }
        public auth(PreRegistrationService preRegistrationService, AuthorizationService authorizationService, IConfiguration config)
        {
            _preRegistrationService = preRegistrationService;
            _authorizationService = authorizationService;
            _config = config;

        }

        [HttpPost("preregistration")]
        public IActionResult PreRegistration([FromBody] PreRegistrationVM preRegistration)
        {
            _preRegistrationService.AddPreRegistration(preRegistration);
            return Ok();
        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody] RegisterVM registration)
        {
            _authorizationService.Register(registration);
            return Ok();
        }
        [Authorize]
        [HttpGet("get-pre-registrations")]
        public IActionResult GetPreRegistrations()
        {
            var data = _preRegistrationService.getPreRegistrations();
            return Ok(data);
        }

        
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginVM userLogin)
        {
            var user =_authorizationService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _authorizationService.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

    }
}
