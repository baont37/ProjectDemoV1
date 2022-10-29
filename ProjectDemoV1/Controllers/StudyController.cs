using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;

namespace ProjectDemoV1.Controllers
{
    public class StudyController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: Study
        public ActionResult Index(int id, string searching)
        {
            var questions = db.Questions.Include(q => q.Account).Include(q => q.Answer).Include(q => q.Level).Include(q => q.Status).Include(q => q.Subject).Include(q => q.TestType).Where(m => m.SubjectId == id).Where(t => t.TestTypeId == 1).Where(s => s.StatusId == 1);
            if (!String.IsNullOrEmpty(searching))
            {
                questions = db.Questions.Include(q => q.Account).Include(q => q.Answer).Include(q => q.Level).Include(q => q.Status).Include(q => q.Subject).Include(q => q.TestType).Where(l => l.Level.LevelName.Contains(searching)).Where(s => s.StatusId == 1).Where(t => t.TestTypeId == 1).Where(m=> m.SubjectId == id);
            }
            List<Subject> subjects = db.Subjects.ToList();
            var temp = "";
            foreach (var item in subjects)
            {
                if (id == item.SubjectId)
                {
                    temp = item.SubjectName;
                }
            }

            ViewBag.searching = new SelectList(db.Levels, "LevelName", "LevelName");
            ViewBag.SubjectTitle = temp;
            return View(questions.OrderBy(x => x.QuestionId));
        }

        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Questions.Find(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }

        // GET: Study/Details/5
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
