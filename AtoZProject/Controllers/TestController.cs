using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
