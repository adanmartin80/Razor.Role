using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Role.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string role)
        {
            ViewBag.Role = role;
            return View();
        }

        public ActionResult About(string role)
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.Role = role;
            return View();
        }

        public ActionResult Contact(string role)
        {
            ViewBag.Message = "Your contact page.";

            ViewBag.Role = role;
            return View();
        }
    }
}