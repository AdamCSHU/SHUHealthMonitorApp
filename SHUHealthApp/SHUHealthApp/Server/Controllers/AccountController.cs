using SHUHealthApp.Server.Authentication;
using SHUHealthApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountService _userAccountService;

        public AccountController(AccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public ActionResult<UserSession> Signin([FromBody] SigninRequest loginRequest)
        {
            var jwtAuthenticationManager = new JWTAuthenticationManager(_userAccountService);
            var userSession = jwtAuthenticationManager.GenerateJWTToken(loginRequest.UserName, loginRequest.Password);
            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }
    }
}
