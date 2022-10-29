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
using ProjectDemoV1.ViewModel;

namespace ProjectDemoV1.Controllers
{


    [MyAuthorizeAttribute(Roles = "Admin")]
    public class QuestionsApproveController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: QuestionsApprove

        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Combination);
            var allQuestion = db.Questions.ToList();
            List<StaticSubject> staticSubjects = new List<StaticSubject>();
            foreach (var item in subjects)
            {
                int count = 0;
                foreach (var question in allQuestion)
                {
                    if ((question.SubjectId == item.SubjectId) &&(question.StatusId == 2))
                    {
                        count++;
                    }
                }
                //int totalAppproveQuestion = db.Questions.Where(o => o.SubjectId == item.SubjectId && o.StatusId == 2).ToList().Count;
                staticSubjects.Add(new StaticSubject(item.SubjectId, item.SubjectName, item.Duration, count, item.Combination.CombinationName));
            }

                return View(staticSubjects);
        }



        public ActionResult ApproveDetails(int subjectId, int testTypeId/*, string searching*/)
        {

            //List<Question> questions = db.Questions.Include(q => q.Account).Include(q => q.Answer).Include(q => q.Level).Include(q => q.Status).Include(q => q.Subject).Include(q => q.TestType).Where(w => w.Subject.SubjectId == subjectId).Where(w => w.TestType.TestTypeId == testTypeId).Where(w => w.StatusId == 2).ToList();
            List<Question> questions = db.Questions.Where(w => w.SubjectId == subjectId &&  w.TestTypeId == testTypeId && w.StatusId == 2).ToList();
            /*List<Subject> subjects = db.Subjects.ToList();
            var Subject = "";
            foreach (var item in subjects)
            {
                if (subjectId == item.SubjectId)
                {
                    Subject = item.SubjectName;
                }
            }*/

            ViewBag.Subject = db.Subjects.FirstOrDefault(o => o.SubjectId == subjectId).SubjectName;
            ViewBag.searching = new SelectList(db.Levels, "LevelName", "LevelName");

                return View(questions.ToList());
        }



        [ActionName("ApproveDetails")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ApproveDetailsPost(int subjectId, int testTypeId, string SubmitButton, string SubmitButtonAll, int? id, string searching)
        {
            if (id == null)
            {
                var questions = db.Questions.Where(w => w.SubjectId == subjectId).Where(w => w.TestTypeId == testTypeId).Where(w => w.StatusId == 2);

                if (!String.IsNullOrEmpty(searching))
                {
                    questions = db.Questions.Where(w => w.SubjectId == subjectId).Where(w => w.TestTypeId == testTypeId).Where(s => s.Level.LevelName.Contains(searching)).Where(w => w.Status.StatusId == 2);
                }
                ViewBag.searching = new SelectList(db.Levels, "LevelName", "LevelName");

                List<Subject> subjects = db.Subjects.ToList();
                var Subject = "";
                foreach (var item in subjects)
                {
                    if (subjectId == item.SubjectId)
                    {
                        Subject = item.SubjectName;
                    }
                }
                ViewBag.Subject = Subject;

                if (SubmitButtonAll != null)
                {
                    foreach (var item in questions)
                    {
                        item.StatusId = 1;
                    }
                    db.SaveChanges();
                }

                /*string buttonAll = SubmitButtonAll;
                
                if (buttonAll.Equals("Duyệt tất cả"))
                {
                    foreach (var item in questions)
                    {
                        item.StatusId = 1;
                    }
                    db.SaveChanges();
                }*/
                return View(questions.ToList());
            }

            string buttonClicked = SubmitButton;
            if (buttonClicked == "Duyệt")
            {
                Question question = db.Questions.Find(id);
                Session["SubjectId"] = question.SubjectId;
                Session["TestTypeId"] = question.TestTypeId;
                question.StatusId = 1;
                db.SaveChanges();
            }

            
            return RedirectToAction("ApproveDetails", "QuestionsApprove", new { subjectId = @Session["SubjectId"], testTypeId = @Session["TestTypeId"] });
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
                return RedirectToAction("Index", "QuestionsApprove");
            }
            catch
            {
                return RedirectToAction("Index", "QuestionsApprove");
            }
        }

        
        // GET: QuestionsApprove/Details/5
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


        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Questions.Find(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }


        // GET: QuestionsApprove/Create
        public ActionResult Create()
        {
            TempData["Success"] = "Thêm câu hỏi thành công";
            ViewBag.StatusDefault = 2;
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName");
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName");
            return View();
        }

        // POST: QuestionsApprove/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "QuestionId,QuestionContent,OptionA,OptionB,OptionC,OptionD,Image,Solution,AccountId,SubjectId,StatusId,LevelId,TestTypeId,Answer_Id")] Question question, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
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
                Session["SubjectId"] = question.SubjectId;
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.StatusDefault = 2;
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", question.AccountId);
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // GET: QuestionsApprove/Edit/5
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
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", question.AccountId);
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // POST: QuestionsApprove/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, int subjectId, int testTypeId, [Bind(Include = "QuestionId,QuestionContent,OptionA,OptionB,OptionC,OptionD,Image,Solution,AccountId,SubjectId,StatusId,LevelId,TestTypeId,Answer_Id")] Question question, HttpPostedFileBase uploadImage)
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
                /*var data = db.Questions.Where(s => s.Subject.SubjectId == subjectId && s.TestType.TestTypeId == testTypeId).FirstOrDefault();
                Session["SubjectId"] = data.SubjectId;
                Session["TestTypeId"] = data.TestTypeId;*/
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ApproveDetails", "QuestionsApprove", new { subjectId = subjectId, testTypeId = testTypeId });
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", question.AccountId);
            ViewBag.Answer_Id = new SelectList(db.Answers, "AnswerId", "AnswerName", question.Answer_Id);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "LevelName", question.LevelId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", question.StatusId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", question.SubjectId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "TestTypeId", "TestTypeName", question.TestTypeId);
            return View(question);
        }

        // GET: QuestionsApprove/Delete/5
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

        // POST: QuestionsApprove/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question); 
            db.SaveChanges();
            return RedirectToAction("ApproveDetails", "QuestionsApprove", new { subjectId = question.SubjectId, testTypeId = question.TestTypeId });
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
