using DataModel.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Expenses.Security;

namespace Expenses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [AuthorizeRole("User")]
        public ActionResult Pricing()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpGet]
        public ActionResult Unauthorized()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}
