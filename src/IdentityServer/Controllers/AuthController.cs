using System;
using System.Threading.Tasks;
using IdentityServer.Data.Entities;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToArrayAsync();
            return View(users);
        }
        
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (res.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }

                if (res.IsLockedOut)
                {
                    //send reset email
                }

                ModelState.AddModelError("AuthFailed", "Authentication failed");
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("500", "Something went wrong");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var user = new ApplicationUser
                {
                    FullName = model.Fullname,
                    Email = model.Email,
                    UserName = model.Email,
                };

                var res = await _userManager.CreateAsync(user, model.Password);

                if (res.Succeeded)
                {
                    var res2 = await _userManager.AddToRoleAsync(user, "BasicUser");
                    if (res2.Succeeded) return RedirectToAction("Login", new { returnUrl = returnUrl });
                    
                    await _userManager.DeleteAsync(user);
                    ModelState.AddModelError("500", "Failed to add user roles");
                    return View(model);
                }

                ModelState.AddModelError("500", "Failed to register");
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("500", "Something went wrong");
                return View();
            }
        }
    }
}