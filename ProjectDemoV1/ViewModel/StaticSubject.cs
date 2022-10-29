using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.ViewModel
{
    public class StaticSubject
    {
        public StaticSubject()
        {
        }

        public StaticSubject(int subjectId, string subjectName, int duration, int totalApproveQuestion, string combinationName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Duration = duration;
            TotalApproveQuestion = totalApproveQuestion;
            CombinationName = combinationName;      
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Duration { get; set; }
        public int TotalApproveQuestion { get; set; }
        public string CombinationName { get; set; }



    }
}