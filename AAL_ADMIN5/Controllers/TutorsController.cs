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

        [HttpGet("ViewTutorProfile/{id}")]
        public IActionResult ViewTutorProfile(string id)
        {
            ViewBag.title = "ViewTutorProfile";

            var tutor = db.Aspnetusers
                .Where(i => i.Id == id)
                .Include(i => i.MMoodleUsers)
                .Include(i => i.MTutorRatings)
                .Include(i => i.MAspnetUserLanguages)
                .Include(i => i.MTutor)
                .Include(i => i.MTutorEducations)
                .Include(i => i.MTutorCourses)
                .Include(i => i.MTutorWorkExperiences)
                .Include(i => i.MAspnetUserAvailableTimes)
                .FirstOrDefault();
            //
            var language_levels = db.ELanguageLevels.ToList();
            var languages = db.MLanguages.ToList();
            var countries = db.MCountries.ToList();
            var degrees = db.MDiplomasOrDegrees.ToList();
            var time_periods = db.ETimePeriods.OrderBy(i => i.Sequence).ToList();


            ViewBag.time_periods = time_periods;
            ViewBag.language_levels = language_levels;
            ViewBag.languages = languages;
            ViewBag.degrees = degrees;
            ViewBag.countries = countries;
            ViewBag.tutor = tutor;

            return View();
        }


    }
}
