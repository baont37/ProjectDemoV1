using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectDemoV1.Controllers
{
    public class MakeTestController : Controller

    {
        private ClassDbContext db = new ClassDbContext();
        

        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Questions.Find(id).Image;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }


        public ActionResult ChooseSubject()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseSubject(ViewTestDetail _testDetail)
        {
            TestDetail testDetail = new TestDetail();
            List<QuestionTest> questionTests = new List<QuestionTest>();
            var subject = db.Subjects.FirstOrDefault(o => o.SubjectId == _testDetail.SubjectId);

            /*List<Question> allEasy = new List<Question>();
            List<Question> allMedium = new List<Question>();
            List<Question> allHard = new List<Question>();
            List<Question> allQuestion = db.Questions.ToList();
            foreach (var item in allQuestion)
            {
                if ((item.TestTypeId == 2) && (item.SubjectId == subject.SubjectId) && (item.LevelId == 1) && (item.StatusId == 2))
                {
                    allEasy.Add(item);
                }
                if ((item.TestTypeId == 2) && (item.SubjectId == subject.SubjectId) && (item.LevelId == 2) && (item.StatusId == 2))
                {
                    allMedium.Add(item);
                }
                if ((item.TestTypeId == 2) && (item.SubjectId == subject.SubjectId) && (item.LevelId == 3) && (item.StatusId == 2))
                {
                    allHard.Add(item);
                }
            }*/
            List<Question> allEasy = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 1).ToList();
            List<Question> allMedium = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 2).ToList();
            List<Question> allHard = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 3).ToList();

            if ((allEasy.Count < (subject.TotalQuestion) / 10 * 7) || (allMedium.Count < (subject.TotalQuestion) / 10 * 2) || (allHard.Count < (subject.TotalQuestion) / 10 * 1))
            {
                return RedirectToAction("Error","Home");
            }

            var trans = db.Database.BeginTransaction();

            testDetail.CreateDate = DateTime.Now;
            testDetail.AccountId = int.Parse(Session["AccountId"].ToString());
            testDetail.SubjectId = _testDetail.SubjectId;
            testDetail.Score = 0;
            testDetail.Submitted = false;
            var temp = db.TestDetails.Add(testDetail);
            if (Request["submit"] == "true")
            {
                trans.Commit();
            }
            else
                trans.Rollback();
            db.SaveChanges();
            _testDetail.CreateDate = testDetail.CreateDate;
            _testDetail.TestDetailId = temp.TestDetailId;

            var rand = new Random();

            List<int> listIndexEasy = new List<int>();
            int number;
            for (int i = 0; i < subject.TotalQuestion / 10 * 7; i++)
            {
                do
                {
                    number = rand.Next(0, allEasy.Count - 1);
                } while (listIndexEasy.Contains(number));
                listIndexEasy.Add(number);
            }
            List<int> listIndexMedium = new List<int>();

            for (int i = 0; (i < subject.TotalQuestion / 10 * 2); i++)
            {
                do
                {
                    number = rand.Next(0, allMedium.Count - 1);
                } while (listIndexMedium.Contains(number));
                listIndexMedium.Add(number);
            }
            List<int> listIndexHard = new List<int>();

            for (int i = 0; (i < subject.TotalQuestion / 10 * 1); i++)
            {
                do
                {
                    number = rand.Next(0, allHard.Count - 1);
                } while (listIndexHard.Contains(number));
                listIndexHard.Add(number);
            }


            foreach (var index in listIndexEasy)
            {
                questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allEasy[index].QuestionId, 5));
            }
            foreach (var index in listIndexMedium)
            {
                questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allMedium[index].QuestionId, 5));
            }
            foreach (var index in listIndexHard)
            {
                questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allHard[index].QuestionId, 5));
            }

            /*for (int i = 0; i < (subject.TotalQuestion) / 10 * 5; i++)
            {
               questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allEasy[i].QuestionId, 5));
            }
            for (int i = 0; i < (subject.TotalQuestion) / 10 * 3; i++)
            {
               questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allMedium[i].QuestionId, 5));
            }
            for (int i = 0; i < (subject.TotalQuestion) / 10 * 2; i++)
            {
               questionTests.Add(new QuestionTest(_testDetail.TestDetailId, allHard[i].QuestionId, 5));
            }*/

            foreach (var questionTest in questionTests)
            {
                db.questionTests.Add(questionTest);
            }
            db.SaveChanges();
            return RedirectToAction("MakeTest", _testDetail);
        }
        public ActionResult MakeTest(ViewTestDetail _testDetail)
        {
            /*TestDetail testDetail = db.TestDetails.FirstOrDefault(o => o.TestDetailId == _testDetail.TestDetailId);

            if (testDetail.Submitted == true)
            {
                return RedirectToAction("ViewScore", testDetail);
            }*/

            Subject subject = db.Subjects.FirstOrDefault(o => o.SubjectId == _testDetail.SubjectId);

            List<QuestionTest> listQuestion = (from a in db.questionTests
                                               where a.TestDetailId == _testDetail.TestDetailId
                                               select a).ToList();
            List<QuestionInQuestionTest> QuestionInQuestionTest = new List<QuestionInQuestionTest>();
            foreach (var item in listQuestion)
            {
                Question questionDetail = db.Questions.Find(item.QuestionId);
                QuestionInQuestionTest.Add(new QuestionInQuestionTest(item.QuetionTestId, item.TestDetailId, questionDetail.QuestionId, -1, questionDetail.QuestionContent, questionDetail.OptionA, questionDetail.OptionB, questionDetail.OptionC, questionDetail.OptionD, questionDetail.Image, questionDetail.Answer_Id));

            }

            var model = new ViewQuestionInQuestionTest();
            model.TestDetailId = _testDetail.TestDetailId.ToString();
            model.Questions = QuestionInQuestionTest;


            ViewBag.OutTime = DateTime.Parse(_testDetail.CreateDate.ToString()).AddMinutes(subject.Duration);

            ViewBag.SubjectName = subject.SubjectName;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeTest(int testDetailId, QuestionInQuestionTest[] Questions)
        {
            TestDetail testDetail = db.TestDetails.FirstOrDefault(o => o.TestDetailId == testDetailId);

            if (testDetail.Submitted == true)
            {
                return RedirectToAction("ViewScore", testDetail);
            }
            var quetionTestIdList = Questions.Select(o => o.QuetionTestId).ToList();
            var quetionTestIdListDistinct = quetionTestIdList.Distinct().ToList();

            if (quetionTestIdList.Count != quetionTestIdListDistinct.Count)
            {
                // Xử lý gia nlanaj
            }

            if (!ModelState.IsValid)
            {
                // return ....
            }
            foreach (var question in Questions)
            {

                var questionTest = db.questionTests.FirstOrDefault(o => o.QuetionTestId == question.QuetionTestId);
                if (question.UserAnswer != 0)
                {
                    questionTest.AnswerId = question.UserAnswer;
                    db.SaveChanges();
                }


            }


            List<QuestionTest> listQuestionTest = (from a in db.questionTests
                                                   where a.TestDetailId == testDetailId
                                                   select a).ToList();
            List<QuestionInQuestionTest> QuestionInQuestionTest = new List<QuestionInQuestionTest>();
            foreach (var item in listQuestionTest)
            {
                Question questionDetail = db.Questions.Find(item.QuestionId);
                QuestionInQuestionTest.Add(new QuestionInQuestionTest(item.QuetionTestId, item.TestDetailId, questionDetail.QuestionId, item.AnswerId, questionDetail.QuestionContent, questionDetail.OptionA, questionDetail.OptionB, questionDetail.OptionC, questionDetail.OptionD, questionDetail.Image, questionDetail.Answer_Id));

            }
            double score = 0;
            foreach (var item in QuestionInQuestionTest)
            {
                if (item.AnswerId == item.UserAnswer)
                {
                    score += 10.0 / (Convert.ToDouble(Questions.Length));
                }
            }

            var testDetailInfo = db.TestDetails.FirstOrDefault(o => o.TestDetailId == testDetailId);
            if (testDetailInfo != null)
            {
                testDetailInfo.Score = score;
                testDetailInfo.Submitted = true;
                db.SaveChanges();

            }
            return RedirectToAction("ViewScore", testDetailInfo);
        }

        public ActionResult ViewScore(TestDetail testDetailInfo)
        {
            Subject subject = db.Subjects.FirstOrDefault(o => o.SubjectId == testDetailInfo.SubjectId);
            ViewBag.SubjectName = subject.SubjectName;
            return View(testDetailInfo);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeTestAgain(int testDetailId)
        {
            var testDetailFind = db.TestDetails.FirstOrDefault(o => o.TestDetailId == testDetailId);


            List<QuestionTest> listQuestionTest = (from a in db.questionTests
                                                   where a.TestDetailId == testDetailId
                                                   select a).ToList();
            List<QuestionInQuestionTest> QuestionInQuestionTest = new List<QuestionInQuestionTest>();
            foreach (var item in listQuestionTest)
            {
                Question questionDetail = db.Questions.Find(item.QuestionId);
                QuestionInQuestionTest.Add(new QuestionInQuestionTest(item.QuetionTestId, item.TestDetailId, questionDetail.QuestionId, item.AnswerId, questionDetail.QuestionContent, questionDetail.OptionA, questionDetail.OptionB, questionDetail.OptionC, questionDetail.OptionD, questionDetail.Image, questionDetail.Answer_Id));
            }

            List<QuestionTest> questionTests = new List<QuestionTest>();
            var subject = db.Subjects.FirstOrDefault(o => o.SubjectId == testDetailFind.SubjectId);

            List<Question> allEasy = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 1).ToList();
            List<Question> allMedium = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 2).ToList();
            List<Question> allHard = db.Questions.Where(o => o.SubjectId == subject.SubjectId).Where(o => o.StatusId == 1)
                                        .Where(o => o.TestTypeId == 2).Where(o => o.LevelId == 3).ToList();

            var rand = new Random();

            List<int> listIndexEasy = new List<int>();
            List<int> listIndexMedium = new List<int>();
            List<int> listIndexHard = new List<int>();

            /*for (int i = 0; i < allEasy.Count; i++)
            {
                foreach (var item in QuestionInQuestionTest)
                {
                    if (item.QuestionId == allEasy[i].QuestionId && item.UserAnswer != item.AnswerId)
                    {
                        listIndexEasy.Add(i);
                    }
                }
            }   */

            foreach (var item in QuestionInQuestionTest)
            {
                for (int i = 0; i < allEasy.Count; i++)
                {
                    if (item.QuestionId == allEasy[i].QuestionId && item.UserAnswer != item.AnswerId)
                    {
                        listIndexEasy.Add(i);
                    }
                }

                for (int i = 0; i < allMedium.Count; i++)
                {
                    if (item.QuestionId == allMedium[i].QuestionId && item.UserAnswer != item.AnswerId)
                    {
                        listIndexMedium.Add(i);
                    }
                }

                for (int i = 0; i < allHard.Count; i++)
                {                    
                    if (item.QuestionId == allHard[i].QuestionId && item.UserAnswer != item.AnswerId)
                    {
                        listIndexHard.Add(i);
                    }
                    
                }
            }

              
            int number;


            while (listIndexEasy.Count < subject.TotalQuestion / 10 * 7)
            {
                do
                {
                    number = rand.Next(0, allEasy.Count - 1);
                } while (listIndexEasy.Contains(number));
                listIndexEasy.Add(number);
            }

            while (listIndexMedium.Count < subject.TotalQuestion / 10 * 2)
            {
                do
                {
                    number = rand.Next(0, allMedium.Count - 1);
                } while (listIndexMedium.Contains(number));
                listIndexMedium.Add(number);
            }

            while (listIndexHard.Count < subject.TotalQuestion / 10 * 1)
            {
                do
                {
                    number = rand.Next(0, allHard.Count - 1);
                } while (listIndexHard.Contains(number));
                listIndexHard.Add(number);
            }

            TestDetail testDetail = new TestDetail();
            var trans = db.Database.BeginTransaction();

            testDetail.CreateDate = DateTime.Now;
            testDetail.AccountId = Convert.ToInt32(Session["AccountId"]);
            testDetail.SubjectId = subject.SubjectId;
            testDetail.Score = 0;
            testDetail.Submitted = false;
            var temp = db.TestDetails.Add(testDetail);
            if (Request["submit"] == "true")
            {
                trans.Commit();
            }
            else
                trans.Rollback();
           
            foreach (var index in listIndexEasy)
            {
                questionTests.Add(new QuestionTest(testDetail.TestDetailId, allEasy[index].QuestionId, 5));
            }
            foreach (var index in listIndexMedium)
            {
                questionTests.Add(new QuestionTest(testDetail.TestDetailId, allMedium[index].QuestionId, 5));
            }
            foreach (var index in listIndexHard)
            {
                questionTests.Add(new QuestionTest(testDetail.TestDetailId, allHard[index].QuestionId, 5));
            }

            foreach (var questionTest in questionTests)
            {
                db.questionTests.Add(questionTest);
            }
            db.SaveChanges();
            return RedirectToAction("MakeTest", testDetail);

        }
    }
}