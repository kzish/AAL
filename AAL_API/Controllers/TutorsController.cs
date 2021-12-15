using AAL_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        Globals.Globals globals;

        public TutorsController (IConfiguration configuration)
        {
            this.globals = configuration.GetSection("Globals").Get<Globals.Globals>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("FetchTutors")]
        public JsonResult FetchTutors(int page = 1)
        {
            page--;//page starts at 0
            try
            {
                var tutors = db.AspNetUsers
                .Where(i => i.AspNetUserRoles.Any(r => r.Role.Name == "tutor"))
                .Where(i=>i.MTutor.Active)
                .Include(i => i.MTutor)
                .Skip(page * 15)
                .Take(15)
                .ToList();
                //var tutors = db.MTutor.ToList();

                return Json(new
                {
                    res = "ok",
                    data = tutors
                }, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                });
            }
            catch (Exception ex)
            {
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
                var filePath = System.IO.Path.Combine(globals.profile_pictures_folder, file_name);
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
                return NotFound();
            }
        }

    }
}
