using Microsoft.AspNetCore.Identity;

namespace SHUHealthMonitor.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CustomClaim { get; set; }
		public string Notes { get; set; }
	}
}
