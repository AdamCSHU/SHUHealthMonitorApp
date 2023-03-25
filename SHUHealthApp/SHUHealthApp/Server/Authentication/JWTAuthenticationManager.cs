using Microsoft.IdentityModel.Tokens;
using SHUHealthApp.Shared;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SHUHealthApp.Server.Authentication
{
    public class JWTAuthenticationManager
    {
        public const string JWT_KEY = "JQAaQWkFOng5x4NvmP0G0mBQSc3F4Zux";
        private const int JWT_TOKEN_TIME_MINS = 25;

        private AccountService UserAccountService;

        public JWTAuthenticationManager (AccountService userAccountService)
        {
            UserAccountService = userAccountService;
        }

        public UserSession? GenerateJWTToken(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            //validates user credentials against the database. 
            var UserAccount = UserAccountService.GetUserModelByUserName(userName);
            if (UserAccount == null || UserAccount.Password != password)
                return null;

            //genrate jwt token for session
            var TokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_TIME_MINS);
            var TokenKey = Encoding.ASCII.GetBytes(JWT_KEY);
            var ClaimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, UserAccount.UserName),
                new Claim(ClaimTypes.Role, UserAccount.Role)
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ClaimsIdentity,
                Expires = TokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var JWTSecurityTokenhandler = new JwtSecurityTokenHandler();
            var SecurityToken = JWTSecurityTokenhandler.CreateToken(securityTokenDescriptor);
            var token = JWTSecurityTokenhandler.WriteToken(SecurityToken);

            //return user session object
            var userSession = new UserSession
            {
                UserName = UserAccount.UserName,
                Role = UserAccount.Role,
                Token = token,
                ExpireTime = (int)TokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };

            return userSession;
        }
    }
}
