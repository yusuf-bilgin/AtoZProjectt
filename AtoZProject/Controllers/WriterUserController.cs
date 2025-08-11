using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AtoZProject.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager _writerUserManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            var values = _writerUserManager.TGetList();
            return Json(JsonConvert.SerializeObject(values));
        }
    }
}
