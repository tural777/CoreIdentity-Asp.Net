using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CoreIdentity.Controllers
{
    public class AdminRoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public AdminRoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }



        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(name));
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
            return View(name);
        }




        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    TempData["message"] = $"{role.Name} has been deleted.";
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
            return RedirectToAction("Index");
        }

    }
}