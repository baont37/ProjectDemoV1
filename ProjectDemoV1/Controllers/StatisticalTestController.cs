using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.Security;

namespace ProjectDemoV1.Controllers
{
    public class StatisticalTestController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: StatisticalTest
        public ActionResult Index(int? page)
        {
            var pageNum = page ?? 1;
            var pageSize = 10;
            var testDetails = db.TestDetails.Include(t => t.Account).Include(t => t.Subject).Where(s => s.Submitted == true);
            return View(testDetails.OrderByDescending(x => x.CreateDate).ToPagedList(pageNum, pageSize));
        }

        // GET: StatisticalTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDetail testDetail = db.TestDetails.Find(id);
            if (testDetail == null)
            {
                return HttpNotFound();
            }
            return View(testDetail);
        }

        // GET: StatisticalTest/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: StatisticalTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestDetailId,CreateDate,Score,Submitted,AccountId,SubjectId")] TestDetail testDetail)
        {
            if (ModelState.IsValid)
            {
                db.TestDetails.Add(testDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", testDetail.AccountId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", testDetail.SubjectId);
            return View(testDetail);
        }

        // GET: StatisticalTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDetail testDetail = db.TestDetails.Find(id);
            if (testDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", testDetail.AccountId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", testDetail.SubjectId);
            return View(testDetail);
        }

        // POST: StatisticalTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestDetailId,CreateDate,Score,Submitted,AccountId,SubjectId")] TestDetail testDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", testDetail.AccountId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", testDetail.SubjectId);
            return View(testDetail);
        }

        // GET: StatisticalTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDetail testDetail = db.TestDetails.Find(id);
            if (testDetail == null)
            {
                return HttpNotFound();
            }
            return View(testDetail);
        }

        // POST: StatisticalTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestDetail testDetail = db.TestDetails.Find(id);
            db.TestDetails.Remove(testDetail);
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
