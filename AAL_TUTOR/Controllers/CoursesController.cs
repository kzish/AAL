using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;
using System.Net.Http;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using AAL_ADMIN.Repository;
using AAL_ADMIN.Globals;
using AAL_TUTOR.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace Admin.Controllers
{
    [Route("Courses")]
    [Authorize(Roles = "tutor")]
    public class CoursesController : Controller
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

        public CoursesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MoodleRepository moodleRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.moodleRepository = moodleRepository;
        }

        [HttpGet("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteTutor(string id)
        {
            ViewBag.title = "Delete Tutor";
            try
            {
                var tutor = db.MMoodleUser.Where(i => i.AspnetUserId == id).FirstOrDefault();
                dynamic res = this.moodleRepository.DeleteMoodleUser(tutor);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    //remove moodle user, aspnetuser
                    db.MMoodleUser.Remove(tutor);
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

        [HttpGet("CreateCourse")]
        public IActionResult CreateCourse()
        {
            ViewBag.title = "Create Course";
            return View();
        }


        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateTutor(MTutorCourses course)
        {
            ViewBag.title = "Create Course";
            //
            try
            {
                //
                course.AspnetUserId = userManager.GetUserId(HttpContext.User);
                dynamic res = moodleRepository.CreateMoodleCourse(course);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    TempData["type"] = "success";
                    TempData["msg"] = "Created Course successfully";
                    course.MoodleCourseId = res.moodle_course_id;
                    db.MTutorCourses.Add(course);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Index")]
        [HttpGet("")]
        public IActionResult Index(int page = 1)
        {
            ViewBag.title = "Courses";
            //_userManager.GetUserAsync(HttpContext.User);
            var tutor = db.AspNetUsers
                .Where(i => i.Email == User.Identity.Name)
                .Include(i => i.MTutorCourses)
                .FirstOrDefault();

            var courses = db.MTutorCourses
                .Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User))
                .ToPagedList(page, 10);
            //
            ViewBag.courses = courses;
            //
            return View();
        }


    }
}
