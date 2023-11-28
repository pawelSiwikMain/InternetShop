using Application.Interfaces.AuthorizationService;
using Application.Models.AuthorizationService;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("signin")]
        public IActionResult GetSignIn(SignInRequest request) 
        {
            var response = _authorizationService.SingIn(request);
            return Ok(response);
        }
        [HttpPost("signup")]
        public IActionResult GetSignUp(SignUpRequst requst) 
        { 
            var response = _authorizationService.SignUp(requst);
            return Ok(response);
        }
    }
}
