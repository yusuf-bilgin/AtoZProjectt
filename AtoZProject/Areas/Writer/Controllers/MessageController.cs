using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    public class MessageController : Controller
    {
        [Area("Writer")]
        public IActionResult Index()
        { 
            return View();
        }
    }
}
