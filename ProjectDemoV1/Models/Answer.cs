using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuestionTest> QuestionTests { get; set; }
    }
}