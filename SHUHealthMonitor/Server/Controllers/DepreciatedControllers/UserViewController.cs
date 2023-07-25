/*

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHUHealthMonitor.Server.Models;

//this feature was planned to be a basic user management system for editing and deleting users
//Instead, I scrapped the user management feature in favour of a user list which an admin can view, if an administrator user wants to delete a user, they can do so using sql commands. 
//may try to implement this at a later date. 
//Admin/Doctor can still view current users registered however.
namespace SHUHealthMonitor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserViewController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

    }
}
*/