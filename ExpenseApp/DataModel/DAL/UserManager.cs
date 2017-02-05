using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DataModel.DAL
{
    public class UserManager
    {
        public readonly ExpenseAppEntities _db;
        public UserManager()
        {
            _db = new ExpenseAppEntities();
        }
        public bool IsUserInRole(string loginName, string roleName)
        {
            using (ExpenseAppEntities db = new ExpenseAppEntities())
            {
                UserMaster um = db.UserMasters.Where(o => o.Email.ToLower().Equals(loginName))?.FirstOrDefault();
                if (um != null)
                {
                    var roles = from u in db.UserMasters
                                join r in db.UserTypeMasters on u.UserTypeID equals r.UserTypeID
                                where r.Role.Equals(roleName) && u.UserID.Equals(um.UserID)
                                select r.Role;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public string ValidateUser(string userName, string password)
        {
            try
            {
                var userInfo = _db.UserMasters.FirstOrDefault(u => u.Email == userName);

                if (userInfo != null && userInfo.IsActive == true)
                {
                    byte[] saltBytes = new byte[8];

                    saltBytes = Convert.FromBase64String(userInfo.PasswordSalt);

                    if (ENCDEC.ComputeHash(password, "MD5", saltBytes) == userInfo.PasswordHash)
                    {
                        // Clear any lingering authentication data
                        FormsAuthentication.SignOut();

                        //Create a new Forms Authentication Ticket
                        FormsAuthenticationTicket newAuthTicket = new FormsAuthenticationTicket(userName, false, 20);

                        //Create the FormsIdentity object
                        FormsIdentity formsIdentity = new FormsIdentity(newAuthTicket);

                        //Store the data in claims
                        formsIdentity.AddClaim(new Claim("UserName", userInfo.UserName));
                        formsIdentity.AddClaim(new Claim("Role", userInfo.UserTypeMaster.Description));
                        formsIdentity.AddClaim(new Claim("Email", userInfo.Email));
                        formsIdentity.AddClaim(new Claim("UserID", userInfo.UserID.ToString()));
                        formsIdentity.AddClaim(new Claim("UserTypeID", userInfo.UserTypeMaster.UserTypeID.ToString()));

                        //Attach the new principal object to the current HttpContext object
                        HttpContext.Current.User = new GenericPrincipal(formsIdentity, new string[] { });

                        //Make sure the Principal's are in sync
                        Thread.CurrentPrincipal = HttpContext.Current.User;

                        return "Success";
                    }
                    else
                    {
                        return "The user name or password is incorrect.";
                    }
                }
                else
                {
                    if (userInfo.IsActive == false)
                    {
                        return "The user account disabled by the admin.";
                    }
                    else
                    {
                        return "The user name or password is incorrect.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}
