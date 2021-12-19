using AAL_API5.ApiModels;
using Globals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger<TutorsController> logger;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public TutorsController(ILogger<TutorsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("FetchTutors")]
        public JsonResult FetchTutors(int page = 1)
        {
            page--;//page starts at 0
            try
            {
                var tutors = db.AspNetUsers
                .Where(i => i.AspNetUserRoles.Any(r => r.Role.Name == "tutor"))
                .Where(i => i.MTutor.Active)
                .Include(i => i.MTutor)
                .Include(i => i.MAspnetUserLanguages)
                .Include(i => i.MTutorCourses)
                .Skip(page * 15)
                .Take(15)
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
                    apiTutor.CoutryName = db.MCountries.Find(t.MTutor.CoutryIso).CountryName;
                    //
                    foreach(var lang in t.MAspnetUserLanguages)
                    {
                        apiTutor.Languages.Add(db.MLanguages.Find(lang.LanguageIdFk).LanguageName);
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
                    data = apiTutors
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
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
                logger.LogError(ex.Message);
                return NotFound();
            }
        }

    }
}
