using DataModel;
using DataModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Security
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        private readonly ExpenseAppEntities _db;
        public AuthorizeRoleAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
            _db = new ExpenseAppEntities();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            UserManager UM = new UserManager();

            foreach (var roles in userAssignedRoles)
            {
                authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                if (authorize)
                {
                    return authorize;
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/Unauthorized");
        }
    }
}