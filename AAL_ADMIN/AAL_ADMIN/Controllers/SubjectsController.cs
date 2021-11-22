using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AAL_ADMIN.Models;
using PagedList.Core;
using System.Net.Http;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Admin.Controllers
{
    [Route("Subjects")]
    [Authorize(Roles = "admin")]
    public class SubjectsController : Controller
    {
        dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("Index")]
        [HttpGet("")]
        public IActionResult Index(int page = 1)
        {
            db.MSubject.RemoveRange(db.MSubject.Where(i => i.SubjectTitle == "").ToList());//remove empty subjects
            db.SaveChanges();
            ViewBag.title = "Subjects";
            var subjects = db.MSubject
                .AsQueryable()
                .ToPagedList(page, 15);
            ViewBag.subjects = subjects;
            return View();
        }

        [HttpGet("DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            ViewBag.title = "Delete Subject";
            try
            {
                var subject = db.MSubject.Find(id);
                db.MSubject.Remove(subject);
                await db.SaveChangesAsync();
                TempData["type"] = "success";
                TempData["msg"] = "Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpGet("CreateSubject/{id}")]
        public IActionResult CreateSubject(int id, int page = 1)
        {
            ViewBag.title = "Create Subject";
            MSubject subject = null;
            List<MTopics> topics = null;
            if (id == 0)//create a new one
            {
                subject = new MSubject();
                subject.SubjectTitle = "";
                db.MSubject.Add(subject);
                db.SaveChanges();
                topics = new List<MTopics>();
            }
            else
            {
                subject = db.MSubject.Find(id);
                topics = db.MTopics.Where(i => i.SubjectIdFk == subject.Id).ToList();
            }
            ViewBag.subject = subject;
            ViewBag.topics = topics.AsQueryable().ToPagedList(page, 15);
            return View();
        }

        [HttpPost("CreateTopic")]
        public async Task<IActionResult> CreateTopic(MTopics topic)
        {
            try
            {
                db.MTopics.Add(topic);
                await db.SaveChangesAsync();
                TempData["type"] = "success";
                TempData["msg"] = "Saved";
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
            }
            return RedirectToAction($"CreateSubject", "Subjects", new { id = topic.SubjectIdFk });
        }

        /// <summary>
        /// creates or edits a subject
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="topics"></param>
        /// <returns></returns>
        [HttpPost("CreateSubject")]
        public async Task<IActionResult> CreateSubject(MSubject subject, List<MTopics> topics)
        {
            ViewBag.title = "Create Subject";
            db.Database.BeginTransaction();
            try
            {
                var exist = db.MSubject.Any(i => i.Id == subject.Id);
                subject.MTopics = topics;
                if (exist)
                {
                    db.Entry(subject).State = EntityState.Modified;
                }
                else
                {
                    db.MSubject.Add(subject);
                }

                await db.SaveChangesAsync();
                db.Database.CommitTransaction();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
                return RedirectToAction($"CreateSubject", "Subjects");
            }
        }


        [HttpGet("DeleteTopic/{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = db.MTopics.Find(id);
            try
            {
                db.MTopics.Remove(topic);
                await db.SaveChangesAsync();
                TempData["type"] = "success";
                TempData["msg"] = "Deleted";
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = "Error: " + ex.Message;
            }
            return RedirectToAction($"CreateSubject", "Subjects", new { id =  topic.SubjectIdFk});

        }




    }
}
