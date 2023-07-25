using Microsoft.AspNetCore.Mvc;

//Implementation is incomplete
//controller for showing dummy data health statistics, using bogus and visualised via line graphs
namespace SHUHealthMonitor.Server.Controllers
{
    public class HealthStatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
