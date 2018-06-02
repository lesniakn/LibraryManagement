using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Aktor.ToList());
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}