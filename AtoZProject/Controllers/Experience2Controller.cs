using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AtoZProject.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = _experienceManager.TGetList();
            return Json(JsonConvert.SerializeObject(values));
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            _experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var result = _experienceManager.TGetByID(ExperienceID);
            return Json(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceManager.TGetByID(id);
            _experienceManager.TDelete(values);
            return NoContent();
        }

    }
}
