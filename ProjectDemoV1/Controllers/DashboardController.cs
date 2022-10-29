using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Models;
using ProjectDemoV1.Data;
using Newtonsoft.Json;
using System.Data.Entity;
using ProjectDemoV1.Security;

namespace ProjectDemoV1.Controllers
{

    [MyAuthorizeAttribute(Roles = "Admin,Moderator")]
    public class DashboardController : Controller
    {
        private ClassDbContext db = new ClassDbContext();
        // GET: Dashboardz


        /*[Authorize(Roles = "Admin")]*/
        public ActionResult Statistic()
        {
            //Sum member
            var memberList = db.Accounts.ToList();
            int sumMember = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3)
                {
                    sumMember += 1;
                }
            }
            ViewBag.sumMember = sumMember;
            //Count member in day
            int memberInDay = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3 && a.CreateDate.Date == DateTime.Now.Date)
                {
                    memberInDay += 1;
                }
            }
            ViewBag.countMemberInDay = memberInDay;
            //Count member in month
            int memberInMonth = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3 && a.CreateDate.Month == DateTime.Now.Month)
                {
                    memberInMonth += 1;
                }
            }
            ViewBag.countMemberInMonth = memberInMonth;
            //Count member in year
            int memberInYear = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3 && a.CreateDate.Year == DateTime.Now.Year)
                {
                    memberInYear += 1;
                }
            }
            ViewBag.countMemberInYear = memberInYear;
            //Count member per month
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0, t12 = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3 && a.CreateDate.Year == DateTime.Now.Year)
                {
                    switch (a.CreateDate.Month)
                    {
                        case 1:
                            t1 += 1;
                            break;
                        case 2:
                            t2 += 1;
                            break;
                        case 3:
                            t3 += 1;
                            break;
                        case 4:
                            t4 += 1;
                            break;
                        case 5:
                            t5 += 1;
                            break;
                        case 6:
                            t6 += 1;
                            break;
                        case 7:
                            t7 += 1;
                            break;
                        case 8:
                            t8 += 1;
                            break;
                        case 9:
                            t9 += 1;
                            break;
                        case 10:
                            t10 += 1;
                            break;
                        case 11:
                            t11 += 1;
                            break;
                        case 12:
                            t12 += 1;
                            break;
                    }
                }
            }
            ViewBag.t1 = t1;
            ViewBag.t2 = t2;
            ViewBag.t3 = t3;
            ViewBag.t4 = t4;
            ViewBag.t5 = t5;
            ViewBag.t6 = t6;
            ViewBag.t7 = t7;
            ViewBag.t8 = t8;
            ViewBag.t9 = t9;
            ViewBag.t10 = t10;
            ViewBag.t11 = t11;
            ViewBag.t12 = t12;
            //Count member per Day
            int d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0, d7 = 0, d8 = 0, d9 = 0, d10 = 0, d11 = 0, d12 = 0, d13 = 0, d14 = 0,
                d15 = 0, d16 = 0, d17 = 0, d18 = 0, d19 = 0, d20 = 0, d21 = 0, d22 = 0, d23 = 0, d24 = 0, d25 = 0, d26 = 0, d27 = 0,
                d28 = 0, d29 = 0, d30 = 0, d31 = 0;
            foreach (Account a in memberList)
            {
                if (a.RoleId == 3 && a.CreateDate.Year == DateTime.Now.Year && a.CreateDate.Month == DateTime.Now.Month)
                {
                    switch (a.CreateDate.Day)
                    {
                        case 1:
                            d1 += 1;
                            break;
                        case 2:
                            d2 += 1;
                            break;
                        case 3:
                            d3 += 1;
                            break;
                        case 4:
                            d4 += 1;
                            break;
                        case 5:
                            d5 += 1;
                            break;
                        case 6:
                            d6 += 1;
                            break;
                        case 7:
                            d7 += 1;
                            break;
                        case 8:
                            d8 += 1;
                            break;
                        case 9:
                            d9 += 1;
                            break;
                        case 10:
                            d10 += 1;
                            break;
                        case 11:
                            d11 += 1;
                            break;
                        case 12:
                            d12 += 1;
                            break;
                        case 13:
                            d13 += 1;
                            break;
                        case 14:
                            d14 += 1;
                            break;
                        case 15:
                            d15 += 1;
                            break;
                        case 16:
                            d16 += 1;
                            break;
                        case 17:
                            d17 += 1;
                            break;
                        case 18:
                            d18 += 1;
                            break;
                        case 19:
                            d19 += 1;
                            break;
                        case 20:
                            d20 += 1;
                            break;
                        case 21:
                            d21 += 1;
                            break;
                        case 22:
                            d22 += 1;
                            break;
                        case 23:
                            d23 += 1;
                            break;
                        case 24:
                            d24 += 1;
                            break;
                        case 25:
                            d25 += 1;
                            break;
                        case 26:
                            d26 += 1;
                            break;
                        case 27:
                            d27 += 1;
                            break;
                        case 28:
                            d28 += 1;
                            break;
                        case 29:
                            d29 += 1;
                            break;
                        case 30:
                            d30 += 1;
                            break;
                        case 31:
                            d31 += 1;
                            break;
                    }
                }
            }
            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;
            ViewBag.d10 = d10;
            ViewBag.d11 = d11;
            ViewBag.d12 = d12;
            ViewBag.d13 = d13;
            ViewBag.d14 = d14;
            ViewBag.d15 = d15;
            ViewBag.d16 = d16;
            ViewBag.d17 = d17;
            ViewBag.d18 = d18;
            ViewBag.d19 = d19;
            ViewBag.d20 = d20;
            ViewBag.d21 = d21;
            ViewBag.d22 = d22;
            ViewBag.d23 = d23;
            ViewBag.d24 = d24;
            ViewBag.d25 = d25;
            ViewBag.d26 = d26;
            ViewBag.d27 = d27;
            ViewBag.d28 = d28;
            ViewBag.d29 = d29;
            ViewBag.d30 = d30;
            ViewBag.d31 = d31;
            //Sum question
            float sumQuestion = 0;
            foreach (var q in db.Questions)
            {
                if (q.StatusId == 1)
                {
                    sumQuestion += 1;
                }
            }
            ViewBag.sumQuestion = sumQuestion;
            //Count study question
            List<Question> questionList = new List<Question>();
            questionList = db.Questions.ToList();
            float percentStudyQuestion = 0;
            float countStudyQuestion = 0;
            foreach (Question q in questionList)
            {
                if (q.TestTypeId == 1 && q.StatusId == 1)
                {
                    countStudyQuestion += 1;
                }
            }
            percentStudyQuestion = (countStudyQuestion / sumQuestion * 100);
            ViewBag.percentStudyQuestion = Math.Round(percentStudyQuestion, 1);
            ViewBag.countStudyQuestion = countStudyQuestion;
            //Count test question
            float percentTestQuestion = 0;
            float countTestQuestion = 0;
            foreach (Question q in questionList)
            {
                if (q.TestTypeId == 2 && q.StatusId == 1)
                {
                    countTestQuestion += 1;
                }
            }
            percentTestQuestion = countTestQuestion / sumQuestion * 100;
            ViewBag.percentTestQuestion = Math.Round(percentTestQuestion, 1);
            ViewBag.countTestQuestion = countTestQuestion;
            //Count easy question
            float percentEasyQuestion = 0;
            float countEasyQuestion = 0;
            foreach (Question q in questionList)
            {
                if (q.LevelId == 1 && q.StatusId == 1)
                {
                    countEasyQuestion += 1;
                }
            }
            percentEasyQuestion = (countEasyQuestion / sumQuestion * 100);
            ViewBag.percentEasyQuestion = Math.Round(percentEasyQuestion, 1);
            ViewBag.countEasyQuestion = countEasyQuestion;
            //Count medium question
            float percentMediumQuestion = 0;
            float countMediumQuestion = 0;
            foreach (Question q in questionList)
            {
                if (q.LevelId == 2 && q.StatusId == 1)
                {
                    countMediumQuestion += 1;
                }
            }
            percentMediumQuestion = (countMediumQuestion / sumQuestion * 100);
            ViewBag.percentMediumQuestion = Math.Round(percentMediumQuestion, 1);
            ViewBag.countMediumQuestion = countMediumQuestion;
            //Count hard question
            float percentHardQuestion = 0;
            float countHardQuestion = 0;
            foreach (Question q in questionList)
            {
                if (q.LevelId == 3 && q.StatusId == 1)
                {
                    countHardQuestion += 1;
                }
            }
            percentHardQuestion = (countHardQuestion / sumQuestion * 100);
            ViewBag.percentHardQuestion = Math.Round(percentHardQuestion, 1);
            ViewBag.countHardQuestion = countHardQuestion;
            //Sum Offical Test
            var testDetailList = db.TestDetails;
            ViewBag.sumTest = testDetailList.Count();
            //Count Offical Test In Day
            int countTestInDay = 0;
            foreach (TestDetail d in testDetailList)
            {
                if (d.CreateDate.Date == DateTime.Now.Date)
                {
                    countTestInDay += 1;
                }
            }
            ViewBag.countTestInDay = countTestInDay;
            //Count Offical Test In Month
            int countTestInMonth = 0;
            foreach (TestDetail d in testDetailList)
            {
                if (d.CreateDate.Month == DateTime.Now.Month)
                {
                    countTestInMonth += 1;
                }
            }
            ViewBag.countTestInMonth = countTestInMonth;
            //Count Offical Test In Year
            int countTestInYear = 0;
            foreach (TestDetail d in testDetailList)
            {
                if (d.CreateDate.Year == DateTime.Now.Year)
                {
                    countTestInYear += 1;
                }
            }
            ViewBag.countTestInYear = countTestInYear;
            //Count Test Per Month
            int tt1 = 0, tt2 = 0, tt3 = 0, tt4 = 0, tt5 = 0, tt6 = 0, tt7 = 0, tt8 = 0, tt9 = 0, tt10 = 0, tt11 = 0, tt12 = 0;
            foreach (TestDetail d in testDetailList)
            {
                if (d.CreateDate.Year == DateTime.Now.Year)
                {
                    switch (d.CreateDate.Month)
                    {
                        case 1:
                            tt1 += 1;
                            break;
                        case 2:
                            tt2 += 1;
                            break;
                        case 3:
                            tt3 += 1;
                            break;
                        case 4:
                            tt4 += 1;
                            break;
                        case 5:
                            tt5 += 1;
                            break;
                        case 6:
                            tt6 += 1;
                            break;
                        case 7:
                            tt7 += 1;
                            break;
                        case 8:
                            tt8 += 1;
                            break;
                        case 9:
                            tt9 += 1;
                            break;
                        case 10:
                            tt10 += 1;
                            break;
                        case 11:
                            tt11 += 1;
                            break;
                        case 12:
                            tt12 += 1;
                            break;
                    }
                }
            }
            ViewBag.tt1 = tt1;
            ViewBag.tt2 = tt2;
            ViewBag.tt3 = tt3;
            ViewBag.tt4 = tt4;
            ViewBag.tt5 = tt5;
            ViewBag.tt6 = tt6;
            ViewBag.tt7 = tt7;
            ViewBag.tt8 = tt8;
            ViewBag.tt9 = tt9;
            ViewBag.tt10 = tt10;
            ViewBag.tt11 = tt11;
            ViewBag.tt12 = tt12;
            //Count Test Per Day
            int td1 = 0, td2 = 0, td3 = 0, td4 = 0, td5 = 0, td6 = 0, td7 = 0, td8 = 0, td9 = 0, td10 = 0, td11 = 0, td12 = 0, td13 = 0, td14 = 0,
                td15 = 0, td16 = 0, td17 = 0, td18 = 0, td19 = 0, td20 = 0, td21 = 0, td22 = 0, td23 = 0, td24 = 0, td25 = 0, td26 = 0, td27 = 0,
                td28 = 0, td29 = 0, td30 = 0, td31 = 0;
            foreach (TestDetail d in testDetailList)
            {
                if (d.CreateDate.Year == DateTime.Now.Year && d.CreateDate.Month == DateTime.Now.Month)
                {
                    switch (d.CreateDate.Day)
                    {
                        case 1:
                            td1 += 1;
                            break;
                        case 2:
                            td2 += 1;
                            break;
                        case 3:
                            td3 += 1;
                            break;
                        case 4:
                            td4 += 1;
                            break;
                        case 5:
                            td5 += 1;
                            break;
                        case 6:
                            td6 += 1;
                            break;
                        case 7:
                            td7 += 1;
                            break;
                        case 8:
                            td8 += 1;
                            break;
                        case 9:
                            td9 += 1;
                            break;
                        case 10:
                            td10 += 1;
                            break;
                        case 11:
                            td11 += 1;
                            break;
                        case 12:
                            td12 += 1;
                            break;
                        case 13:
                            td13 += 1;
                            break;
                        case 14:
                            td14 += 1;
                            break;
                        case 15:
                            td15 += 1;
                            break;
                        case 16:
                            td16 += 1;
                            break;
                        case 17:
                            td17 += 1;
                            break;
                        case 18:
                            td18 += 1;
                            break;
                        case 19:
                            td19 += 1;
                            break;
                        case 20:
                            td20 += 1;
                            break;
                        case 21:
                            td21 += 1;
                            break;
                        case 22:
                            td22 += 1;
                            break;
                        case 23:
                            td23 += 1;
                            break;
                        case 24:
                            td24 += 1;
                            break;
                        case 25:
                            td25 += 1;
                            break;
                        case 26:
                            td26 += 1;
                            break;
                        case 27:
                            td27 += 1;
                            break;
                        case 28:
                            td28 += 1;
                            break;
                        case 29:
                            td29 += 1;
                            break;
                        case 30:
                            td30 += 1;
                            break;
                        case 31:
                            td31 += 1;
                            break;
                    }
                }
            }
            ViewBag.td1 = td1;
            ViewBag.td2 = td2;
            ViewBag.td3 = td3;
            ViewBag.td4 = td4;
            ViewBag.td5 = td5;
            ViewBag.td6 = td6;
            ViewBag.td7 = td7;
            ViewBag.td8 = td8;
            ViewBag.td9 = td9;
            ViewBag.td10 = td10;
            ViewBag.td11 = td11;
            ViewBag.td12 = td12;
            ViewBag.td13 = td13;
            ViewBag.td14 = td14;
            ViewBag.td15 = td15;
            ViewBag.td16 = td16;
            ViewBag.td17 = td17;
            ViewBag.td18 = td18;
            ViewBag.td19 = td19;
            ViewBag.td20 = td20;
            ViewBag.td21 = td21;
            ViewBag.td22 = td22;
            ViewBag.td23 = td23;
            ViewBag.td24 = td24;
            ViewBag.td25 = td25;
            ViewBag.td26 = td26;
            ViewBag.td27 = td27;
            ViewBag.td28 = td28;
            ViewBag.td29 = td29;
            ViewBag.td30 = td30;
            ViewBag.td31 = td31;
            //Count question by Subject
            int sqe1t1 = 0, sqe2t1 = 0, sqe3t1 = 0, sqe4t1 = 0, sqe5t1 = 0, sqe6t1 = 0, sqe7t1 = 0, sqe8t1 = 0;
            int sqe1t2 = 0, sqe2t2 = 0, sqe3t2 = 0, sqe4t2 = 0, sqe5t2 = 0, sqe6t2 = 0, sqe7t2 = 0, sqe8t2 = 0;
            int sqm1t1 = 0, sqm2t1 = 0, sqm3t1 = 0, sqm4t1 = 0, sqm5t1 = 0, sqm6t1 = 0, sqm7t1 = 0, sqm8t1 = 0;
            int sqm1t2 = 0, sqm2t2 = 0, sqm3t2 = 0, sqm4t2 = 0, sqm5t2 = 0, sqm6t2 = 0, sqm7t2 = 0, sqm8t2 = 0;
            int sqh1t1 = 0, sqh2t1 = 0, sqh3t1 = 0, sqh4t1 = 0, sqh5t1 = 0, sqh6t1 = 0, sqh7t1 = 0, sqh8t1 = 0;
            int sqh1t2 = 0, sqh2t2 = 0, sqh3t2 = 0, sqh4t2 = 0, sqh5t2 = 0, sqh6t2 = 0, sqh7t2 = 0, sqh8t2 = 0;
            foreach (Question s in questionList)
            {
                if (s.TestTypeId == 1 && s.StatusId == 1)
                {
                    switch (s.SubjectId)
                    {
                        case 1:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe1t1 += 1;
                                    break;
                                case 2:
                                    sqm1t1 += 1;
                                    break;
                                case 3:
                                    sqh1t1 += 1;
                                    break;
                            }
                            break;
                        case 2:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe2t1 += 1;
                                    break;
                                case 2:
                                    sqm2t1 += 1;
                                    break;
                                case 3:
                                    sqh2t1 += 1;
                                    break;
                            }
                            break;
                        case 3:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe3t1 += 1;
                                    break;
                                case 2:
                                    sqm3t1 += 1;
                                    break;
                                case 3:
                                    sqh3t1 += 1;
                                    break;
                            }
                            break;
                        case 4:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe4t1 += 1;
                                    break;
                                case 2:
                                    sqm4t1 += 1;
                                    break;
                                case 3:
                                    sqh4t1 += 1;
                                    break;
                            }
                            break;
                        case 5:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe5t1 += 1;
                                    break;
                                case 2:
                                    sqm5t1 += 1;
                                    break;
                                case 3:
                                    sqh5t1 += 1;
                                    break;
                            }
                            break;
                        case 6:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe6t1 += 1;
                                    break;
                                case 2:
                                    sqm6t1 += 1;
                                    break;
                                case 3:
                                    sqh6t1 += 1;
                                    break;
                            }
                            break;
                        case 7:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe7t1 += 1;
                                    break;
                                case 2:
                                    sqm7t1 += 1;
                                    break;
                                case 3:
                                    sqh7t1 += 1;
                                    break;
                            }
                            break;
                        case 8:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe8t1 += 1;
                                    break;
                                case 2:
                                    sqm8t1 += 1;
                                    break;
                                case 3:
                                    sqh8t1 += 1;
                                    break;
                            }
                            break;
                    }
                }
                if (s.TestTypeId == 2 && s.StatusId == 1)
                {
                    switch (s.SubjectId)
                    {
                        case 1:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe1t2 += 1;
                                    break;
                                case 2:
                                    sqm1t2 += 1;
                                    break;
                                case 3:
                                    sqh1t2 += 1;
                                    break;
                            }
                            break;
                        case 2:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe2t2 += 1;
                                    break;
                                case 2:
                                    sqm2t2 += 1;
                                    break;
                                case 3:
                                    sqh2t2 += 1;
                                    break;
                            }
                            break;
                        case 3:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe3t2 += 1;
                                    break;
                                case 2:
                                    sqm3t2 += 1;
                                    break;
                                case 3:
                                    sqh3t2 += 1;
                                    break;
                            }
                            break;
                        case 4:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe4t2 += 1;
                                    break;
                                case 2:
                                    sqm4t2 += 1;
                                    break;
                                case 3:
                                    sqh4t2 += 1;
                                    break;
                            }
                            break;
                        case 5:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe5t2 += 1;
                                    break;
                                case 2:
                                    sqm5t2 += 1;
                                    break;
                                case 3:
                                    sqh5t2 += 1;
                                    break;
                            }
                            break;
                        case 6:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe6t2 += 1;
                                    break;
                                case 2:
                                    sqm6t2 += 1;
                                    break;
                                case 3:
                                    sqh6t2 += 1;
                                    break;
                            }
                            break;
                        case 7:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe7t2 += 1;
                                    break;
                                case 2:
                                    sqm7t2 += 1;
                                    break;
                                case 3:
                                    sqh7t2 += 1;
                                    break;
                            }
                            break;
                        case 8:
                            switch (s.LevelId)
                            {
                                case 1:
                                    sqe8t2 += 1;
                                    break;
                                case 2:
                                    sqm8t2 += 1;
                                    break;
                                case 3:
                                    sqh8t2 += 1;
                                    break;
                            }
                            break;
                    }
                }
            }
            ViewBag.sqe1t1 = sqe1t1;
            ViewBag.sqm1t1 = sqm1t1;
            ViewBag.sqh1t1 = sqh1t1;
            ViewBag.sqe2t1 = sqe2t1;
            ViewBag.sqm2t1 = sqm2t1;
            ViewBag.sqh2t1 = sqh2t1;
            ViewBag.sqe3t1 = sqe3t1;
            ViewBag.sqm3t1 = sqm3t1;
            ViewBag.sqh3t1 = sqh3t1;
            ViewBag.sqe4t1 = sqe4t1;
            ViewBag.sqm4t1 = sqm4t1;
            ViewBag.sqh4t1 = sqh4t1;
            ViewBag.sqe5t1 = sqe5t1;
            ViewBag.sqm5t1 = sqm5t1;
            ViewBag.sqh5t1 = sqh5t1;
            ViewBag.sqe6t1 = sqe6t1;
            ViewBag.sqm6t1 = sqm6t1;
            ViewBag.sqh6t1 = sqh6t1;
            ViewBag.sqe7t1 = sqe7t1;
            ViewBag.sqm7t1 = sqm7t1;
            ViewBag.sqh7t1 = sqh7t1;
            ViewBag.sqe8t1 = sqe8t1;
            ViewBag.sqm8t1 = sqm8t1;
            ViewBag.sqh8t1 = sqh8t1;
            ViewBag.sqe1t2 = sqe1t2;
            ViewBag.sqm1t2 = sqm1t2;
            ViewBag.sqh1t2 = sqh1t2;
            ViewBag.sqe2t2 = sqe2t2;
            ViewBag.sqm2t2 = sqm2t2;
            ViewBag.sqh2t2 = sqh2t2;
            ViewBag.sqe3t2 = sqe3t2;
            ViewBag.sqm3t2 = sqm3t2;
            ViewBag.sqh3t2 = sqh3t2;
            ViewBag.sqe4t2 = sqe4t2;
            ViewBag.sqm4t2 = sqm4t2;
            ViewBag.sqh4t2 = sqh4t2;
            ViewBag.sqe5t2 = sqe5t2;
            ViewBag.sqm5t2 = sqm5t2;
            ViewBag.sqh5t2 = sqh5t2;
            ViewBag.sqe6t2 = sqe6t2;
            ViewBag.sqm6t2 = sqm6t2;
            ViewBag.sqh6t2 = sqh6t2;
            ViewBag.sqe7t2 = sqe7t2;
            ViewBag.sqm7t2 = sqm7t2;
            ViewBag.sqh7t2 = sqh7t2;
            ViewBag.sqe8t2 = sqe8t2;
            ViewBag.sqm8t2 = sqm8t2;
            ViewBag.sqh8t2 = sqh8t2;
            //Count Test by Subject Per Day
            int stt1d1 = 0, stt1d2 = 0, stt1d3 = 0, stt1d4 = 0, stt1d5 = 0, stt1d6 = 0, stt1d7 = 0, stt1d8 = 0, stt1d9 = 0, stt1d10 = 0, stt1d11 = 0, stt1d12 = 0,
                stt1d13 = 0, stt1d14 = 0, stt1d15 = 0, stt1d16 = 0, stt1d17 = 0, stt1d18 = 0, stt1d19 = 0, stt1d20 = 0, stt1d21 = 0, stt1d22 = 0, stt1d23 = 0,
                stt1d24 = 0, stt1d25 = 0, stt1d26 = 0, stt1d27 = 0, stt1d28 = 0, stt1d29 = 0, stt1d30 = 0, stt1d31 = 0;
            int stt2d1 = 0, stt2d2 = 0, stt2d3 = 0, stt2d4 = 0, stt2d5 = 0, stt2d6 = 0, stt2d7 = 0, stt2d8 = 0, stt2d9 = 0, stt2d10 = 0, stt2d11 = 0, stt2d12 = 0,
                stt2d13 = 0, stt2d14 = 0, stt2d15 = 0, stt2d16 = 0, stt2d17 = 0, stt2d18 = 0, stt2d19 = 0, stt2d20 = 0, stt2d21 = 0, stt2d22 = 0, stt2d23 = 0,
                stt2d24 = 0, stt2d25 = 0, stt2d26 = 0, stt2d27 = 0, stt2d28 = 0, stt2d29 = 0, stt2d30 = 0, stt2d31 = 0;
            int stt3d1 = 0, stt3d2 = 0, stt3d3 = 0, stt3d4 = 0, stt3d5 = 0, stt3d6 = 0, stt3d7 = 0, stt3d8 = 0, stt3d9 = 0, stt3d10 = 0, stt3d11 = 0, stt3d12 = 0,
                stt3d13 = 0, stt3d14 = 0, stt3d15 = 0, stt3d16 = 0, stt3d17 = 0, stt3d18 = 0, stt3d19 = 0, stt3d20 = 0, stt3d21 = 0, stt3d22 = 0, stt3d23 = 0,
                stt3d24 = 0, stt3d25 = 0, stt3d26 = 0, stt3d27 = 0, stt3d28 = 0, stt3d29 = 0, stt3d30 = 0, stt3d31 = 0;
            int stt4d1 = 0, stt4d2 = 0, stt4d3 = 0, stt4d4 = 0, stt4d5 = 0, stt4d6 = 0, stt4d7 = 0, stt4d8 = 0, stt4d9 = 0, stt4d10 = 0, stt4d11 = 0, stt4d12 = 0,
                stt4d13 = 0, stt4d14 = 0, stt4d15 = 0, stt4d16 = 0, stt4d17 = 0, stt4d18 = 0, stt4d19 = 0, stt4d20 = 0, stt4d21 = 0, stt4d22 = 0, stt4d23 = 0,
                stt4d24 = 0, stt4d25 = 0, stt4d26 = 0, stt4d27 = 0, stt4d28 = 0, stt4d29 = 0, stt4d30 = 0, stt4d31 = 0;
            int stt5d1 = 0, stt5d2 = 0, stt5d3 = 0, stt5d4 = 0, stt5d5 = 0, stt5d6 = 0, stt5d7 = 0, stt5d8 = 0, stt5d9 = 0, stt5d10 = 0, stt5d11 = 0, stt5d12 = 0,
                stt5d13 = 0, stt5d14 = 0, stt5d15 = 0, stt5d16 = 0, stt5d17 = 0, stt5d18 = 0, stt5d19 = 0, stt5d20 = 0, stt5d21 = 0, stt5d22 = 0, stt5d23 = 0,
                stt5d24 = 0, stt5d25 = 0, stt5d26 = 0, stt5d27 = 0, stt5d28 = 0, stt5d29 = 0, stt5d30 = 0, stt5d31 = 0;
            int stt6d1 = 0, stt6d2 = 0, stt6d3 = 0, stt6d4 = 0, stt6d5 = 0, stt6d6 = 0, stt6d7 = 0, stt6d8 = 0, stt6d9 = 0, stt6d10 = 0, stt6d11 = 0, stt6d12 = 0,
                stt6d13 = 0, stt6d14 = 0, stt6d15 = 0, stt6d16 = 0, stt6d17 = 0, stt6d18 = 0, stt6d19 = 0, stt6d20 = 0, stt6d21 = 0, stt6d22 = 0, stt6d23 = 0,
                stt6d24 = 0, stt6d25 = 0, stt6d26 = 0, stt6d27 = 0, stt6d28 = 0, stt6d29 = 0, stt6d30 = 0, stt6d31 = 0;
            int stt7d1 = 0, stt7d2 = 0, stt7d3 = 0, stt7d4 = 0, stt7d5 = 0, stt7d6 = 0, stt7d7 = 0, stt7d8 = 0, stt7d9 = 0, stt7d10 = 0, stt7d11 = 0, stt7d12 = 0,
                stt7d13 = 0, stt7d14 = 0, stt7d15 = 0, stt7d16 = 0, stt7d17 = 0, stt7d18 = 0, stt7d19 = 0, stt7d20 = 0, stt7d21 = 0, stt7d22 = 0, stt7d23 = 0,
                stt7d24 = 0, stt7d25 = 0, stt7d26 = 0, stt7d27 = 0, stt7d28 = 0, stt7d29 = 0, stt7d30 = 0, stt7d31 = 0;
            int stt8d1 = 0, stt8d2 = 0, stt8d3 = 0, stt8d4 = 0, stt8d5 = 0, stt8d6 = 0, stt8d7 = 0, stt8d8 = 0, stt8d9 = 0, stt8d10 = 0, stt8d11 = 0, stt8d12 = 0,
                stt8d13 = 0, stt8d14 = 0, stt8d15 = 0, stt8d16 = 0, stt8d17 = 0, stt8d18 = 0, stt8d19 = 0, stt8d20 = 0, stt8d21 = 0, stt8d22 = 0, stt8d23 = 0,
                stt8d24 = 0, stt8d25 = 0, stt8d26 = 0, stt8d27 = 0, stt8d28 = 0, stt8d29 = 0, stt8d30 = 0, stt8d31 = 0;
            foreach (var q in testDetailList)
            {
                if (q.CreateDate.Year == DateTime.Now.Year && q.CreateDate.Month == DateTime.Now.Month)
                {
                    switch (q.SubjectId)
                    {
                        case 1:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt1d1 += 1;
                                    break;
                                case 2:
                                    stt1d2 += 1;
                                    break;
                                case 3:
                                    stt1d3 += 1;
                                    break;
                                case 4:
                                    stt1d4 += 1;
                                    break;
                                case 5:
                                    stt1d5 += 1;
                                    break;
                                case 6:
                                    stt1d6 += 1;
                                    break;
                                case 7:
                                    stt1d7 += 1;
                                    break;
                                case 8:
                                    stt1d8 += 1;
                                    break;
                                case 9:
                                    stt1d9 += 1;
                                    break;
                                case 10:
                                    stt1d10 += 1;
                                    break;
                                case 11:
                                    stt1d11 += 1;
                                    break;
                                case 12:
                                    stt1d12 += 1;
                                    break;
                                case 13:
                                    stt1d13 += 1;
                                    break;
                                case 14:
                                    stt1d14 += 1;
                                    break;
                                case 15:
                                    stt1d15 += 1;
                                    break;
                                case 16:
                                    stt1d16 += 1;
                                    break;
                                case 17:
                                    stt1d17 += 1;
                                    break;
                                case 18:
                                    stt1d18 += 1;
                                    break;
                                case 19:
                                    stt1d19 += 1;
                                    break;
                                case 20:
                                    stt1d20 += 1;
                                    break;
                                case 21:
                                    stt1d21 += 1;
                                    break;
                                case 22:
                                    stt1d22 += 1;
                                    break;
                                case 23:
                                    stt1d23 += 1;
                                    break;
                                case 24:
                                    stt1d24 += 1;
                                    break;
                                case 25:
                                    stt1d25 += 1;
                                    break;
                                case 26:
                                    stt1d26 += 1;
                                    break;
                                case 27:
                                    stt1d27 += 1;
                                    break;
                                case 28:
                                    stt1d28 += 1;
                                    break;
                                case 29:
                                    stt1d29 += 1;
                                    break;
                                case 30:
                                    stt1d30 += 1;
                                    break;
                                case 31:
                                    stt1d31 += 1;
                                    break;
                            }
                            break;
                        case 2:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt2d1 += 1;
                                    break;
                                case 2:
                                    stt2d2 += 1;
                                    break;
                                case 3:
                                    stt2d3 += 1;
                                    break;
                                case 4:
                                    stt2d4 += 1;
                                    break;
                                case 5:
                                    stt2d5 += 1;
                                    break;
                                case 6:
                                    stt2d6 += 1;
                                    break;
                                case 7:
                                    stt2d7 += 1;
                                    break;
                                case 8:
                                    stt2d8 += 1;
                                    break;
                                case 9:
                                    stt2d9 += 1;
                                    break;
                                case 10:
                                    stt2d10 += 1;
                                    break;
                                case 11:
                                    stt2d11 += 1;
                                    break;
                                case 12:
                                    stt2d12 += 1;
                                    break;
                                case 13:
                                    stt2d13 += 1;
                                    break;
                                case 14:
                                    stt2d14 += 1;
                                    break;
                                case 15:
                                    stt2d15 += 1;
                                    break;
                                case 16:
                                    stt2d16 += 1;
                                    break;
                                case 17:
                                    stt2d17 += 1;
                                    break;
                                case 18:
                                    stt2d18 += 1;
                                    break;
                                case 19:
                                    stt2d19 += 1;
                                    break;
                                case 20:
                                    stt2d20 += 1;
                                    break;
                                case 21:
                                    stt2d21 += 1;
                                    break;
                                case 22:
                                    stt2d22 += 1;
                                    break;
                                case 23:
                                    stt2d23 += 1;
                                    break;
                                case 24:
                                    stt2d24 += 1;
                                    break;
                                case 25:
                                    stt2d25 += 1;
                                    break;
                                case 26:
                                    stt2d26 += 1;
                                    break;
                                case 27:
                                    stt2d27 += 1;
                                    break;
                                case 28:
                                    stt2d28 += 1;
                                    break;
                                case 29:
                                    stt2d29 += 1;
                                    break;
                                case 30:
                                    stt2d30 += 1;
                                    break;
                                case 31:
                                    stt2d31 += 1;
                                    break;
                            }
                            break;
                        case 3:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt3d1 += 1;
                                    break;
                                case 2:
                                    stt3d2 += 1;
                                    break;
                                case 3:
                                    stt3d3 += 1;
                                    break;
                                case 4:
                                    stt3d4 += 1;
                                    break;
                                case 5:
                                    stt3d5 += 1;
                                    break;
                                case 6:
                                    stt3d6 += 1;
                                    break;
                                case 7:
                                    stt3d7 += 1;
                                    break;
                                case 8:
                                    stt3d8 += 1;
                                    break;
                                case 9:
                                    stt3d9 += 1;
                                    break;
                                case 10:
                                    stt3d10 += 1;
                                    break;
                                case 11:
                                    stt3d11 += 1;
                                    break;
                                case 12:
                                    stt3d12 += 1;
                                    break;
                                case 13:
                                    stt3d13 += 1;
                                    break;
                                case 14:
                                    stt3d14 += 1;
                                    break;
                                case 15:
                                    stt3d15 += 1;
                                    break;
                                case 16:
                                    stt3d16 += 1;
                                    break;
                                case 17:
                                    stt3d17 += 1;
                                    break;
                                case 18:
                                    stt3d18 += 1;
                                    break;
                                case 19:
                                    stt3d19 += 1;
                                    break;
                                case 20:
                                    stt3d20 += 1;
                                    break;
                                case 21:
                                    stt3d21 += 1;
                                    break;
                                case 22:
                                    stt3d22 += 1;
                                    break;
                                case 23:
                                    stt3d23 += 1;
                                    break;
                                case 24:
                                    stt3d24 += 1;
                                    break;
                                case 25:
                                    stt3d25 += 1;
                                    break;
                                case 26:
                                    stt3d26 += 1;
                                    break;
                                case 27:
                                    stt3d27 += 1;
                                    break;
                                case 28:
                                    stt3d28 += 1;
                                    break;
                                case 29:
                                    stt3d29 += 1;
                                    break;
                                case 30:
                                    stt3d30 += 1;
                                    break;
                                case 31:
                                    stt3d31 += 1;
                                    break;
                            }
                            break;
                        case 4:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt4d1 += 1;
                                    break;
                                case 2:
                                    stt4d2 += 1;
                                    break;
                                case 3:
                                    stt4d3 += 1;
                                    break;
                                case 4:
                                    stt4d4 += 1;
                                    break;
                                case 5:
                                    stt4d5 += 1;
                                    break;
                                case 6:
                                    stt4d6 += 1;
                                    break;
                                case 7:
                                    stt4d7 += 1;
                                    break;
                                case 8:
                                    stt4d8 += 1;
                                    break;
                                case 9:
                                    stt4d9 += 1;
                                    break;
                                case 10:
                                    stt4d10 += 1;
                                    break;
                                case 11:
                                    stt4d11 += 1;
                                    break;
                                case 12:
                                    stt4d12 += 1;
                                    break;
                                case 13:
                                    stt4d13 += 1;
                                    break;
                                case 14:
                                    stt4d14 += 1;
                                    break;
                                case 15:
                                    stt4d15 += 1;
                                    break;
                                case 16:
                                    stt4d16 += 1;
                                    break;
                                case 17:
                                    stt4d17 += 1;
                                    break;
                                case 18:
                                    stt4d18 += 1;
                                    break;
                                case 19:
                                    stt4d19 += 1;
                                    break;
                                case 20:
                                    stt4d20 += 1;
                                    break;
                                case 21:
                                    stt4d21 += 1;
                                    break;
                                case 22:
                                    stt4d22 += 1;
                                    break;
                                case 23:
                                    stt4d23 += 1;
                                    break;
                                case 24:
                                    stt4d24 += 1;
                                    break;
                                case 25:
                                    stt4d25 += 1;
                                    break;
                                case 26:
                                    stt4d26 += 1;
                                    break;
                                case 27:
                                    stt4d27 += 1;
                                    break;
                                case 28:
                                    stt4d28 += 1;
                                    break;
                                case 29:
                                    stt4d29 += 1;
                                    break;
                                case 30:
                                    stt4d30 += 1;
                                    break;
                                case 31:
                                    stt4d31 += 1;
                                    break;
                            }
                            break;
                        case 5:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt5d1 += 1;
                                    break;
                                case 2:
                                    stt5d2 += 1;
                                    break;
                                case 3:
                                    stt5d3 += 1;
                                    break;
                                case 4:
                                    stt5d4 += 1;
                                    break;
                                case 5:
                                    stt5d5 += 1;
                                    break;
                                case 6:
                                    stt5d6 += 1;
                                    break;
                                case 7:
                                    stt5d7 += 1;
                                    break;
                                case 8:
                                    stt5d8 += 1;
                                    break;
                                case 9:
                                    stt5d9 += 1;
                                    break;
                                case 10:
                                    stt5d10 += 1;
                                    break;
                                case 11:
                                    stt5d11 += 1;
                                    break;
                                case 12:
                                    stt5d12 += 1;
                                    break;
                                case 13:
                                    stt5d13 += 1;
                                    break;
                                case 14:
                                    stt5d14 += 1;
                                    break;
                                case 15:
                                    stt5d15 += 1;
                                    break;
                                case 16:
                                    stt5d16 += 1;
                                    break;
                                case 17:
                                    stt5d17 += 1;
                                    break;
                                case 18:
                                    stt5d18 += 1;
                                    break;
                                case 19:
                                    stt5d19 += 1;
                                    break;
                                case 20:
                                    stt5d20 += 1;
                                    break;
                                case 21:
                                    stt5d21 += 1;
                                    break;
                                case 22:
                                    stt5d22 += 1;
                                    break;
                                case 23:
                                    stt5d23 += 1;
                                    break;
                                case 24:
                                    stt5d24 += 1;
                                    break;
                                case 25:
                                    stt5d25 += 1;
                                    break;
                                case 26:
                                    stt5d26 += 1;
                                    break;
                                case 27:
                                    stt5d27 += 1;
                                    break;
                                case 28:
                                    stt5d28 += 1;
                                    break;
                                case 29:
                                    stt5d29 += 1;
                                    break;
                                case 30:
                                    stt5d30 += 1;
                                    break;
                                case 31:
                                    stt5d31 += 1;
                                    break;
                            }
                            break;
                        case 6:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt6d1 += 1;
                                    break;
                                case 2:
                                    stt6d2 += 1;
                                    break;
                                case 3:
                                    stt6d3 += 1;
                                    break;
                                case 4:
                                    stt6d4 += 1;
                                    break;
                                case 5:
                                    stt6d5 += 1;
                                    break;
                                case 6:
                                    stt6d6 += 1;
                                    break;
                                case 7:
                                    stt6d7 += 1;
                                    break;
                                case 8:
                                    stt6d8 += 1;
                                    break;
                                case 9:
                                    stt6d9 += 1;
                                    break;
                                case 10:
                                    stt6d10 += 1;
                                    break;
                                case 11:
                                    stt6d11 += 1;
                                    break;
                                case 12:
                                    stt6d12 += 1;
                                    break;
                                case 13:
                                    stt6d13 += 1;
                                    break;
                                case 14:
                                    stt6d14 += 1;
                                    break;
                                case 15:
                                    stt6d15 += 1;
                                    break;
                                case 16:
                                    stt6d16 += 1;
                                    break;
                                case 17:
                                    stt6d17 += 1;
                                    break;
                                case 18:
                                    stt6d18 += 1;
                                    break;
                                case 19:
                                    stt6d19 += 1;
                                    break;
                                case 20:
                                    stt6d20 += 1;
                                    break;
                                case 21:
                                    stt6d21 += 1;
                                    break;
                                case 22:
                                    stt6d22 += 1;
                                    break;
                                case 23:
                                    stt6d23 += 1;
                                    break;
                                case 24:
                                    stt6d24 += 1;
                                    break;
                                case 25:
                                    stt6d25 += 1;
                                    break;
                                case 26:
                                    stt6d26 += 1;
                                    break;
                                case 27:
                                    stt6d27 += 1;
                                    break;
                                case 28:
                                    stt6d28 += 1;
                                    break;
                                case 29:
                                    stt6d29 += 1;
                                    break;
                                case 30:
                                    stt6d30 += 1;
                                    break;
                                case 31:
                                    stt6d31 += 1;
                                    break;
                            }
                            break;
                        case 7:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt7d1 += 1;
                                    break;
                                case 2:
                                    stt7d2 += 1;
                                    break;
                                case 3:
                                    stt7d3 += 1;
                                    break;
                                case 4:
                                    stt7d4 += 1;
                                    break;
                                case 5:
                                    stt7d5 += 1;
                                    break;
                                case 6:
                                    stt7d6 += 1;
                                    break;
                                case 7:
                                    stt7d7 += 1;
                                    break;
                                case 8:
                                    stt7d8 += 1;
                                    break;
                                case 9:
                                    stt7d9 += 1;
                                    break;
                                case 10:
                                    stt7d10 += 1;
                                    break;
                                case 11:
                                    stt7d11 += 1;
                                    break;
                                case 12:
                                    stt7d12 += 1;
                                    break;
                                case 13:
                                    stt7d13 += 1;
                                    break;
                                case 14:
                                    stt7d14 += 1;
                                    break;
                                case 15:
                                    stt7d15 += 1;
                                    break;
                                case 16:
                                    stt7d16 += 1;
                                    break;
                                case 17:
                                    stt7d17 += 1;
                                    break;
                                case 18:
                                    stt7d18 += 1;
                                    break;
                                case 19:
                                    stt7d19 += 1;
                                    break;
                                case 20:
                                    stt7d20 += 1;
                                    break;
                                case 21:
                                    stt7d21 += 1;
                                    break;
                                case 22:
                                    stt7d22 += 1;
                                    break;
                                case 23:
                                    stt7d23 += 1;
                                    break;
                                case 24:
                                    stt7d24 += 1;
                                    break;
                                case 25:
                                    stt7d25 += 1;
                                    break;
                                case 26:
                                    stt7d26 += 1;
                                    break;
                                case 27:
                                    stt7d27 += 1;
                                    break;
                                case 28:
                                    stt7d28 += 1;
                                    break;
                                case 29:
                                    stt7d29 += 1;
                                    break;
                                case 30:
                                    stt7d30 += 1;
                                    break;
                                case 31:
                                    stt7d31 += 1;
                                    break;
                            }
                            break;
                        case 8:
                            switch (q.CreateDate.Day)
                            {
                                case 1:
                                    stt8d1 += 1;
                                    break;
                                case 2:
                                    stt8d2 += 1;
                                    break;
                                case 3:
                                    stt8d3 += 1;
                                    break;
                                case 4:
                                    stt8d4 += 1;
                                    break;
                                case 5:
                                    stt8d5 += 1;
                                    break;
                                case 6:
                                    stt8d6 += 1;
                                    break;
                                case 7:
                                    stt8d7 += 1;
                                    break;
                                case 8:
                                    stt8d8 += 1;
                                    break;
                                case 9:
                                    stt8d9 += 1;
                                    break;
                                case 10:
                                    stt8d10 += 1;
                                    break;
                                case 11:
                                    stt8d11 += 1;
                                    break;
                                case 12:
                                    stt8d12 += 1;
                                    break;
                                case 13:
                                    stt8d13 += 1;
                                    break;
                                case 14:
                                    stt8d14 += 1;
                                    break;
                                case 15:
                                    stt8d15 += 1;
                                    break;
                                case 16:
                                    stt8d16 += 1;
                                    break;
                                case 17:
                                    stt8d17 += 1;
                                    break;
                                case 18:
                                    stt8d18 += 1;
                                    break;
                                case 19:
                                    stt8d19 += 1;
                                    break;
                                case 20:
                                    stt8d20 += 1;
                                    break;
                                case 21:
                                    stt8d21 += 1;
                                    break;
                                case 22:
                                    stt8d22 += 1;
                                    break;
                                case 23:
                                    stt8d23 += 1;
                                    break;
                                case 24:
                                    stt8d24 += 1;
                                    break;
                                case 25:
                                    stt8d25 += 1;
                                    break;
                                case 26:
                                    stt8d26 += 1;
                                    break;
                                case 27:
                                    stt8d27 += 1;
                                    break;
                                case 28:
                                    stt8d28 += 1;
                                    break;
                                case 29:
                                    stt8d29 += 1;
                                    break;
                                case 30:
                                    stt8d30 += 1;
                                    break;
                                case 31:
                                    stt8d31 += 1;
                                    break;
                            }
                            break;
                    }
                }
            }
            ViewBag.stt1d1 = stt1d1;
            ViewBag.stt1d2 = stt1d2;
            ViewBag.stt1d3 = stt1d3;
            ViewBag.stt1d4 = stt1d4;
            ViewBag.stt1d5 = stt1d5;
            ViewBag.stt1d6 = stt1d6;
            ViewBag.stt1d7 = stt1d7;
            ViewBag.stt1d8 = stt1d8;
            ViewBag.stt1d9 = stt1d9;
            ViewBag.stt1d10 = stt1d10;
            ViewBag.stt1d11 = stt1d11;
            ViewBag.stt1d12 = stt1d12;
            ViewBag.stt1d13 = stt1d13;
            ViewBag.stt1d14 = stt1d14;
            ViewBag.stt1d15 = stt1d15;
            ViewBag.stt1d16 = stt1d16;
            ViewBag.stt1d17 = stt1d17;
            ViewBag.stt1d18 = stt1d18;
            ViewBag.stt1d19 = stt1d19;
            ViewBag.stt1d20 = stt1d20;
            ViewBag.stt1d21 = stt1d21;
            ViewBag.stt1d22 = stt1d22;
            ViewBag.stt1d23 = stt1d23;
            ViewBag.stt1d24 = stt1d24;
            ViewBag.stt1d25 = stt1d25;
            ViewBag.stt1d26 = stt1d26;
            ViewBag.stt1d27 = stt1d27;
            ViewBag.stt1d28 = stt1d28;
            ViewBag.stt1d29 = stt1d29;
            ViewBag.stt1d30 = stt1d30;
            ViewBag.stt1d31 = stt1d31;
            ViewBag.stt2d1 = stt2d1;
            ViewBag.stt2d2 = stt2d2;
            ViewBag.stt2d3 = stt2d3;
            ViewBag.stt2d4 = stt2d4;
            ViewBag.stt2d5 = stt2d5;
            ViewBag.stt2d6 = stt2d6;
            ViewBag.stt2d7 = stt2d7;
            ViewBag.stt2d8 = stt2d8;
            ViewBag.stt2d9 = stt2d9;
            ViewBag.stt2d10 = stt2d10;
            ViewBag.stt2d11 = stt2d11;
            ViewBag.stt2d12 = stt2d12;
            ViewBag.stt2d13 = stt2d13;
            ViewBag.stt2d14 = stt2d14;
            ViewBag.stt2d15 = stt2d15;
            ViewBag.stt2d16 = stt2d16;
            ViewBag.stt2d17 = stt2d17;
            ViewBag.stt2d18 = stt2d18;
            ViewBag.stt2d19 = stt2d19;
            ViewBag.stt2d20 = stt2d20;
            ViewBag.stt2d21 = stt2d21;
            ViewBag.stt2d22 = stt2d22;
            ViewBag.stt2d23 = stt2d23;
            ViewBag.stt2d24 = stt2d24;
            ViewBag.stt2d25 = stt2d25;
            ViewBag.stt2d26 = stt2d26;
            ViewBag.stt2d27 = stt2d27;
            ViewBag.stt2d28 = stt2d28;
            ViewBag.stt2d29 = stt2d29;
            ViewBag.stt2d30 = stt2d30;
            ViewBag.stt2d31 = stt2d31;
            ViewBag.stt3d1 = stt3d1;
            ViewBag.stt3d2 = stt3d2;
            ViewBag.stt3d3 = stt3d3;
            ViewBag.stt3d4 = stt3d4;
            ViewBag.stt3d5 = stt3d5;
            ViewBag.stt3d6 = stt3d6;
            ViewBag.stt3d7 = stt3d7;
            ViewBag.stt3d8 = stt3d8;
            ViewBag.stt3d9 = stt3d9;
            ViewBag.stt3d10 = stt3d10;
            ViewBag.stt3d11 = stt3d11;
            ViewBag.stt3d12 = stt3d12;
            ViewBag.stt3d13 = stt3d13;
            ViewBag.stt3d14 = stt3d14;
            ViewBag.stt3d15 = stt3d15;
            ViewBag.stt3d16 = stt3d16;
            ViewBag.stt3d17 = stt3d17;
            ViewBag.stt3d18 = stt3d18;
            ViewBag.stt3d19 = stt3d19;
            ViewBag.stt3d20 = stt3d20;
            ViewBag.stt3d21 = stt3d21;
            ViewBag.stt3d22 = stt3d22;
            ViewBag.stt3d23 = stt3d23;
            ViewBag.stt3d24 = stt3d24;
            ViewBag.stt3d25 = stt3d25;
            ViewBag.stt3d26 = stt3d26;
            ViewBag.stt3d27 = stt3d27;
            ViewBag.stt3d28 = stt3d28;
            ViewBag.stt3d29 = stt3d29;
            ViewBag.stt3d30 = stt3d30;
            ViewBag.stt3d31 = stt3d31;
            ViewBag.stt4d1 = stt4d1;
            ViewBag.stt4d2 = stt4d2;
            ViewBag.stt4d3 = stt4d3;
            ViewBag.stt4d4 = stt4d4;
            ViewBag.stt4d5 = stt4d5;
            ViewBag.stt4d6 = stt4d6;
            ViewBag.stt4d7 = stt4d7;
            ViewBag.stt4d8 = stt4d8;
            ViewBag.stt4d9 = stt4d9;
            ViewBag.stt4d10 = stt4d10;
            ViewBag.stt4d11 = stt4d11;
            ViewBag.stt4d12 = stt4d12;
            ViewBag.stt4d13 = stt4d13;
            ViewBag.stt4d14 = stt4d14;
            ViewBag.stt4d15 = stt4d15;
            ViewBag.stt4d16 = stt4d16;
            ViewBag.stt4d17 = stt4d17;
            ViewBag.stt4d18 = stt4d18;
            ViewBag.stt4d19 = stt4d19;
            ViewBag.stt4d20 = stt4d20;
            ViewBag.stt4d21 = stt4d21;
            ViewBag.stt4d22 = stt4d22;
            ViewBag.stt4d23 = stt4d23;
            ViewBag.stt4d24 = stt4d24;
            ViewBag.stt4d25 = stt4d25;
            ViewBag.stt4d26 = stt4d26;
            ViewBag.stt4d27 = stt4d27;
            ViewBag.stt4d28 = stt4d28;
            ViewBag.stt4d29 = stt4d29;
            ViewBag.stt4d30 = stt4d30;
            ViewBag.stt4d31 = stt4d31;
            ViewBag.stt5d1 = stt5d1;
            ViewBag.stt5d2 = stt5d2;
            ViewBag.stt5d3 = stt5d3;
            ViewBag.stt5d4 = stt5d4;
            ViewBag.stt5d5 = stt5d5;
            ViewBag.stt5d6 = stt5d6;
            ViewBag.stt5d7 = stt5d7;
            ViewBag.stt5d8 = stt5d8;
            ViewBag.stt5d9 = stt5d9;
            ViewBag.stt5d10 = stt5d10;
            ViewBag.stt5d11 = stt5d11;
            ViewBag.stt5d12 = stt5d12;
            ViewBag.stt5d13 = stt5d13;
            ViewBag.stt5d14 = stt5d14;
            ViewBag.stt5d15 = stt5d15;
            ViewBag.stt5d16 = stt5d16;
            ViewBag.stt5d17 = stt5d17;
            ViewBag.stt5d18 = stt5d18;
            ViewBag.stt5d19 = stt5d19;
            ViewBag.stt5d20 = stt5d20;
            ViewBag.stt5d21 = stt5d21;
            ViewBag.stt5d22 = stt5d22;
            ViewBag.stt5d23 = stt5d23;
            ViewBag.stt5d24 = stt5d24;
            ViewBag.stt5d25 = stt5d25;
            ViewBag.stt5d26 = stt5d26;
            ViewBag.stt5d27 = stt5d27;
            ViewBag.stt5d28 = stt5d28;
            ViewBag.stt5d29 = stt5d29;
            ViewBag.stt5d30 = stt5d30;
            ViewBag.stt5d31 = stt5d31;
            ViewBag.stt6d1 = stt6d1;
            ViewBag.stt6d2 = stt6d2;
            ViewBag.stt6d3 = stt6d3;
            ViewBag.stt6d4 = stt6d4;
            ViewBag.stt6d5 = stt6d5;
            ViewBag.stt6d6 = stt6d6;
            ViewBag.stt6d7 = stt6d7;
            ViewBag.stt6d8 = stt6d8;
            ViewBag.stt6d9 = stt6d9;
            ViewBag.stt6d10 = stt6d10;
            ViewBag.stt6d11 = stt6d11;
            ViewBag.stt6d12 = stt6d12;
            ViewBag.stt6d13 = stt6d13;
            ViewBag.stt6d14 = stt6d14;
            ViewBag.stt6d15 = stt6d15;
            ViewBag.stt6d16 = stt6d16;
            ViewBag.stt6d17 = stt6d17;
            ViewBag.stt6d18 = stt6d18;
            ViewBag.stt6d19 = stt6d19;
            ViewBag.stt6d20 = stt6d20;
            ViewBag.stt6d21 = stt6d21;
            ViewBag.stt6d22 = stt6d22;
            ViewBag.stt6d23 = stt6d23;
            ViewBag.stt6d24 = stt6d24;
            ViewBag.stt6d25 = stt6d25;
            ViewBag.stt6d26 = stt6d26;
            ViewBag.stt6d27 = stt6d27;
            ViewBag.stt6d28 = stt6d28;
            ViewBag.stt6d29 = stt6d29;
            ViewBag.stt6d30 = stt6d30;
            ViewBag.stt6d31 = stt6d31;
            ViewBag.stt7d1 = stt7d1;
            ViewBag.stt7d2 = stt7d2;
            ViewBag.stt7d3 = stt7d3;
            ViewBag.stt7d4 = stt7d4;
            ViewBag.stt7d5 = stt7d5;
            ViewBag.stt7d6 = stt7d6;
            ViewBag.stt7d7 = stt7d7;
            ViewBag.stt7d8 = stt7d8;
            ViewBag.stt7d9 = stt7d9;
            ViewBag.stt7d10 = stt7d10;
            ViewBag.stt7d11 = stt7d11;
            ViewBag.stt7d12 = stt7d12;
            ViewBag.stt7d13 = stt7d13;
            ViewBag.stt7d14 = stt7d14;
            ViewBag.stt7d15 = stt7d15;
            ViewBag.stt7d16 = stt7d16;
            ViewBag.stt7d17 = stt7d17;
            ViewBag.stt7d18 = stt7d18;
            ViewBag.stt7d19 = stt7d19;
            ViewBag.stt7d20 = stt7d20;
            ViewBag.stt7d21 = stt7d21;
            ViewBag.stt7d22 = stt7d22;
            ViewBag.stt7d23 = stt7d23;
            ViewBag.stt7d24 = stt7d24;
            ViewBag.stt7d25 = stt7d25;
            ViewBag.stt7d26 = stt7d26;
            ViewBag.stt7d27 = stt7d27;
            ViewBag.stt7d28 = stt7d28;
            ViewBag.stt7d29 = stt7d29;
            ViewBag.stt7d30 = stt7d30;
            ViewBag.stt7d31 = stt7d31;
            ViewBag.stt8d1 = stt8d1;
            ViewBag.stt8d2 = stt8d2;
            ViewBag.stt8d3 = stt8d3;
            ViewBag.stt8d4 = stt8d4;
            ViewBag.stt8d5 = stt8d5;
            ViewBag.stt8d6 = stt8d6;
            ViewBag.stt8d7 = stt8d7;
            ViewBag.stt8d8 = stt8d8;
            ViewBag.stt8d9 = stt8d9;
            ViewBag.stt8d10 = stt8d10;
            ViewBag.stt8d11 = stt8d11;
            ViewBag.stt8d12 = stt8d12;
            ViewBag.stt8d13 = stt8d13;
            ViewBag.stt8d14 = stt8d14;
            ViewBag.stt8d15 = stt8d15;
            ViewBag.stt8d16 = stt8d16;
            ViewBag.stt8d17 = stt8d17;
            ViewBag.stt8d18 = stt8d18;
            ViewBag.stt8d19 = stt8d19;
            ViewBag.stt8d20 = stt8d20;
            ViewBag.stt8d21 = stt8d21;
            ViewBag.stt8d22 = stt8d22;
            ViewBag.stt8d23 = stt8d23;
            ViewBag.stt8d24 = stt8d24;
            ViewBag.stt8d25 = stt8d25;
            ViewBag.stt8d26 = stt8d26;
            ViewBag.stt8d27 = stt8d27;
            ViewBag.stt8d28 = stt8d28;
            ViewBag.stt8d29 = stt8d29;
            ViewBag.stt8d30 = stt8d30;
            ViewBag.stt8d31 = stt8d31;
            //Count Test by Subject Per Month
            int stt1 = 0, stt2 = 0, stt3 = 0, stt4 = 0, stt5 = 0, stt6 = 0, stt7 = 0, stt8 = 0;
            int stt1m1 = 0, stt1m2 = 0, stt1m3 = 0, stt1m4 = 0, stt1m5 = 0, stt1m6 = 0, stt1m7 = 0, stt1m8 = 0, stt1m9 = 0, stt1m10 = 0, stt1m11 = 0, stt1m12 = 0;
            int stt2m1 = 0, stt2m2 = 0, stt2m3 = 0, stt2m4 = 0, stt2m5 = 0, stt2m6 = 0, stt2m7 = 0, stt2m8 = 0, stt2m9 = 0, stt2m10 = 0, stt2m11 = 0, stt2m12 = 0;
            int stt3m1 = 0, stt3m2 = 0, stt3m3 = 0, stt3m4 = 0, stt3m5 = 0, stt3m6 = 0, stt3m7 = 0, stt3m8 = 0, stt3m9 = 0, stt3m10 = 0, stt3m11 = 0, stt3m12 = 0;
            int stt4m1 = 0, stt4m2 = 0, stt4m3 = 0, stt4m4 = 0, stt4m5 = 0, stt4m6 = 0, stt4m7 = 0, stt4m8 = 0, stt4m9 = 0, stt4m10 = 0, stt4m11 = 0, stt4m12 = 0;
            int stt5m1 = 0, stt5m2 = 0, stt5m3 = 0, stt5m4 = 0, stt5m5 = 0, stt5m6 = 0, stt5m7 = 0, stt5m8 = 0, stt5m9 = 0, stt5m10 = 0, stt5m11 = 0, stt5m12 = 0;
            int stt6m1 = 0, stt6m2 = 0, stt6m3 = 0, stt6m4 = 0, stt6m5 = 0, stt6m6 = 0, stt6m7 = 0, stt6m8 = 0, stt6m9 = 0, stt6m10 = 0, stt6m11 = 0, stt6m12 = 0;
            int stt7m1 = 0, stt7m2 = 0, stt7m3 = 0, stt7m4 = 0, stt7m5 = 0, stt7m6 = 0, stt7m7 = 0, stt7m8 = 0, stt7m9 = 0, stt7m10 = 0, stt7m11 = 0, stt7m12 = 0;
            int stt8m1 = 0, stt8m2 = 0, stt8m3 = 0, stt8m4 = 0, stt8m5 = 0, stt8m6 = 0, stt8m7 = 0, stt8m8 = 0, stt8m9 = 0, stt8m10 = 0, stt8m11 = 0, stt8m12 = 0;
            foreach (var q in testDetailList)
            {
                if (q.CreateDate.Year == DateTime.Now.Year)
                {
                    switch (q.SubjectId)
                    {
                        case 1:
                            stt1 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt1m1 += 1;
                                    break;
                                case 2:
                                    stt1m2 += 1;
                                    break;
                                case 3:
                                    stt1m3 += 1;
                                    break;
                                case 4:
                                    stt1m4 += 1;
                                    break;
                                case 5:
                                    stt1m5 += 1;
                                    break;
                                case 6:
                                    stt1m6 += 1;
                                    break;
                                case 7:
                                    stt1m7 += 1;
                                    break;
                                case 8:
                                    stt1m8 += 1;
                                    break;
                                case 9:
                                    stt1m9 += 1;
                                    break;
                                case 10:
                                    stt1m10 += 1;
                                    break;
                                case 11:
                                    stt1m11 += 1;
                                    break;
                                case 12:
                                    stt1m12 += 1;
                                    break;
                            }
                            break;
                        case 2:
                            stt2 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt2m1 += 1;
                                    break;
                                case 2:
                                    stt2m2 += 1;
                                    break;
                                case 3:
                                    stt2m3 += 1;
                                    break;
                                case 4:
                                    stt2m4 += 1;
                                    break;
                                case 5:
                                    stt2m5 += 1;
                                    break;
                                case 6:
                                    stt2m6 += 1;
                                    break;
                                case 7:
                                    stt2m7 += 1;
                                    break;
                                case 8:
                                    stt2m8 += 1;
                                    break;
                                case 9:
                                    stt2m9 += 1;
                                    break;
                                case 10:
                                    stt2m10 += 1;
                                    break;
                                case 11:
                                    stt2m11 += 1;
                                    break;
                                case 12:
                                    stt2m12 += 1;
                                    break;
                            }
                            break;
                        case 3:
                            stt3 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt3m1 += 1;
                                    break;
                                case 2:
                                    stt3m2 += 1;
                                    break;
                                case 3:
                                    stt3m3 += 1;
                                    break;
                                case 4:
                                    stt3m4 += 1;
                                    break;
                                case 5:
                                    stt3m5 += 1;
                                    break;
                                case 6:
                                    stt3m6 += 1;
                                    break;
                                case 7:
                                    stt3m7 += 1;
                                    break;
                                case 8:
                                    stt3m8 += 1;
                                    break;
                                case 9:
                                    stt3m9 += 1;
                                    break;
                                case 10:
                                    stt3m10 += 1;
                                    break;
                                case 11:
                                    stt3m11 += 1;
                                    break;
                                case 12:
                                    stt3m12 += 1;
                                    break;
                            }
                            break;
                        case 4:
                            stt4 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt4m1 += 1;
                                    break;
                                case 2:
                                    stt4m2 += 1;
                                    break;
                                case 3:
                                    stt4m3 += 1;
                                    break;
                                case 4:
                                    stt4m4 += 1;
                                    break;
                                case 5:
                                    stt4m5 += 1;
                                    break;
                                case 6:
                                    stt4m6 += 1;
                                    break;
                                case 7:
                                    stt4m7 += 1;
                                    break;
                                case 8:
                                    stt4m8 += 1;
                                    break;
                                case 9:
                                    stt4m9 += 1;
                                    break;
                                case 10:
                                    stt4m10 += 1;
                                    break;
                                case 11:
                                    stt4m11 += 1;
                                    break;
                                case 12:
                                    stt4m12 += 1;
                                    break;
                            }
                            break;
                        case 5:
                            stt5 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt5m1 += 1;
                                    break;
                                case 2:
                                    stt5m2 += 1;
                                    break;
                                case 3:
                                    stt5m3 += 1;
                                    break;
                                case 4:
                                    stt5m4 += 1;
                                    break;
                                case 5:
                                    stt5m5 += 1;
                                    break;
                                case 6:
                                    stt5m6 += 1;
                                    break;
                                case 7:
                                    stt5m7 += 1;
                                    break;
                                case 8:
                                    stt5m8 += 1;
                                    break;
                                case 9:
                                    stt5m9 += 1;
                                    break;
                                case 10:
                                    stt5m10 += 1;
                                    break;
                                case 11:
                                    stt5m11 += 1;
                                    break;
                                case 12:
                                    stt5m12 += 1;
                                    break;
                            }
                            break;
                        case 6:
                            stt6 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt6m1 += 1;
                                    break;
                                case 2:
                                    stt6m2 += 1;
                                    break;
                                case 3:
                                    stt6m3 += 1;
                                    break;
                                case 4:
                                    stt6m4 += 1;
                                    break;
                                case 5:
                                    stt6m5 += 1;
                                    break;
                                case 6:
                                    stt6m6 += 1;
                                    break;
                                case 7:
                                    stt6m7 += 1;
                                    break;
                                case 8:
                                    stt6m8 += 1;
                                    break;
                                case 9:
                                    stt6m9 += 1;
                                    break;
                                case 10:
                                    stt6m10 += 1;
                                    break;
                                case 11:
                                    stt6m11 += 1;
                                    break;
                                case 12:
                                    stt6m12 += 1;
                                    break;
                            }
                            break;
                        case 7:
                            stt7 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt7m1 += 1;
                                    break;
                                case 2:
                                    stt7m2 += 1;
                                    break;
                                case 3:
                                    stt7m3 += 1;
                                    break;
                                case 4:
                                    stt7m4 += 1;
                                    break;
                                case 5:
                                    stt7m5 += 1;
                                    break;
                                case 6:
                                    stt7m6 += 1;
                                    break;
                                case 7:
                                    stt7m7 += 1;
                                    break;
                                case 8:
                                    stt7m8 += 1;
                                    break;
                                case 9:
                                    stt7m9 += 1;
                                    break;
                                case 10:
                                    stt7m10 += 1;
                                    break;
                                case 11:
                                    stt7m11 += 1;
                                    break;
                                case 12:
                                    stt7m12 += 1;
                                    break;
                            }
                            break;
                        case 8:
                            stt8 += 1;
                            switch (q.CreateDate.Month)
                            {
                                case 1:
                                    stt8m1 += 1;
                                    break;
                                case 2:
                                    stt8m2 += 1;
                                    break;
                                case 3:
                                    stt8m3 += 1;
                                    break;
                                case 4:
                                    stt8m4 += 1;
                                    break;
                                case 5:
                                    stt8m5 += 1;
                                    break;
                                case 6:
                                    stt8m6 += 1;
                                    break;
                                case 7:
                                    stt8m7 += 1;
                                    break;
                                case 8:
                                    stt8m8 += 1;
                                    break;
                                case 9:
                                    stt8m9 += 1;
                                    break;
                                case 10:
                                    stt8m10 += 1;
                                    break;
                                case 11:
                                    stt8m11 += 1;
                                    break;
                                case 12:
                                    stt8m12 += 1;
                                    break;
                            }
                            break;
                    }
                }
            }
            ViewBag.stt1 = stt1;
            ViewBag.stt2 = stt2;
            ViewBag.stt3 = stt3;
            ViewBag.stt4 = stt4;
            ViewBag.stt5 = stt5;
            ViewBag.stt6 = stt6;
            ViewBag.stt7 = stt7;
            ViewBag.stt8 = stt8;
            ViewBag.stt1m1 = stt1m1;
            ViewBag.stt1m2 = stt1m2;
            ViewBag.stt1m3 = stt1m3;
            ViewBag.stt1m4 = stt1m4;
            ViewBag.stt1m5 = stt1m5;
            ViewBag.stt1m6 = stt1m6;
            ViewBag.stt1m7 = stt1m7;
            ViewBag.stt1m8 = stt1m8;
            ViewBag.stt1m9 = stt1m9;
            ViewBag.stt1m10 = stt1m10;
            ViewBag.stt1m11 = stt1m11;
            ViewBag.stt1m12 = stt1m12;
            ViewBag.stt2m1 = stt2m1;
            ViewBag.stt2m2 = stt2m2;
            ViewBag.stt2m3 = stt2m3;
            ViewBag.stt2m4 = stt2m4;
            ViewBag.stt2m5 = stt2m5;
            ViewBag.stt2m6 = stt2m6;
            ViewBag.stt2m7 = stt2m7;
            ViewBag.stt2m8 = stt2m8;
            ViewBag.stt2m9 = stt2m9;
            ViewBag.stt2m10 = stt2m10;
            ViewBag.stt2m11 = stt2m11;
            ViewBag.stt2m12 = stt2m12;
            ViewBag.stt3m1 = stt3m1;
            ViewBag.stt3m2 = stt3m2;
            ViewBag.stt3m3 = stt3m3;
            ViewBag.stt3m4 = stt3m4;
            ViewBag.stt3m5 = stt3m5;
            ViewBag.stt3m6 = stt3m6;
            ViewBag.stt3m7 = stt3m7;
            ViewBag.stt3m8 = stt3m8;
            ViewBag.stt3m9 = stt3m9;
            ViewBag.stt3m10 = stt3m10;
            ViewBag.stt3m11 = stt3m11;
            ViewBag.stt3m12 = stt3m12;
            ViewBag.stt4m1 = stt4m1;
            ViewBag.stt4m2 = stt4m2;
            ViewBag.stt4m3 = stt4m3;
            ViewBag.stt4m4 = stt4m4;
            ViewBag.stt4m5 = stt4m5;
            ViewBag.stt4m6 = stt4m6;
            ViewBag.stt4m7 = stt4m7;
            ViewBag.stt4m8 = stt4m8;
            ViewBag.stt4m9 = stt4m9;
            ViewBag.stt4m10 = stt4m10;
            ViewBag.stt4m11 = stt4m11;
            ViewBag.stt4m12 = stt4m12;
            ViewBag.stt5m1 = stt5m1;
            ViewBag.stt5m2 = stt5m2;
            ViewBag.stt5m3 = stt5m3;
            ViewBag.stt5m4 = stt5m4;
            ViewBag.stt5m5 = stt5m5;
            ViewBag.stt5m6 = stt5m6;
            ViewBag.stt5m7 = stt5m7;
            ViewBag.stt5m8 = stt5m8;
            ViewBag.stt5m9 = stt5m9;
            ViewBag.stt5m10 = stt5m10;
            ViewBag.stt5m11 = stt5m11;
            ViewBag.stt5m12 = stt5m12;
            ViewBag.stt6m1 = stt6m1;
            ViewBag.stt6m2 = stt6m2;
            ViewBag.stt6m3 = stt6m3;
            ViewBag.stt6m4 = stt6m4;
            ViewBag.stt6m5 = stt6m5;
            ViewBag.stt6m6 = stt6m6;
            ViewBag.stt6m7 = stt6m7;
            ViewBag.stt6m8 = stt6m8;
            ViewBag.stt6m9 = stt6m9;
            ViewBag.stt6m10 = stt6m10;
            ViewBag.stt6m11 = stt6m11;
            ViewBag.stt6m12 = stt6m12;
            ViewBag.stt7m1 = stt7m1;
            ViewBag.stt7m2 = stt7m2;
            ViewBag.stt7m3 = stt7m3;
            ViewBag.stt7m4 = stt7m4;
            ViewBag.stt7m5 = stt7m5;
            ViewBag.stt7m6 = stt7m6;
            ViewBag.stt7m7 = stt7m7;
            ViewBag.stt7m8 = stt7m8;
            ViewBag.stt7m9 = stt7m9;
            ViewBag.stt7m10 = stt7m10;
            ViewBag.stt7m11 = stt7m11;
            ViewBag.stt7m12 = stt7m12;
            ViewBag.stt8m1 = stt8m1;
            ViewBag.stt8m2 = stt8m2;
            ViewBag.stt8m3 = stt8m3;
            ViewBag.stt8m4 = stt8m4;
            ViewBag.stt8m5 = stt8m5;
            ViewBag.stt8m6 = stt8m6;
            ViewBag.stt8m7 = stt8m7;
            ViewBag.stt8m8 = stt8m8;
            ViewBag.stt8m9 = stt8m9;
            ViewBag.stt8m10 = stt8m10;
            ViewBag.stt8m11 = stt8m11;
            ViewBag.stt8m12 = stt8m12;
            //Count Member From Each School
            /*int mc1 = 0, mc2 = 0, mc3 = 0, mc4 = 0;
            int mc1m1 = 0, mc1m2 = 0, mc1m3 = 0, mc1m4 = 0, mc1m5 = 0, mc1m6 = 0, mc1m7 = 0, mc1m8 = 0, mc1m9 = 0, mc1m10 = 0, mc1m11 = 0, mc1m12 = 0;
            int mc2m1 = 0, mc2m2 = 0, mc2m3 = 0, mc2m4 = 0, mc2m5 = 0, mc2m6 = 0, mc2m7 = 0, mc2m8 = 0, mc2m9 = 0, mc2m10 = 0, mc2m11 = 0, mc2m12 = 0;
            int mc3m1 = 0, mc3m2 = 0, mc3m3 = 0, mc3m4 = 0, mc3m5 = 0, mc3m6 = 0, mc3m7 = 0, mc3m8 = 0, mc3m9 = 0, mc3m10 = 0, mc3m11 = 0, mc3m12 = 0;
            int mc4m1 = 0, mc4m2 = 0, mc4m3 = 0, mc4m4 = 0, mc4m5 = 0, mc4m6 = 0, mc4m7 = 0, mc4m8 = 0, mc4m9 = 0, mc4m10 = 0, mc4m11 = 0, mc4m12 = 0;
            var accountWithSchoolList = from a in db.Accounts
                                        join p in db.Profiles
                                        on a.AccountId equals p.AccountId
                                        select new
                                        {
                                            schoolId = p.SchoolId,
                                            accountCreateDate = a.CreteDate
                                        };
            foreach (var a in accountWithSchoolList)
            {
                switch (a.schoolId)
                {
                    case 1: mc1 += 1;
                        switch (a.accountCreateDate.Month)
                        {
                            case 1:
                                mc1m1 += 1;
                                break;
                            case 2:
                                mc1m2 += 1;
                                break;
                            case 3:
                                mc1m3 += 1;
                                break;
                            case 4:
                                mc1m4 += 1;
                                break;
                            case 5:
                                mc1m5 += 1;
                                break;
                            case 6:
                                mc1m6 += 1;
                                break;
                            case 7:
                                mc1m7 += 1;
                                break;
                            case 8:
                                mc1m8 += 1;
                                break;
                            case 9:
                                mc1m9 += 1;
                                break;
                            case 10:
                                mc1m10 += 1;
                                break;
                            case 11:
                                mc1m11 += 1;
                                break;
                            case 12:
                                mc1m12 += 1;
                                break;
                        }
                        break;
                    case 2: mc2 += 1;
                        switch (a.accountCreateDate.Month)
                        {
                            case 1:
                                mc2m1 += 1;
                                break;
                            case 2:
                                mc2m2 += 1;
                                break;
                            case 3:
                                mc2m3 += 1;
                                break;
                            case 4:
                                mc2m4 += 1;
                                break;
                            case 5:
                                mc2m5 += 1;
                                break;
                            case 6:
                                mc2m6 += 1;
                                break;
                            case 7:
                                mc2m7 += 1;
                                break;
                            case 8:
                                mc2m8 += 1;
                                break;
                            case 9:
                                mc2m9 += 1;
                                break;
                            case 10:
                                mc2m10 += 1;
                                break;
                            case 11:
                                mc2m11 += 1;
                                break;
                            case 12:
                                mc2m12 += 1;
                                break;
                        }
                        break;
                    case 3: mc3 += 1;
                        switch (a.accountCreateDate.Month)
                        {
                            case 1:
                                mc3m1 += 1;
                                break;
                            case 2:
                                mc3m2 += 1;
                                break;
                            case 3:
                                mc3m3 += 1;
                                break;
                            case 4:
                                mc3m4 += 1;
                                break;
                            case 5:
                                mc3m5 += 1;
                                break;
                            case 6:
                                mc3m6 += 1;
                                break;
                            case 7:
                                mc3m7 += 1;
                                break;
                            case 8:
                                mc3m8 += 1;
                                break;
                            case 9:
                                mc3m9 += 1;
                                break;
                            case 10:
                                mc3m10 += 1;
                                break;
                            case 11:
                                mc3m11 += 1;
                                break;
                            case 12:
                                mc3m12 += 1;
                                break;
                        }
                        break;
                    case 4: mc4 += 1;
                        switch (a.accountCreateDate.Month)
                        {
                            case 1:
                                mc4m1 += 1;
                                break;
                            case 2:
                                mc4m2 += 1;
                                break;
                            case 3:
                                mc4m3 += 1;
                                break;
                            case 4:
                                mc4m4 += 1;
                                break;
                            case 5:
                                mc4m5 += 1;
                                break;
                            case 6:
                                mc4m6 += 1;
                                break;
                            case 7:
                                mc4m7 += 1;
                                break;
                            case 8:
                                mc4m8 += 1;
                                break;
                            case 9:
                                mc4m9 += 1;
                                break;
                            case 10:
                                mc4m10 += 1;
                                break;
                            case 11:
                                mc4m11 += 1;
                                break;
                            case 12:
                                mc4m12 += 1;
                                break;
                        }
                        break;
                }
            }
            ViewBag.mc1 = mc1;
            ViewBag.mc2 = mc2;
            ViewBag.mc3 = mc3;
            ViewBag.mc4 = mc4;
            ViewBag.mc1m1 = mc1m1;
            ViewBag.mc1m2 = mc1m2;
            ViewBag.mc1m3 = mc1m3;
            ViewBag.mc1m4 = mc1m4;
            ViewBag.mc1m5 = mc1m5;
            ViewBag.mc1m6 = mc1m6;
            ViewBag.mc1m7 = mc1m7;
            ViewBag.mc1m8 = mc1m8;
            ViewBag.mc1m9 = mc1m9;
            ViewBag.mc1m10 = mc1m10;
            ViewBag.mc1m11 = mc1m11;
            ViewBag.mc1m12 = mc1m12;
            ViewBag.mc2m1 = mc2m1;
            ViewBag.mc2m2 = mc2m2;
            ViewBag.mc2m3 = mc2m3;
            ViewBag.mc2m4 = mc2m4;
            ViewBag.mc2m5 = mc2m5;
            ViewBag.mc2m6 = mc2m6;
            ViewBag.mc2m7 = mc2m7;
            ViewBag.mc2m8 = mc2m8;
            ViewBag.mc2m9 = mc2m9;
            ViewBag.mc2m10 = mc2m10;
            ViewBag.mc2m11 = mc2m11;
            ViewBag.mc2m12 = mc2m12;
            ViewBag.mc3m1 = mc3m1;
            ViewBag.mc3m2 = mc3m2;
            ViewBag.mc3m3 = mc3m3;
            ViewBag.mc3m4 = mc3m4;
            ViewBag.mc3m5 = mc3m5;
            ViewBag.mc3m6 = mc3m6;
            ViewBag.mc3m7 = mc3m7;
            ViewBag.mc3m8 = mc3m8;
            ViewBag.mc3m9 = mc3m9;
            ViewBag.mc3m10 = mc3m10;
            ViewBag.mc3m11 = mc3m11;
            ViewBag.mc3m12 = mc3m12;
            ViewBag.mc4m1 = mc4m1;
            ViewBag.mc4m2 = mc4m2;
            ViewBag.mc4m3 = mc4m3;
            ViewBag.mc4m4 = mc4m4;
            ViewBag.mc4m5 = mc4m5;
            ViewBag.mc4m6 = mc4m6;
            ViewBag.mc4m7 = mc4m7;
            ViewBag.mc4m8 = mc4m8;
            ViewBag.mc4m9 = mc4m9;
            ViewBag.mc4m10 = mc4m10;
            ViewBag.mc4m11 = mc4m11;
            ViewBag.mc4m12 = mc4m12;
            //Avenger Point Each School
            float cas1 = 0, cas2 = 0, cas3 = 0, cas4 = 0;
            float sumS1 = 0, sumS2 = 0, sumS3 = 0, sumS4 = 0;
            var testResultBySchoolList = from tr in db.TestResults
                                 join td in db.TestDetails
                                 on tr.TestDetailId equals td.TestDetailId
                                 join a in db.Accounts
                                 on td.AccountId equals a.AccountId
                                 join p in db.Profiles
                                 on a.AccountId equals p.AccountId
                                 join s in db.Schools
                                 on p.SchoolId equals s.SchoolId
                                 select new
                                 {
                                     score = tr.Score,
                                     schoolId = s.SchoolId
                                 };
            foreach (var s in testResultBySchoolList)
            {
                switch (s.schoolId)
                {
                    case 1:
                        sumS1 += s.score;
                        cas1 += 1;
                        break;
                    case 2:
                        sumS2 += s.score;
                        cas2 += 1;
                        break;
                    case 3:
                        sumS3 += s.score;
                        cas3 += 1;
                        break;
                    case 4:
                        sumS4 += s.score;
                        cas4 += 1;
                        break;
                }
            }
            ViewBag.averageSchool1 = Math.Round(sumS1 / cas1, 1);
            ViewBag.averageSchool2 = Math.Round(sumS2 / cas2, 1);
            ViewBag.averageSchool3 = Math.Round(sumS3 / cas3, 1);
            ViewBag.averageSchool4 = Math.Round(sumS4 / cas4, 1);
            //Avenger Point Each Subject
            */
            double casj1 = 0, casj2 = 0, casj3 = 0, casj4 = 0, casj5 = 0, casj6 = 0, casj7 = 0, casj8 = 0;
            double sumSJ1 = 0, sumSJ2 = 0, sumSJ3 = 0, sumSJ4 = 0, sumSJ5 = 0, sumSJ6 = 0, sumSJ7 = 0, sumSJ8 = 0;
            foreach (var s in db.TestDetails)
            {
                switch (s.SubjectId)
                {
                    case 1:
                        casj1 += 1;
                        sumSJ1 += s.Score;
                        break;
                    case 2:
                        casj2 += 1;
                        sumSJ2 += s.Score;
                        break;
                    case 3:
                        casj3 += 1;
                        sumSJ3 += s.Score;
                        break;
                    case 4:
                        casj4 += 1;
                        sumSJ4 += s.Score;
                        break;
                    case 5:
                        casj5 += 1;
                        sumSJ5 += s.Score;
                        break;
                    case 6:
                        casj6 += 1;
                        sumSJ6 += s.Score;
                        break;
                    case 7:
                        casj7 += 1;
                        sumSJ7 += s.Score;
                        break;
                    case 8:
                        casj8 += 1;
                        sumSJ8 += s.Score;
                        break;
                }
            }
            ViewBag.averageSubject1 = Math.Round(sumSJ1 / casj1, 1);
            ViewBag.averageSubject2 = Math.Round(sumSJ2 / casj2, 1);
            ViewBag.averageSubject3 = Math.Round(sumSJ3 / casj3, 1);
            ViewBag.averageSubject4 = Math.Round(sumSJ4 / casj4, 1);
            ViewBag.averageSubject5 = Math.Round(sumSJ5 / casj5, 1);
            ViewBag.averageSubject6 = Math.Round(sumSJ6 / casj6, 1);
            ViewBag.averageSubject7 = Math.Round(sumSJ7 / casj7, 1);
            ViewBag.averageSubject8 = Math.Round(sumSJ8 / casj8, 1);
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}