using Globals;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using Serilog;
using SharedModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAL_API.Controllers
{
    [Route("Courses")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class CoursesController : Controller
    {
        dbContext db = new dbContext();

        private const int array_limit = 15;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public CoursesController()
        {
        }

        [HttpGet("FetchCourse")]
        public IActionResult FetchCourse(int moodle_course_id)
        {
            try
            {
                var course = db.MTutorCourses.Where(i => i.MoodleCourseId == moodle_course_id).FirstOrDefault();

                if (course != null)
                {
                    return Ok(new
                    {
                        res = "ok",
                        course = course
                    });
                }
                else
                {
                    return Ok(new
                    {
                        res = "err",
                        msg = "course does not exist"
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = "Error fetching course",
                    debug = ex.Message
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
