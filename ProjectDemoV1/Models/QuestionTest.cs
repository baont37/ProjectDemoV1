using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class QuestionTest
    {
        public QuestionTest()
        {
        }

        public QuestionTest(int testDetailId, int questionId, int answerId)
        {
            TestDetailId = testDetailId;
            QuestionId = questionId;
            AnswerId = answerId;
        }

        [Key]
        public int QuetionTestId { get; set; }


        public int TestDetailId { get; set; }
        [ForeignKey("TestDetailId")]
        public virtual TestDetail TestDetail { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual Answer Answer { get; set; }
    }
}