using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";

            var values = skillManager.TGetList();
            return View(values);
        }

        // Yeni yetenek ekleme
        [HttpGet] // formu gostermek icin
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenekler Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Ekleme";

            return View();
        }
        [HttpPost] // formu isleyip veritabanina kaydetmek icin kullanilir.
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index"); //Guncellemeyi yap sonra index'e git
        }

        // Yetenek Silme
        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }

        // Yetenek Guncelleme
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Güncelleme";
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
