using AutoMapper;
using DataModel;
using DataModel.BO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace ExpenseApp.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("RegisterUser")]
        public IHttpActionResult RegisterUser(JObject jsonData)
        {
            try
            {
                using (var _db = new ExpenseAppEntities())
                {
                    dynamic json = jsonData;
                    JObject userObj = json.objUser;

                    var user = userObj.ToObject<UserMaster>();

                    // Password encryption Start
                    byte[] saltBytes = new byte[8];
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    rng.GetNonZeroBytes(saltBytes);
                    string pwdSalt = Convert.ToBase64String(saltBytes);
                    string pwdHash = ENCDEC.ComputeHash(userObj["Password"].ToString(), "MD5", saltBytes);
                    // End

                    user.PasswordSalt = pwdSalt;
                    user.PasswordHash = pwdHash;
                    user.IsActive = true;
                    user.IsPro = false;
                    user.UserTypeID = 2;

                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = null;

                    _db.UserMasters.Add(user);
                    _db.SaveChanges();

                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IHttpActionResult ForgotPassword(JObject jsonData)
        {
            try
            {
                using (var _db = new ExpenseAppEntities())
                {
                    dynamic json = jsonData;
                    string email = json.email.ToString();

                    var user = _db.UserMasters.Where(u => u.Email == email).FirstOrDefault();

                    if (user != null)
                    {
                        // Code to send email to be added here.
                        return Ok(1);
                    }
                    else
                    {
                        return Ok(2);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}