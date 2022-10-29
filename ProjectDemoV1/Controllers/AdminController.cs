using ProjectDemoV1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemoV1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ClassDbContext db = new ClassDbContext();
        public ActionResult Index()
        {               
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}