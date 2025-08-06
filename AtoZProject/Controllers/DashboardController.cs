using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
