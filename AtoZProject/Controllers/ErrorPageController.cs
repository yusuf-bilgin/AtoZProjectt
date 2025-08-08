using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
