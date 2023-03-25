using Microsoft.AspNetCore.Http;
using SHUHealthApp.Shared;
using SHUHealthApp.Server.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SHUHealthApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private AccountService UserAccountService;

        public AccountController (AccountService userAccountService)
        {
            userAccountService = UserAccountService;
        }
        
        [HttpPost]
        [Route("/Signin")]
        [AllowAnonymous]

        public ActionResult<UserSession> Signin([FromBody] SigninRequest signinRequest)
        {
            var JwtAuthenticationManager = new JWTAuthenticationManager(UserAccountService);
            var UserSession = JwtAuthenticationManager.GenerateJWTToken(signinRequest.UserName, signinRequest.Password);

            if (UserSession is null)
                return Unauthorized();
            else
                return UserSession;
        }
    }
}
