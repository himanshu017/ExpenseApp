using DataModel.BO;
using DataModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Expenses.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            UserManager obj = new UserManager();

            string result = obj.ValidateUser(userName, password);

            if (result == "Success")
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                var identity = (ClaimsIdentity)User.Identity;
                var userID = identity.FindFirst("UserID").Value;

                return Json(true);
            }
            else
            {

                return Json(result);
            }
        }
    }
}