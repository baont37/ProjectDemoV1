using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProjectDemoV1.Data;
using ProjectDemoV1.Models;
using ProjectDemoV1.ViewModel;
using StructureMap;

namespace ProjectDemoV1.Controllers
{
    public class ProfilesController : Controller
    {
        private ClassDbContext db = new ClassDbContext();

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }


        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", profile.AccountId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", profile.GenderId);
            return View(profile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, [Bind(Include = "AccountId,FullName,BirthDay,Phone,SchoolName,Email,Avatar,GenderId")] Profile profile, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var profiles = db.Profiles.AsNoTracking().Single(e => e.AccountId == id);

                if (uploadImage != null)
                {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                        }
                        var Image = new Profile
                        {
                            Avatar = imageData
                        };
                        profile.Avatar = Image.Avatar;
                }
                else
                {
                    profile.Avatar = profiles.Avatar;
                }
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Profiles", new { id = @Session["AccountId"] });
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "UserName", profile.AccountId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", profile.GenderId);
            return View(profile);
        }



        public ActionResult Changepassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Changepassword(ChangePasswordVM changePassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                var f_password = GetMD5(changePassword.Password);
                changePassword.ConfirmPassword = GetMD5(changePassword.ConfirmPassword);
                var detail = db.Accounts.Where(p => p.PassWord.Equals(f_password) && p.UserName.Equals(changePassword.UserName)).FirstOrDefault();
                if (detail != null)
                {
                    detail.PassWord = GetMD5(changePassword.NewPassword);
                    db.SaveChanges();
                    ViewBag.Message = "Đổi mật khẩu thành công";
                    return RedirectToAction("Details", "Profiles", new { id = Session["AccountId"] });
                }
                else
                {
                    ViewBag.Message = "Vui lòng nhập đúng mật khẩu!";
                }

                }
                catch (Exception)
                {
                    return View();
                }
            }

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

        public FileContentResult getImg(int id)
        {
            byte[] byteArray = db.Profiles.Find(id).Avatar;
            return byteArray != null
                ? new FileContentResult(byteArray, "image/jpg")
                : null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
