using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.BO
{
    public class UserMasterBO
    {
        public long UserID { get; set; }
        public byte UserTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public System.DateTime DOB { get; set; }
        public short Country { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public short DefaultCurrency { get; set; }
        public bool IsActive { get; set; }
        public bool IsPro { get; set; }
    }

    public class UserLoginBO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
