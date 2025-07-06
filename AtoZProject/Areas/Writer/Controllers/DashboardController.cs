using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)  
                return RedirectToAction("Login", "Account");

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = $"{user.Name ?? "İsim Yok"} {user.Surname ?? "Soyisim Yok"}";

            // Istatistik verilerini çekip ViewBag'e atama
            Context c = new Context();
            ViewBag.v1 = 0;
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = 0;
            ViewBag.v4 = c.Skills.Count();

            return View();
        }
    }
}
