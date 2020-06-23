
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ThucPham.Model.Models;
using WebAPI.App_Start;
using WebAPI.Models;
using System.Threading;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;
using WebAPI.Provider;
using WebAPI.Results;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; } 

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<HttpResponseMessage> Register(HttpRequestMessage request, RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var user = new User() { UserName = model.Email, Email = model.Email, Address = model.Address, PhoneNumber = model.PhoneNumber, BirthDay = model.BirthDay };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            return request.CreateResponse(HttpStatusCode.OK);
        }



        //[AllowAnonymous]
        //[Route("login")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> Login(HttpRequestMessage request, LoginViewModel model)
        //{
        //    HttpResponseMessage response = null;
        //    if (!ModelState.IsValid)
        //    {
        //        return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    else
        //    {
        //        try
        //        {
        //            User user = await UserManager.FindAsync(model.Username, model.Password);
        //            if (user != null)
        //            {
        //               ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);
        //                response = request.CreateResponse(HttpStatusCode.OK, identity);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
                  
        //            response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //        }

        //    }

        //    return response;
        //}

        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            User user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok(user);
        }



        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }
        #region helper
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
        #endregion
 
    }
}
