using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //db.Dispose();
        }
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,RoleManager<IdentityRole>roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            ViewBag.title = "Login";
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password, string ReturnUrl)
        {
            ViewBag.title = "Login";
            var result = await signInManager.PasswordSignInAsync(email, password, false, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl) && ReturnUrl != "%2" && ReturnUrl != "/")
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Tutors");
                }
            }
            else
            {
                TempData["type"] = "error";
                TempData["msg"] = "Invalid credentials";
                TempData["email"] = email;
                return View();
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("LogOff")]
        public async Task<ActionResult> LogOff()
        {
            ViewBag.title = "Log Off";
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

    }
}
