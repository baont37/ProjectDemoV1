using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class TestType
    {
        [Key]
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}