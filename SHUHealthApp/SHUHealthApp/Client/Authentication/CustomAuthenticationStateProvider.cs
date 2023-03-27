using Blazored.SessionStorage;
using SHUHealthApp.Client.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using SHUHealthApp.Shared;

namespace SHUHealthApp.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService sessionStorageVar;
        private ClaimsPrincipal anonymousVar = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            sessionStorageVar = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await sessionStorageVar.ReadItemEncrypted<UserSession>("UserSession");

                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(anonymousVar));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "JwtAuthentication"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            }
            catch 
            {
                return await Task.FromResult(new AuthenticationState(anonymousVar));
            }
        }

        //updating current authentication state
        public async Task UpdateAuthenticationState(UserSession? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            //checking is user session is active. If user session is active, execute code inside of statement
            if (userSession != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));

                userSession.SessionEndStamp = DateTime.Now.AddSeconds(userSession.ExpireTime);
                await sessionStorageVar.SaveitemEncrypted("UserSession", userSession);
            }
            else
            {
                claimsPrincipal = anonymousVar;
                await sessionStorageVar.RemoveItemAsync("UserSession");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var res = string.Empty;

            try
            {
                var userSession = await sessionStorageVar.ReadItemEncrypted<UserSession>("UserSession");

                if (userSession != null && DateTime.Now < userSession.SessionEndStamp)
                    res = userSession.Token;
            }
            catch { }

            return res;
        }
    }
}
