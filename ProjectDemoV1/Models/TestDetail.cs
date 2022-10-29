using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class TestDetail
    {
        [Key]
        public int TestDetailId { get; set; }
        public DateTime CreateDate { get; set; }
        public double Score { get; set; }
        public bool Submitted { get; set; }

        public int AccountId { get; set; }
        //[ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int SubjectId { get; set; }
        //[ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public virtual ICollection<QuestionTest> QuestionTests { get; set; }

    }
}