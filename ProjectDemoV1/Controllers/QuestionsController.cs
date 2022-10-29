using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.Security;

namespace ProjectDemoV1.Controllers
{

    public class QuestionsController :  Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: Questions


        [MyAuthorizeAttribute(Roles = "Admin,Moderator")]
        public ActionResult Index(int id)
        {
            var questions = db.Questions.Include(q => q.Account).Include(q => q.Answer).Include(q => q.Level).Include(q => q.Status).Include(q => q.Subject).Include(q => q.TestType).Where(w => w.Subject.SubjectId==id).Where(w => w.StatusId == 1);
            return View(questions.ToList());
        }

        //import question
        public ActionResult ImportQuestion(HttpPostedFileBase postedFile)
        {

            try
            {
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Upload/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls":
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx":
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }

                    DataTable dtExcel = new DataTable();
                    conString = string.Format(conString, filePath);
                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT *from [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dtExcel);
                                connExcel.Close();
                            }
                        }
                    }
                    conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            sqlBulkCopy.DestinationTableName = "dbo.[Questions]";

                            sqlBulkCopy.ColumnMappings.Add("QuestionContent", "QuestionContent");
                            sqlBulkCopy.ColumnMappings.Add("OptionA", "OptionA");
                            sqlBulkCopy.ColumnMappings.Add("OptionB", "OptionB");
                            sqlBulkCopy.ColumnMappings.Add("OptionC", "OptionC");
                            sqlBulkCopy.ColumnMappings.Add("OptionD", "OptionD");
                            sqlBulkCopy.ColumnMappings.Add("AccountId", "AccountId");
                            sqlBulkCopy.ColumnMappings.Add("SubjectId", "SubjectId");
                            sqlBulkCopy.ColumnMappings.Add("StatusId", "StatusId");
                            sqlBulkCopy.ColumnMappings.Add("LevelId", "LevelId");
                            sqlBulkCopy.ColumnMappings.Add("TestTypeId", "TestTypeId");
                            sqlBulkCopy.ColumnMappings.Add("Answer_Id", "Answer_Id");
                            sqlBulkCopy.ColumnMappings.Add("Solution", "Solution");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcel);
                            con.Close();
                        }
                    }

                }
                return RedirectToAction("Index","QuestionsApprove");
            }
            catch
            {
                return RedirectToAction("Index", "QuestionsApprove");
            }
        }


        [MyAuthorizeAttribute(Roles = "Admin,Moderator")]
        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        // GET: Questions/Create

        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Questions.Find(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }



        [MyAuthorizeAttribute(Roles = "Admin,Moderator")]
        public ActionResult Create()
        {
            ViewBag.StatusDefault = 2;
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "QuestionId,QuestionContent,OptionA,OptionB,OptionC,OptionD,Image,Solution,AccountId,SubjectId,StatusId,LevelId,TestTypeId,Answer_Id")] Question question, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage!=null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    var Image = new Question
                    {
                        Image = imageData
                    };
                    question.Image = Image.Image;
                }
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index", "Questions", new { id = question.SubjectId });
            }
            ViewBag.StatusDefault = 2;
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // GET: Questions/Edit/5


        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, [Bind(Include = "QuestionId,QuestionContent,OptionA,OptionB,OptionC,OptionD,Image,Solution,AccountId,SubjectId,StatusId,LevelId,TestTypeId,Answer_Id")] Question question, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var questions = db.Questions.AsNoTracking().SingleOrDefault(e => e.QuestionId == id);

                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    var Image = new Question
                    {
                        Image = imageData
                    };
                    question.Image = Image.Image;
                }
                else
                {
                    question.Image = questions.Image;
                }
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Questions", new { id = question.SubjectId });
            }
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // GET: Questions/Delete/5


        [MyAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index","Questions", new { id = question.SubjectId });
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
