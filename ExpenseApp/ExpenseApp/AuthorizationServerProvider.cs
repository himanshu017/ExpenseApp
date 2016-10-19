using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using DataModel;

namespace ExpenseApp
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                if (allowedOrigin == null) allowedOrigin = "*";

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

                // Validate your user and base on validation return claim identity or invalid_grant error
                using (var _dbcontext = new ExpenseAppEntities())
                {
                    var userInfo = _dbcontext.UserMasters.FirstOrDefault(u => u.Email == context.UserName);

                    if (userInfo != null && userInfo.IsActive == true)
                    {
                        byte[] saltBytes = new byte[8];

                        saltBytes = Convert.FromBase64String(userInfo.PasswordSalt);

                        if (ENCDEC.ComputeHash(context.Password, "MD5", saltBytes) == userInfo.PasswordHash)
                        {
                            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                            identity.AddClaim(new Claim(ClaimTypes.Name, userInfo.FirstName));
                            identity.AddClaim(new Claim(ClaimTypes.Role, userInfo.UserTypeMaster.Description));
                            identity.AddClaim(new Claim(ClaimTypes.Email, userInfo.Email));
                            identity.AddClaim(new Claim("UserID", userInfo.UserID.ToString()));
                            identity.AddClaim(new Claim("UserTypeID", userInfo.UserTypeMaster.UserTypeID.ToString()));

                            var props = new AuthenticationProperties(new Dictionary<string, string>
                                    {
                                        {
                                            "userName", userInfo.FirstName
                                        },
                                        {
                                            "role",userInfo.UserTypeMaster.Description
                                        },
                                        {
                                            "UserID",userInfo.UserID.ToString()
                                        },
                                        {
                                            "UserTypeID",userInfo.UserTypeID.ToString()
                                        }
                                    });
                            var ticket = new AuthenticationTicket(identity, props);
                            context.Validated(ticket);
                        }
                        else
                        {
                            context.SetError("invalid_grant", "The user name or password is incorrect.");
                            return;
                        }
                    }
                    else
                    {
                        if (userInfo.IsActive == false)
                        {
                            context.SetError("Not Approved", "The user account disabled by the admin.");
                        }
                        else
                        {
                            context.SetError("invalid_grant", "The user name or password is incorrect.");
                        }
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}