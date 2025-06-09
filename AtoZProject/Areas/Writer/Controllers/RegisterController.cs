using AtoZProject.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
