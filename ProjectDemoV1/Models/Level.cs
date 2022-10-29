using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}