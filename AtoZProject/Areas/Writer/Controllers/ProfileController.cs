using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
