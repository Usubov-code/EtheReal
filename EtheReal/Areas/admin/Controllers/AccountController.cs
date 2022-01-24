using EtheReal.Data;
using EtheReal.Models;
using EtheReal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.Controllers
{

    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signIngManager;
        public AccountController(AppDbContext context,UserManager<CustomUser> userManager ,SignInManager<CustomUser> signIngManager)
        {
            _context = context;
            _userManager = userManager;
            _signIngManager = signIngManager;
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (_userManager.Users.Any(e=>e.UserName==model.UserName))
                {

                    ModelState.AddModelError("", "Username Movcuddur!");
                    return View(model);

                }
                else
                {
                    if (_userManager.Users.Any(c=>c.Email==model.Email))
                    {
                        ModelState.AddModelError("", "Email ile Qeydiyyat olunub!");

                        return View(model);

                    }

                    CustomUser member = new CustomUser()
                    {
                        Email = model.Email,
                        UserName=model.UserName,
                        FullName=model.FullName,
                        

                    };

                    var result = await _userManager.CreateAsync(member , model.Password);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", "Email ve ya passwordu duzgun secin!");
                            return View(model);
                        }
                    }
                    else
                    {


                        await _signIngManager.SignInAsync(member, false);
                        return RedirectToAction("login", "account");
                    }
                }
            }
            return View ();
        }

        public IActionResult Login()
        {



            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(VmLogin model)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            CustomUser user = _userManager.Users.FirstOrDefault(x => x.NormalizedUserName == model.UserName.ToUpper());
            if (user == null)
            {
                ModelState.AddModelError("", "User Tapilmadi ");
                return View();
            }

            var result = await _signIngManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName ve ya parol sehvdir!");
                return View();

            }

            return RedirectToAction("index", "home");

        }

        public async Task<IActionResult> Logout()
        {

            await _signIngManager.SignOutAsync();
            return RedirectToAction("login","account");
        }




    }
}
