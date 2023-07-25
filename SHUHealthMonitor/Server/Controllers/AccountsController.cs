using SHUHealthMonitor.Server.Models;
using SHUHealthMonitor.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHUHealthMonitor.Server.Data;

//accounts controller, used to create new application users as well as logging in current ones. 

namespace SHUHealthMonitor.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private static readonly UserModel LoggedOutUser = new() { IsAuthenticated = false };

		private readonly UserManager<ApplicationUser> _userManager;

		public AccountsController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] RegisterModel model)
		{
			var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

			var result = await _userManager.CreateAsync(newUser, model.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(x => x.Description);

				return BadRequest(new RegisterResult { Successful = false, Errors = errors });
			}

			// Add all new users to the User role
			await _userManager.AddToRoleAsync(newUser, "User");

			// Add new users whose email starts with 'admin' to the Admin role
			if (newUser.Email.StartsWith("admin"))
			{
				await _userManager.AddToRoleAsync(newUser, "Admin");
			}

			var users = _userManager.Users.ToList();
            
			return Ok(new RegisterResult { Successful = true });
		}
	}
}
