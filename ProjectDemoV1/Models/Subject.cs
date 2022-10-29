using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Duration { get; set; }
        public int TotalQuestion { get; set; }
        public string ImgLink { get; set; }

        public int CombinationId { get; set; }
        [ForeignKey("CombinationId")]
        public virtual Combination Combination { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}