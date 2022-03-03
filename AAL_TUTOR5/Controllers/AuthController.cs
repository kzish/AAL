using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globals;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SharedModels;

namespace admin.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        MoodleRepository moodleRepository;
        //dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //db.Dispose();
        }
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MoodleRepository moodleRepository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.moodleRepository = moodleRepository;
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
                    return RedirectToAction("Profile", "Tutors");
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


        [HttpGet("Register")]
        public IActionResult Register()
        {
            ViewBag.title = "Register";
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Aspnetuser aspNetUser, MTutor tutor)
        {
            ViewBag.title = "Register Tutor";
            //
            try
            {
                //
                var id_user = new IdentityUser()
                {
                    Email = aspNetUser.Email,
                    UserName = aspNetUser.Email,
                    PasswordHash = aspNetUser.PasswordHash,
                };

                //create tutor/moodle user and link with identity user
                var new_tutor_moodle_user = new MMoodleUser();
                new_tutor_moodle_user.Firstname = tutor.Firstname;
                new_tutor_moodle_user.Surname = tutor.Surname;
                new_tutor_moodle_user.Password = aspNetUser.PasswordHash;
                new_tutor_moodle_user.AspnetUserId = id_user.Id;
                new_tutor_moodle_user.Email = aspNetUser.Email;
                dynamic res = moodleRepository.CreateMoodleUser(new_tutor_moodle_user);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = "Error occurred";
                    string err = res.msg.ToString();
                    Log.Error(err);
                    return RedirectToAction("Register");
                }
                else if (res.res == "ok")
                {
                    //create identity user
                    var created = await userManager.CreateAsync(id_user, aspNetUser.PasswordHash);
                    if (created.Succeeded)
                    {
                        //add moodle user to db
                        new_tutor_moodle_user.MoodleId = res.moodle_user_id;
                        AppSettings.db.MMoodleUsers.Add(new_tutor_moodle_user);
                        tutor.AspnetUserId = id_user.Id;
                        tutor.Email = aspNetUser.Email;
                        AppSettings.db.MTutors.Add(tutor);
                        AppSettings.db.SaveChanges();
                        //add identity user to tutor role
                        await userManager.AddToRoleAsync(id_user, "tutor");
                        //AppSettings.db.Database.CommitTransaction();
                        //
                        TempData["type"] = "success";
                        TempData["msg"] = "Account Created: You may now Login";
                    }
                    else
                    {
                        TempData["type"] = "error";
                        var errors = string.Empty;
                        foreach (var e in created.Errors.ToList())
                        {
                            errors += e.Description + " ";
                        }
                        TempData["msg"] = errors;
                    }
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
                return RedirectToAction("Register");
            }
        }
    }
}
