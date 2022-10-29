using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.Security;
using ProjectDemoV1.ViewModel;

namespace ProjectDemoV1.Controllers
{

    [MyAuthorizeAttribute(Roles = "Admin,Moderator")]
    public class SubjectsController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Combination);
            var allQuestion = db.Questions.ToList();
            List<StaticSubject> staticSubjects = new List<StaticSubject>();
            foreach (var item in subjects)
            {
                //int totalAppproveQuestion = db.Questions.Where(o => o.SubjectId == item.SubjectId && o.StatusId == 1).ToList().Count;
                int count = 0;
                foreach (var question in allQuestion)
                {
                    if ((question.SubjectId == item.SubjectId) && (question.StatusId == 1))
                    {
                        count++;
                    }
                }
                staticSubjects.Add(new StaticSubject(item.SubjectId, item.SubjectName, item.Duration, count, item.Combination.CombinationName));
            }

            return View(staticSubjects);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.CombinationId = new SelectList(db.Combinations, "CombinationId", "CombinationName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,SubjectName,Duration,TotalQuestion,ImgLink,CombinationId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CombinationId = new SelectList(db.Combinations, "CombinationId", "CombinationName", subject.CombinationId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombinationId = new SelectList(db.Combinations, "CombinationId", "CombinationName", subject.CombinationId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,SubjectName,Duration,TotalQuestion,ImgLink,CombinationId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombinationId = new SelectList(db.Combinations, "CombinationId", "CombinationName", subject.CombinationId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
