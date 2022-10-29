
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public byte[] Image { get; set; }
        public string Solution { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public int TestTypeId { get; set; }
        [ForeignKey("TestTypeId")]
        public virtual TestType TestType { get; set; }

        public int Answer_Id { get; set; }
        [ForeignKey("Answer_Id")]
        public virtual Answer Answer { get; set; }


        public virtual ICollection<QuestionTest> QuestionTests { get; set; }


    }
}