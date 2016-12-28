using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAL
{
    public class UserManager
    {
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
    }

}
