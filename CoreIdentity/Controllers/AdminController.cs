using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 

namespace CoreIdentity.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }


        public IActionResult Index()
        {
            return View(userManager.Users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = await userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }


            return View(model);
        }


    }
}