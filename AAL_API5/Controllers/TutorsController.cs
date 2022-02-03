﻿using AAL_API5.ApiModels;
using Globals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using SharedModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAL_API.Controllers
{
    [Route("Tutors")]
    public class TutorsController : Controller
    {
        dbContext db = new dbContext();

        private const int array_limit = 15;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public TutorsController()
        {
        }

        [HttpGet("FetchTutors")]
        public JsonResult FetchTutors(string search_param, string selected_countries, string selected_languages, int page = 1)
        {
            var list_countries = new List<string>();
            var list_languages = new List<string>();

            if (!string.IsNullOrEmpty(selected_countries))
            {
                list_countries = selected_countries.Split(',').ToList();
            }
            if (!string.IsNullOrEmpty(selected_languages))
            {
                list_languages = selected_languages.Split(',').ToList();
            }

            page--;//page starts at 0
            try
            {
                var tutors_query = db.Aspnetusers.AsQueryable();
                //filter
                if (!string.IsNullOrEmpty(search_param))
                {
                    tutors_query = tutors_query
                        .Where(i => i.MTutor.Firstname.Contains(search_param)
                        || i.MTutor.Surname.Contains(search_param)
                        || i.MTutor.About.Contains(search_param)
                        || i.MTutorCourses.Where(c => c.Title.Contains(search_param)).Any()
                        || i.MTutorCourses.Where(c => c.Description.Contains(search_param)).Any()
                        );
                }
                //
                tutors_query = tutors_query.Where(i => i.Aspnetuserroles.Any(r => r.Role.Name == "tutor"))
                .Where(i => i.MTutor.Active==1)
                .Include(i => i.MTutor)
                .Include(i => i.MAspnetUserLanguages)
                .Include(i => i.MTutorCourses);

                if(list_languages.Count > 0)
                {
                    var db_languages = db.MLanguages.Where(i => list_languages.Contains(i.Iso)).Select(i=>i.Id).ToList();
                    tutors_query = tutors_query.Where(i => i.MAspnetUserLanguages.Any(l => db_languages.Contains(l.LanguageIdFk)));
                }

                if (list_countries.Count > 0)
                {
                    var db_countries = db.MCountries.Where(i => list_countries.Contains(i.CountryIso)).Select(i => i.CountryIso).ToList();
                    tutors_query = tutors_query.Where(i => db_countries.Contains(i.MTutor.CoutryIso));
                }

                var tutors = tutors_query.Skip(page * array_limit)
                .Take(array_limit)
                .ToList();

                //convert to api model
                var apiTutors = new List<apiTutor>();
                foreach (var t in tutors)
                {
                    var apiTutor = new apiTutor();
                    apiTutor.AspnetUserId = t.MTutor.AspnetUserId;
                    apiTutor.Firstname = t.MTutor.Firstname;
                    apiTutor.Surname = t.MTutor.Surname;
                    apiTutor.Email = t.MTutor.Email;
                    apiTutor.ImageUrl = t.MTutor.ImageUrl;
                    apiTutor.CoutryIso = t.MTutor.CoutryIso;
                    apiTutor.About = t.MTutor.About;
                    apiTutor.Mobile = t.MTutor.Mobile;
                    apiTutor.OtherMobile = t.MTutor.OtherMobile;
                    apiTutor.MobileAvailableOnWhatsapp = t.MTutor.MobileAvailableOnWhatsapp;
                    apiTutor.ShowEmail = t.MTutor.ShowEmail;
                    apiTutor.CoutryName = t.MTutor.CoutryIso == null ? "" : db.MCountries.Find(t.MTutor.CoutryIso).CountryName;
                    //
                    foreach (var lang in t.MAspnetUserLanguages)
                    {
                        var language = new Language() { 
                            level = lang.LanguageLevelIdFk,
                            lang = db.MLanguages.Find(lang.LanguageIdFk).LanguageName
                        };
                        apiTutor.Languages.Add(language);
                    }
                    //
                    foreach (var course in t.MTutorCourses)
                    {
                        apiTutor.Courses.Add(course.Title);
                    }
                    apiTutors.Add(apiTutor);
                }

                return Json(new
                {
                    res = "ok",
                    tutors = apiTutors,
                    total_tutors = tutors_query.Count(),
                    items_per_page = array_limit
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
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
                Log.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("FetchCountries")]
        public JsonResult FetchCountries()
        {
            try
            {
                var countries = db.MCountries.ToList();
                return Json(new
                {
                    res = "ok",
                    countries = countries,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

        [HttpGet("FetchLanguages")]
        public JsonResult FetchLanguages()
        {
            try
            {
                var languages = db.MLanguages.ToList();
                return Json(new
                {
                    res = "ok",
                    languages = languages,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }


        [HttpGet("FetchTimePeriods")]
        public JsonResult FetchTimePeriods()
        {
            try
            {
                var time_periods = db.ETimePeriods.OrderBy(i => i.Sequence).ToList();
                return Json(new
                {
                    res = "ok",
                    time_periods = time_periods,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

    }
}
