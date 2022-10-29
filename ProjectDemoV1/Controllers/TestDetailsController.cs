using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;

namespace ProjectDemoV1.Controllers
{
    public class TestDetailsController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: TestDetails
        public ActionResult Index(int id)
        {
            var testDetails = db.TestDetails.Include(t => t.Account).Include(t => t.Subject).Where(a => a.AccountId == id);

            List<QuestionTest> QT = db.questionTests.ToList();
            List<TestDetail> TD = db.TestDetails.Where(a => a.AccountId == id).ToList();
            return View(testDetails.OrderByDescending(x=>x.CreateDate).ToList());
        }


        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Questions.Find(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }


        /*[HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }*/

        public ActionResult ViewTestDetails(int id)
        {

            var questionTests = db.questionTests.Include(t => t.TestDetail).Include(t => t.Question).Include(t => t.Answer).Where(td=>td.TestDetailId == id);


            List<TestDetail> details = db.TestDetails.ToList();
            var subject = "";
            var score = 0.0;
            var totalQuestion = 0;
            foreach (var item in details)
            {
                if (id == item.TestDetailId)
                {
                    subject = item.Subject.SubjectName;
                    score = item.Score;
                    totalQuestion = item.Subject.TotalQuestion;
                }
            }

            ViewBag.TestDetailId = id;
            ViewBag.TotalQuestions = totalQuestion;
            ViewBag.SubjectTitle = subject;
            ViewBag.Score = score;


            return View(questionTests.ToList());
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
