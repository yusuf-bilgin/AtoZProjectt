using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.ViewComponents.Dashboard
{
    public class LastProjects : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
