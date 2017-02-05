using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Areas.SuperAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: SuperAdmin/Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ManageCategory()
        {
            return View();
        }
    }
}