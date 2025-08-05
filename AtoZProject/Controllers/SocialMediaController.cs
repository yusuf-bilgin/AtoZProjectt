using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true; // Default status set to true
            socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var value = socialMediaManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
