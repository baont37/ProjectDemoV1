using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Combination
    {
        [Key]
        public int CombinationId { get; set; }
        public string CombinationName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}