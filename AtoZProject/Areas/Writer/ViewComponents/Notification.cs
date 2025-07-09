using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
