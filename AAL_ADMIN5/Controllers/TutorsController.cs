using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;
using SharedModels;
using System.Net.Http;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Globals;

namespace Admin.Controllers
{
    [Route("Tutors")]
    [Route("")]
    [Authorize(Roles = "admin")]
    public class TutorsController : Controller
    {
        dbContext db = new dbContext();
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        MoodleRepository moodleRepository;
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public TutorsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MoodleRepository moodleRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.moodleRepository = moodleRepository;
        }

        [HttpGet("Index")]
        [HttpGet("")]
        public IActionResult Index(string search_param, int page = 1)
        {
            ViewBag.title = "Tutors";

            var tutors_query = db.Aspnetusers.AsQueryable();
            //filter
            if (!string.IsNullOrEmpty(search_param))
            {
                tutors_query = tutors_query
                    .Where(i => i.MTutor.Firstname.Contains(search_param)
                    || i.MTutor.Surname.Contains(search_param)
                    || i.MTutor.About.Contains(search_param)
                    || i.MTutor.Email.Contains(search_param)
                    || i.MTutorCourses.Where(c => c.Title.Contains(search_param)).Any()
                    || i.MTutorCourses.Where(c => c.Description.Contains(search_param)).Any()
                    );
            }
            //
            tutors_query = tutors_query.Where(i => i.Aspnetuserroles.Any(r => r.Role.Name == "tutor"))
            .Include(i => i.MTutor)
            .Include(i => i.MAspnetUserLanguages)
            .Include(i => i.MTutorCourses);

            var tutors = tutors_query.ToPagedList(page, 15);

            ViewBag.tutors = tutors;
            ViewBag.page = page;
            ViewBag.search_param = search_param;
            return View();
        }

        [HttpGet("EnableTutor/{id}/{page}")]
        public IActionResult EnableTutor(string id, int page)
        {
            var tutor = db.MTutors.Where(i => i.AspnetUserId == id).FirstOrDefault();
            tutor.Active = 1;
            db.SaveChanges();
            TempData["type"] = "success";
            TempData["msg"] = "Enabled";
            return RedirectToAction("Index");
        }

        [HttpGet("DisableTutor/{id}/{page}")]
        public IActionResult DisableTutor(string id, int page)
        {
            var tutor = db.MTutors.Where(i => i.AspnetUserId == id).FirstOrDefault();
            tutor.Active = 0;
            db.SaveChanges();
            TempData["type"] = "warning";
            TempData["msg"] = "Disabled";
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteTutor/{id}")]
        public async Task<IActionResult> DeleteTutor(string id)
        {
            ViewBag.title = "Delete Tutor";
            try
            {
                var tutor = db.MMoodleUsers.Where(i => i.AspnetUserId == id).FirstOrDefault();
                dynamic res = this.moodleRepository.DeleteMoodleUser(tutor);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    //remove moodle user, aspnetuser
                    db.MMoodleUsers.Remove(tutor);
                    var client_user = await userManager.FindByIdAsync(id);
                    await userManager.DeleteAsync(client_user);
                    TempData["type"] = "success";
                    TempData["msg"] = "Deleted";
                }

            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet("CreateTutor")]
        public IActionResult CreateTutor()
        {
            ViewBag.title = "Create Tutor";
            return View();
        }

        [HttpPost("CreateTutor")]
        public async Task<IActionResult> CreateTutor(Aspnetuser aspNetUser, MTutor tutor)
        {
            ViewBag.title = "Create Tutor";
            //
            try
            {
                db.Database.BeginTransaction();
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
                    TempData["msg"] = res.msg.ToString();
                    return RedirectToAction("CreateTutor", "Tutors", new { Id = 0 });
                }
                else if (res.res == "ok")
                {
                    //create identity user
                    var created = await userManager.CreateAsync(id_user, aspNetUser.PasswordHash);
                    if (created.Succeeded)
                    {
                        //add moodle user to db
                        new_tutor_moodle_user.MoodleId = res.moodle_user_id;
                        db.MMoodleUsers.Add(new_tutor_moodle_user);
                        tutor.AspnetUserId = id_user.Id;
                        tutor.Email = aspNetUser.Email;
                        db.MTutors.Add(tutor);
                        db.SaveChanges();
                        //add identity user to tutor role
                        await userManager.AddToRoleAsync(id_user, "tutor");
                        db.Database.CommitTransaction();
                        //
                        TempData["type"] = "success";
                        TempData["msg"] = "Saved";
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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
                return RedirectToAction("CreateTutor", "Tutors", new { id = aspNetUser.Id ?? "0" });
            }
        }

        [HttpGet("EditTutor/{id}")]
        public IActionResult EditTutor(string id)
        {
            ViewBag.title = "Edit Tutor";
            //
            var tutor = db.Aspnetusers
                .Where(i => i.Id == id)
                .Include(i => i.MMoodleUsers)
                .Include(i => i.MTutorRatings)
                .Include(i => i.MAspnetUserLanguages)
                .Include(i => i.MTutor)
                .FirstOrDefault();
            //
            var language_levels = db.ELanguageLevels.ToList();
            var languages = db.MLanguages.ToList();
            var countries = db.MCountries.ToList();


            ViewBag.language_levels = language_levels;
            ViewBag.languages = languages;
            ViewBag.countries = countries;
            ViewBag.tutor = tutor;
            //
            return View();
        }


        ////[HttpGet("EditClient/{id}")]
        ////public IActionResult EditClient(string id)
        ////{
        ////    ViewBag.title = "Edit Client";
        ////    var client = db.AspNetUsers.Where(i => i.Id == id).Include(i => i.MClient).FirstOrDefault();
        ////    ViewBag.client = client;
        ////    return View();
        ////}
        ////[HttpPost("EditClient")]
        ////public IActionResult EditClient(MClient client, string id)
        ////{
        ////    ViewBag.title = "Edit Client";
        ////    try
        ////    {
        ////        var asp_net_user = db.AspNetUsers.Where(i => i.Id == id).Include(i => i.MClient).FirstOrDefault();
        ////        asp_net_user.MClient = client;
        ////        db.SaveChanges();
        ////        TempData["msg"] = "Saved";
        ////        TempData["type"] = "success";
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        TempData["msg"] = ex.Message;
        ////        TempData["type"] = "error";
        ////    }
        ////    return RedirectToAction("EditClient", new { id });
        ////}

        ////[HttpGet("ScheduleClientUpdates/{id}")]
        ////public IActionResult ScheduleClientUpdates(string id)
        ////{
        ////    var asp_net_user = db.AspNetUsers
        ////        .Where(i => i.Id == id)
        ////        .Include(i => i.MScheduledUpdates)
        ////        .Include(i => i.MClient)
        ////        .FirstOrDefault();
        ////    ViewBag.title = "ScheduleClientUpdates";
        ////    ViewBag.client = asp_net_user;
        ////    return View();
        ////}

        ////[HttpPost("AddScheduleClientUpdates")]
        ////public IActionResult AddScheduleClientUpdates(MScheduledUpdates schedule)
        ////{
        ////    try
        ////    {
        ////        ViewBag.title = "ScheduleClientUpdates";
        ////        db.MScheduledUpdates.Add(schedule);
        ////        db.SaveChanges();
        ////        TempData["msg"] = "Saved";
        ////        TempData["type"] = "success";
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        TempData["msg"] = ex.Message;
        ////        TempData["type"] = "error";
        ////    }
        ////    return RedirectToAction("ScheduleClientUpdates", new { id = schedule.AspNetUserId });
        ////}

        ////[HttpGet("DeleteScheduleClientUpdates/{id}")]
        ////public IActionResult DeleteScheduleClientUpdates(int id)
        ////{
        ////    string asp_net_user_id = string.Empty;
        ////    try
        ////    {
        ////        ViewBag.title = "DeleteScheduleClientUpdates";
        ////        var schedule = db.MScheduledUpdates.Find(id);
        ////        asp_net_user_id = schedule.AspNetUserId;
        ////        db.MScheduledUpdates.Remove(schedule);
        ////        db.SaveChanges();
        ////        TempData["msg"] = "Deleted";
        ////        TempData["type"] = "success";
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        TempData["msg"] = ex.Message;
        ////        TempData["type"] = "error";
        ////    }
        ////    return RedirectToAction("ScheduleClientUpdates", new { id = asp_net_user_id });
        ////}


        [HttpPost("UpdateTutorProfile")]
        public void UpdateTutorProfile(string aspnet_user_id
            , string tutor_country_iso
            , string[] languageLevel_Beginner
            , string[] languageLevel_Intermediate
            , string[] languageLevel_Advanced
            , string tutor_about)
        {
            string i = "";

        }

    }
}
