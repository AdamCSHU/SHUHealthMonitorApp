using Microsoft.AspNetCore.Mvc;

namespace SHUHealthMonitor.Server.Controllers
{
    public class DummyDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
