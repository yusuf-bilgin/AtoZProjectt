﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IViewComponentResult Invoke()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
    }
}
