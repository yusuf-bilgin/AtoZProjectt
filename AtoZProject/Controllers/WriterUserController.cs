using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class WriterUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
