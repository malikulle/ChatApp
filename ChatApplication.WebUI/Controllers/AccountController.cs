using ChatApplication.Entities.Domain;
using ChatApplication.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email veya Parola yanlış. Tekrar deneyiniz.");
                        return View();

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email veya Parola yanlış. Tekrar deneyiniz.");
                    return View();

                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var exist = await _userManager.FindByEmailAsync(model.Email);

            if (exist != null)
            {
                ModelState.AddModelError("", "Email Kullanılmaktadır");
                return View(model);
            }

            var existUsername = await _userManager.FindByNameAsync(model.UserName);
            if (existUsername != null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı Kullanılmaktadır");
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName.ToString(),
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                PhoneNumber = "0",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Beklenmedik Bir Hata Oluştu. Tekrar Deneyiniz.");
            return View(model);

        }

        [Authorize]
        [HttpGet]
        public ViewResult AccessDenied() => View();

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
