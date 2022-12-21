using Microsoft.AspNetCore.Mvc;
using Template_Design_Patterm.DAL.Entities;
using Template_Design_Patterm.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_Design_Patterm.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Mail,
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.message = "Hatalı alan girişleri yaptınız tekrar deneyiniz";
            }
            return View();
        }

    }
}