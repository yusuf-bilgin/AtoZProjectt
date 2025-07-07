using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;
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

            // Weather API'den veri çekme
            string apiKey = "e8e061a1db8e5021855a2678529d4cae";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=antalya&appid=" + apiKey + "&units=metric&mode=xml"; // Celsius için units=metric, XML formatı için mode=xml 
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").FirstOrDefault()?.Attribute("value")?.Value ?? "Veri Bulunamadı";

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

// https://api.openweathermap.org/data/2.5/weather?q=antalya&appid=e8e061a1db8e5021855a2678529d4cae&units=metric&mode=xml
