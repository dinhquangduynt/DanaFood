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

[assembly: OwinStartup(typeof(WebAPI.App_Start.Startup))]

namespace WebAPI.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {

            //enable cors policy
            app.UseCors(CorsOptions.AllowAll);
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(WebApiDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.CreatePerOwinContext<UserManager<User>>(CreateManager);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new AuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,

            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }

        public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

                if (allowedOrigin == null) allowedOrigin = "*";

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

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
                    var applicationGroupService = ServiceFactory.Get<IGroupService>();
                    var listGroup = applicationGroupService.GetListGroupByUserId(user.Id);
                    if (listGroup.Any(x => x.Name == CommonConstants.Administrator))
                    {
                        ClaimsIdentity identity = await userManager.CreateIdentityAsync(
                                       user,
                                       DefaultAuthenticationTypes.ExternalBearer);
                        context.Validated(identity);
                    }
                    else
                    {
                        context.Rejected();
                        context.SetError("invalid_group", "Bạn không phải là admin");
                    }

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
    }
}
