using DataModel.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [Authorize]
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
        
        [HttpPost]
        public ActionResult Login(UserLoginBO user, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie("Test", false);
            return Json(true);
        }
    }
}
