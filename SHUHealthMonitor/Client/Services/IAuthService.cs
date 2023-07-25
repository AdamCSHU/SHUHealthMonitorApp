using SHUHealthMonitor.Shared.Models;

namespace SHUHealthMonitor.Client.Services
{
	public interface IAuthService
	{
		Task<LoginResult> Login(LoginModel loginModel);
		Task<RegisterResult> Register(RegisterModel registerModel);
		Task Logout();
	}
}
