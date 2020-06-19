using System;
using Microsoft.Owin;
using Owin;
using ThucPham.Data;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ThucPham.Model.Models;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using ThucPham.Service;
using WebAPI.Infrastructure.Core;
using System.Linq;
using ThucPham.Common;
using WebAPI.Provider;
using Microsoft.Owin.Security;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(WebAPI.App_Start.Startup))]

namespace WebAPI.App_Start
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {

            //enable cors policy
            app.UseCors(CorsOptions.AllowAll);
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(WebApiDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
               Provider = new ApplicationOAuthProvider(PublicClientId),
              
                AuthorizeEndpointPath = new PathString("/api/account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);


        }

        public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                //var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                //if (allowedOrigin == null) allowedOrigin = "*";

                //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

                UserManager<User> userManager = context.OwinContext.GetUserManager<UserManager<User>>();
                User user;
                try
                {
                    user = await userManager.FindAsync(context.UserName, context.Password);
                }
                catch
                {
                    // Could not retrieve the user due to error.
                    context.SetError("server_error");
                    context.Rejected();
                    return;
                }
                if (user != null)
                {

                    //phan quyen admin, k can thiet
                    //var applicationGroupService = ServiceFactory.Get<IGroupService>();
                    //var listGroup = applicationGroupService.GetListGroupByUserId(user.Id);

                    //if (listGroup.Any(x => x.Name == CommonConstants.Administrator))
                    //{
                    ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);


                    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
                       OAuthDefaults.AuthenticationType);
                    ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                        CookieAuthenticationDefaults.AuthenticationType);

                    AuthenticationProperties properties = CreateProperties(user.UserName, user.Email);
                    AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
                        context.Validated(ticket);
                    //context.Request.Context.Authentication.SignIn(cookiesIdentity);
                    //}
                    //else
                    //{
                    //    context.Rejected();
                    //    context.SetError("invalid_group", "Bạn không phải là admin");
                    //}

                }
                else
                {
                    context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu không đúng.'");
                    context.Rejected();
                }
            }
        }



        private static UserManager<User> CreateManager(IdentityFactoryOptions<UserManager<User>> options, IOwinContext context)
        {
            var userStore = new UserStore<User>(context.Get<WebApiDbContext>());
            var owinManager = new UserManager<User>(userStore);
            return owinManager;
        }

        public static AuthenticationProperties CreateProperties(string userName, string fullname)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "Fullname", fullname }
            };
            return new AuthenticationProperties(data);
        }
    }
}
