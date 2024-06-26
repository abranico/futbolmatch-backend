using Application.Interfaces;
using Application.Models.Requests;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar([FromBody] AuthenticationRequest request)
        {
            try
            {
                string token = _authenticationService.Autenticar(request);
                return Ok(token);
            }
            catch
            {
                return Unauthorized();
            }
            
        }
    }
}
