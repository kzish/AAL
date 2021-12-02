﻿using System;
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
            ViewBag.tutor = tutor;
            //
            return View();
        }

        [HttpGet("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            ViewBag.title = "Delete Course";
            try
            {
                var course = db.MTutorCourses
                    .Where(i => i.Id == id)
                    .Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User))
                    .FirstOrDefault();
                dynamic res = this.moodleRepository.DeleteMoodleCourse(course);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    //remove moodle user, aspnetuser
                    db.MTutorCourses.Remove(course);
                    db.SaveChanges();
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
        public IActionResult CreateCourse(MTutorCourses course)
        {
            ViewBag.title = "Create Course";
            //
            try
            {
                //append tutor email to the course title incase of duplicates with other tutors with the same course name
                var tutor = db.MTutor.Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                course.Title = course.Title + " - " + tutor.Email;
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

        [HttpGet("EditCourse/{id}")]
        public IActionResult EditCourse(int id)
        {
            ViewBag.title = "Edit Course";
            var course = db.MTutorCourses
                .Where(i => i.Id == id)
                .Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User))
                .FirstOrDefault();

            var tutor = db.AspNetUsers
                .Where(i => i.Id == userManager.GetUserId(HttpContext.User))
                .FirstOrDefault();

            ViewBag.course = course;
            ViewBag.tutor = tutor;

            return View();
        }

        [HttpPost("EditCourse")]
        public IActionResult EditCourse(MTutorCourses course)
        {
            ViewBag.title = "Edit Course";
            //
            try
            {
                var tutor = db.MTutor.Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User)).FirstOrDefault();
                course.Title = course.Title + " - " + tutor.Email;
                course.AspnetUserId = userManager.GetUserId(HttpContext.User);
                dynamic res = moodleRepository.EditMoodleCourse(course);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    TempData["type"] = "success";
                    TempData["msg"] = "Updated Course successfully";
                    db.Entry(course).State = EntityState.Modified;
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

    }
}
