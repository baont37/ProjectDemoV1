using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.Models
{
    public class Profile
    {
        [ForeignKey("Account")]
        [Key]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
      
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string SchoolName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }

        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        

    }
}