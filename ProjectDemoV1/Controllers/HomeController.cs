using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.Security;
using ProjectDemoV1.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemoV1.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ClassDbContext db = new ClassDbContext();
        public ActionResult Index()
        {
            var subjects = db.Subjects;
            return View(subjects.ToList());
        }
        public ActionResult questionTest()
        {
            return View();
        }

        public ActionResult study()
        {
            return View();
        }


        public ActionResult Register()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register _account)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                var data = db.Accounts.Where(s => s.UserName.Equals(_account.UserName)).FirstOrDefault();
                if (data==null)
                {
                    _account.PassWord = GetMD5(_account.PassWord);
                    _account.ConfirmPassword = GetMD5(_account.ConfirmPassword);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var model = new Account()
                    {
                        UserName = _account.UserName,
                        PassWord = _account.PassWord,
                        CreateDate = _account.CreateDate,
                        RoleId = _account.RoleId
                    };

                    var model1 = new Profile()
                    {
                        AccountId = _account.AccountId,
                        FullName = _account.FullName,
                        BirthDay = _account.BirthDay,
                        Phone = _account.Phone,
                        GenderId = _account.GenderId,
                        SchoolName = _account.SchoolName,
                        Email = _account.Email
                    };

                    db.Accounts.Add(model);
                    db.Profiles.Add(model1);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.error = "Tên người dùng đã tồn tại";
                    return View();
                }

            }
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public JsonResult IsUserExists(string UserName)
        {
            return Json(!db.Accounts.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEmailExists(string Email)
        {
            return Json(!db.Profiles.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }



        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {

            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Accounts.Where(s => s.UserName.Equals(username) && s.PassWord.Equals(f_password)).FirstOrDefault();
                
                if (data!=null)
                {
                    //add session
                    Session["UserName"] = data.UserName;
                    Session["AccountId"] = data.AccountId;
                    Session["RoleId"] = data.RoleId;
                    Session["RoleName"] = data.Role.RoleName;
                    if (data.RoleId == 1)
                    {
                        return RedirectToAction("Statistic", "Dashboard");
                    }

                    else if (data.RoleId == 2)
                    {
                        return RedirectToAction("Statistic", "Dashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Tên đăng nhập hoặc mật khẩu sai!";
                }
            }
            return View();
        }*/


        [HttpPost]
        public ActionResult Login(LoginVM accountViewModel)
        {

            var f_password = GetMD5(accountViewModel.PassWord);
            var data = db.Accounts.Where(s => s.UserName.Equals(accountViewModel.UserName) && s.PassWord.Equals(f_password)).FirstOrDefault();
            /*if (string.IsNullOrEmpty(accountViewModel.UserName) || string.IsNullOrEmpty(f_password) || accountViewModel.login(accountViewModel.UserName, f_password) == null)
            {
                    ViewBag.error = "Tên đăng nhập hoặc mật khẩu sai!";
            }*/
            if (data!= null)
            {
                var model = new Account()
                {
                    UserName = accountViewModel.UserName,
                    PassWord = accountViewModel.PassWord
                };

                Session["UserName"] = data.UserName;
                Session["AccountId"] = data.AccountId;
                Session["RoleId"] = data.RoleId;
                Session["RoleName"] = data.Role.RoleName;


                SimpleSessionPersister.Username = accountViewModel.UserName;
                if (data.RoleId == 1)
                {
                    return RedirectToAction("Statistic", "Dashboard");
                }

                else if (data.RoleId == 2)
                {
                    return RedirectToAction("Statistic", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            
            else
            {
                ViewBag.error = "Tên đăng nhập hoặc mật khẩu sai!";
            }
            return View();
        }



        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index","Home");
        }


        public ActionResult Error()
        {
            return View();
        }

    }
}