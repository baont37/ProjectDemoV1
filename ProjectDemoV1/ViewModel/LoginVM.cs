using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemoV1.ViewModel
{
    public class LoginVM
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string RoleName { get; set; }


        ClassDbContext db = new ClassDbContext(); 

        public Account find(string username)
        {
            return db.Accounts.Single(acc => acc.UserName.Equals(username));
        }

        public Account login(string username, string password)
        {
            return db.Accounts.Where(acc => acc.UserName.Equals(username) && acc.PassWord.Equals(password)).FirstOrDefault();
        }
    }
}