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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;
using Globals;
using SharedModels;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AAL_TUTOR5.Controllers
{
    [Route("Tutors")]
    [Route("")]
    [Authorize(Roles = "tutor")]
    public class TutorsController : Controller
    {
        //dbContext db = new dbContext();
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        MoodleRepository moodleRepository;
        EsRepository esRepository;
        IConfiguration configuration;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //db.Dispose();
        }

        public TutorsController(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, MoodleRepository moodleRepository, EsRepository esRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.moodleRepository = moodleRepository;
            this.esRepository = esRepository;
            this.configuration = configuration;
        }

        //[HttpGet("Index")]
        //[HttpGet("")]
        //public IActionResult Index(int page = 1)
        //{
        //    ViewBag.title = "Tutors";
        //    var tutors = userManager
        //        .GetUsersInRoleAsync("tutor")
        //        .Result
        //        .AsQueryable()
        //        .ToPagedList(page, 15);
        //    ViewBag.tutors = tutors;
        //    return View();
        //}

        [HttpGet("DeleteTutor/{id}")]
        public async Task<IActionResult> DeleteTutor(string id)
        {
            ViewBag.title = "Delete Tutor";
            try
            {
                var tutor = AppSettings.db.MMoodleUsers.Where(i => i.AspnetUserId == id).FirstOrDefault();
                dynamic res = this.moodleRepository.DeleteMoodleUser(tutor);

                if (res.res == "err")
                {
                    TempData["type"] = "error";
                    TempData["msg"] = res.msg.ToString();
                }
                else if (res.res == "ok")
                {
                    //remove moodle user, aspnetuser
                    AppSettings.db.MMoodleUsers.Remove(tutor);
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

        [HttpPost("CreateTutor")]
        public async Task<IActionResult> CreateTutor(Aspnetuser aspNetUser, MTutor tutor)
        {
            ViewBag.title = "Create Tutor";
            //
            try
            {
                AppSettings.db.Database.BeginTransaction();
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
                        AppSettings.db.MMoodleUsers.Add(new_tutor_moodle_user);
                        tutor.AspnetUserId = id_user.Id;
                        tutor.Email = aspNetUser.Email;
                        AppSettings.db.MTutors.Add(tutor);
                        AppSettings.db.SaveChanges();
                        //add identity user to tutor role
                        await userManager.AddToRoleAsync(id_user, "tutor");
                        AppSettings.db.Database.CommitTransaction();
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

        [HttpGet("Profile")]
        [HttpGet("")]
        public IActionResult Profile()
        {
            ViewBag.title = "Edit Tutor";
            //_userManager.GetUserAsync(HttpContext.User);
            var tutor = AppSettings.db.Aspnetusers
                .Where(i => i.Email == User.Identity.Name)
                .Include(i => i.MMoodleUsers)
                .Include(i => i.MTutorRatings)
                .Include(i => i.MAspnetUserLanguages)
                .Include(i => i.MTutor)
                .Include(i => i.MTutorEducations)
                .Include(i => i.MTutorWorkExperiences)
                .Include(i => i.MAspnetUserAvailableTimes)
                .FirstOrDefault();
            //
            var language_levels = AppSettings.db.ELanguageLevels.ToList();
            var languages = AppSettings.db.MLanguages.ToList();
            var countries = AppSettings.db.MCountries.ToList();
            var degrees = AppSettings.db.MDiplomasOrDegrees.ToList();
            var time_periods = AppSettings.db.ETimePeriods.OrderBy(i => i.Sequence).ToList();
            //
            ViewBag.time_periods = time_periods;
            ViewBag.language_levels = language_levels;
            ViewBag.languages = languages;
            ViewBag.degrees = degrees;
            ViewBag.countries = countries;
            ViewBag.tutor = tutor;
            //
            return View();
        }

        [HttpPost("UpdateBasicInformation")]
         public async Task<IActionResult> UpdateBasicInformation(string aspnet_user_id
            , sbyte MobileAvailableOnWhatsapp
            , string Mobile
            , string Firstname
            , string Surname
            , string Email
            , string OtherMobile
            , sbyte ShowEmail
            )
        {
            try
            {
                var tutor = AppSettings.db.Aspnetusers
                .Where(i => i.Email == User.Identity.Name)
                .Include(i => i.MTutor)
                .FirstOrDefault();
                //
                tutor.MTutor.Firstname = Firstname;
                tutor.MTutor.Surname = Surname;
                tutor.MTutor.Email = Email;
                tutor.MTutor.Mobile = Mobile;
                tutor.MTutor.OtherMobile = OtherMobile;
                tutor.MTutor.ShowEmail = ShowEmail;
                tutor.MTutor.MobileAvailableOnWhatsapp = MobileAvailableOnWhatsapp;
                //
                await AppSettings.db.SaveChangesAsync();
                var res = esRepository.IndexTutor(tutor.Id);
               
                TempData["type"] = "success";
                TempData["msg"] = "Saved";
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }
            return RedirectToAction("Profile");

        }

        [HttpPost("UpdateTutorProfile")]
        public async Task<IActionResult> UpdateTutorProfile(string aspnet_user_id
            , string tutor_country_iso
            , string[] languageLevel_Beginner
            , string[] languageLevel_Intermediate
            , string[] languageLevel_Advanced
            , string tutor_about
            , IFormFile profile_image)
        {
            try
            {
                var tutor = AppSettings.db.Aspnetusers
                .Where(i => i.Email == User.Identity.Name)
                //.Include(i => i.MMoodleUser)
                //.Include(i => i.MTutorRating)
                .Include(i => i.MAspnetUserLanguages)
                //.Include(i => i.MTutorsSubjects)
                .Include(i => i.MTutor)
                .FirstOrDefault();

                var language_levels = AppSettings.db.ELanguageLevels.ToList();
                //
                var beginner_language_levels = new List<MAspnetUserLanguage>();
                var intermediate_language_levels = new List<MAspnetUserLanguage>();
                var advanced_language_levels = new List<MAspnetUserLanguage>();
                //beginner lanaguage level
                foreach (var lang in languageLevel_Beginner)
                {
                    if (string.IsNullOrEmpty(lang)) continue;
                    var ll = new MAspnetUserLanguage();
                    ll.LanguageIdFk = int.Parse(lang);
                    ll.LanguageLevelIdFk = language_levels.Where(i => i.LanguageLevel == "Beginner").First().Id;
                    beginner_language_levels.Add(ll);
                }
                //intermediate lanaguage level
                foreach (var lang in languageLevel_Intermediate)
                {
                    if (string.IsNullOrEmpty(lang)) continue;
                    var ll = new MAspnetUserLanguage();
                    ll.LanguageIdFk = int.Parse(lang);
                    ll.LanguageLevelIdFk = language_levels.Where(i => i.LanguageLevel == "Intermediate").First().Id;
                    intermediate_language_levels.Add(ll);
                }
                //advanced lanaguage level
                foreach (var lang in languageLevel_Advanced)
                {
                    if (string.IsNullOrEmpty(lang)) continue;
                    var ll = new MAspnetUserLanguage();
                    ll.LanguageIdFk = int.Parse(lang);
                    ll.LanguageLevelIdFk = language_levels.Where(i => i.LanguageLevel == "Advanced").First().Id;
                    advanced_language_levels.Add(ll);
                }
                //
                advanced_language_levels.AddRange(intermediate_language_levels);
                advanced_language_levels.AddRange(beginner_language_levels);
                //
                tutor.MTutor.CoutryIso = tutor_country_iso;
                tutor.MTutor.About = tutor_about;
                tutor.MAspnetUserLanguages = advanced_language_levels;
                //

                if (profile_image != null)
                {
                    if (!string.IsNullOrEmpty(tutor.MTutor.ImageUrl))
                    {
                        System.IO.File.Delete($"{AppSettings.profile_pictures_folder}/{tutor.MTutor.ImageUrl}");
                    }
                    var filename = $"{Guid.NewGuid()}.{Path.GetExtension(profile_image.FileName)}";
                    var filepath = $"{AppSettings.profile_pictures_folder}/{filename}";
                    using (var stream = System.IO.File.Create(filepath))
                    {
                        await profile_image.CopyToAsync(stream);
                        stream.Dispose();
                    }
                    tutor.MTutor.ImageUrl = $"{filename}";
                }

                //
                AppSettings.db.SaveChanges();
                var res = esRepository.IndexTutor(tutor.Id);

                TempData["type"] = "success";
                TempData["msg"] = "Saved";
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }
            return RedirectToAction("Profile");

        }

        [HttpGet("GetImage/{file_name}")]
        public async Task<IActionResult> GetImage(string file_name)
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppSettings.profile_pictures_folder, file_name);
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                    stream.Dispose();
                }
                memory.Position = 0;
                return File(memory.ToArray(), "image/jpg");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpPost("AddEducation")]
        public IActionResult AddEducation(MTutorEducation education)
        {
            try
            {
                education.AspnetUserId = userManager.GetUserId(HttpContext.User);
                AppSettings.db.MTutorEducations.Add(education);
                AppSettings.db.SaveChanges();
                TempData["type"] = "success";
                TempData["msg"] = "Saved";
                var res = esRepository.IndexTutor(userManager.GetUserId(HttpContext.User));
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }

            return RedirectToAction("Profile");
        }

        [HttpGet("RemoveEducation/{id}")]
        public IActionResult RemoveEducation(int id)
        {
            try
            {
                var education = AppSettings.db.MTutorEducations
                    .Where(i => i.Id == id)
                    .Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User))
                    .First();
                AppSettings.db.MTutorEducations.Remove(education);
                AppSettings.db.SaveChanges();
                TempData["type"] = "success";
                TempData["msg"] = "Deleted";
                var res = esRepository.IndexTutor(userManager.GetUserId(HttpContext.User));
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }

            return RedirectToAction("Profile");
        }

        [HttpPost("AddWorkExperience")]
        public IActionResult AddWorkExperience(MTutorWorkExperience workexp)
        {
            try
            {
                workexp.AspnetUserId = userManager.GetUserId(HttpContext.User);
                AppSettings.db.MTutorWorkExperiences.Add(workexp);
                AppSettings.db.SaveChanges();
                TempData["type"] = "success";
                TempData["msg"] = "Saved";
                var res = esRepository.IndexTutor(userManager.GetUserId(HttpContext.User));
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }

            return RedirectToAction("Profile");
        }

        [HttpGet("RemoveWorkExperience/{id}")]
        public IActionResult RemoveWorkExperience(int id)
        {
            try
            {
                var workexp = AppSettings.db.MTutorWorkExperiences
                    .Where(i => i.Id == id)
                    .Where(i => i.AspnetUserId == userManager.GetUserId(HttpContext.User))
                    .First();
                AppSettings.db.MTutorWorkExperiences.Remove(workexp);
                AppSettings.db.SaveChanges();
                TempData["type"] = "success";
                TempData["msg"] = "Deleted";
                var res = esRepository.IndexTutor(userManager.GetUserId(HttpContext.User));
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }

            return RedirectToAction("Profile");
        }

        [HttpPost("SaveTimeTable")]
        public async Task<IActionResult> SaveTimeTable(IFormCollection formcollection)
        {
            try
            {
                var aspnet_user = AppSettings.db.Aspnetusers
                    .Where(i => i.Id == userManager.GetUserId(HttpContext.User))
                    .Include(i=>i.MAspnetUserAvailableTimes)
                    .First();
                //
                var post_data = await new StreamReader(Request.Body).ReadToEndAsync();
                var days_of_week = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                var time_periods = AppSettings.db.ETimePeriods.OrderBy(i=>i.Sequence).ToList();
                aspnet_user.MAspnetUserAvailableTimes.Clear();//remove old items
                //
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                foreach (var day in days_of_week)
                {
                    foreach (var time_period in time_periods)
                    {
                        if (formcollection[time_period.Id + "_" + day] == "true")
                        {
                            var time_table = new MAspnetUserAvailableTime();
                            time_table.AspnetUserId = aspnet_user.Id;
                            time_table.Weekday = day;
                            time_table.TimePeriod = time_period.Id;
                            aspnet_user.MAspnetUserAvailableTimes.Add(time_table);
                        }
                    }
                }
                
                AppSettings.db.SaveChanges();
                var res = esRepository.IndexTutor(aspnet_user.Id);
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error occurred";
                Log.Error(ex.Message);
            }

            return RedirectToAction("Profile");
        }

    }
}
