using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AtoZProject.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    [Route("Writer/[controller]")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            Debug.WriteLine("Post tetiklendi");
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userImage/" + imageName;
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await p.Picture.CopyToAsync(stream);
                }
                user.ImageUrl = imageName;
            }

            user.Name = p.Name;
            user.Surname = p.Surname;

            if (!string.IsNullOrEmpty(p.Password) && p.Password == p.PasswordConfirm)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }
            else if (!string.IsNullOrEmpty(p.Password) || !string.IsNullOrEmpty(p.PasswordConfirm))
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(p);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default", new { area = "Writer" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(p);
        }
    }
}
