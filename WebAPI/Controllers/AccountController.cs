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
using ThucPham.Common;
using ThucPham.Data.Repositories;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private IRoleRepository _role;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat, IRoleRepository role)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            _role = role;
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
            HttpResponseMessage response = null;

            
            var user = new User() { UserName = model.Email, Email = model.Email, Address = model.Address, PhoneNumber = model.PhoneNumber, BirthDay = model.BirthDay, FullName = model.FullName};

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(model.Role))
                {
                    model.Role = "Customer";
                }
                else
                {
                    model.Role = "Administrator";
                }

                await UserManager.AddToRoleAsync(user.Id, model.Role);

                response = request.CreateResponse(HttpStatusCode.Created, user);
            }
            else
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, "fail");
            }

            return response;
        }



        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, LoginViewModel model)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            else
            {
                string PublicClientId = "self";
                try
                {
                    User user = await UserManager.FindAsync(model.Username, model.Password);
                    if (user != null)
                    {
                        ApplicationOAuthProvider Provider = new ApplicationOAuthProvider(PublicClientId);
                        ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
               OAuthDefaults.AuthenticationType);
                        ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);

                        response = request.CreateResponse(HttpStatusCode.OK, user);

                    }
                }
                catch (Exception ex)
                {

                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }

            }

            return response;
        }

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


        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            try
            {

                var model = UserManager.Users;
                response = request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }



        [Route("getdetail/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(HttpRequestMessage request, string id)
        {
            HttpResponseMessage response = null;

            if (!string.IsNullOrEmpty(id))
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }

            var model = UserManager.FindById(id);

            if(model ==null)
            {
                response = request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                await UserManager.AddToRoleAsync(id, "Administrator");
                response = request.CreateResponse(HttpStatusCode.OK, model);
            }
            

            return response;
        }


        [Route("update")]
        [HttpPut]
        [Authorize]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, RegisterViewModel userViewModel )
        {
            HttpResponseMessage response = null;
            var user = await UserManager.FindByEmailAsync(userViewModel.Email);
            try
            {
                user.UpdateUser(userViewModel);

                user.PasswordHash = UserManager.PasswordHasher.HashPassword(userViewModel.Password);

                var result = UserManager.Update(user);
                response = request.CreateResponse(HttpStatusCode.OK, userViewModel);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


            return response;
        }

        [Route("updatepass/{pass}")]
        [HttpPut]
        [Authorize]
        public async Task<HttpResponseMessage> UpdatePass(HttpRequestMessage request, string pass)
        {
            HttpResponseMessage response = null;
            string name = User.Identity.Name;
            var user = await UserManager.FindByNameAsync(name);
            try
            {
               // user.UpdateUser(userViewModel);

                user.PasswordHash = UserManager.PasswordHasher.HashPassword(pass);

                var result = UserManager.Update(user);
                RegisterViewModel userViewModel = new RegisterViewModel()
                {
                    FullName = user.FullName,
                    BirthDay = (DateTime)user.BirthDay,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.PhoneNumber,
                    Password = user.PasswordHash,
                };
                response = request.CreateResponse(HttpStatusCode.OK, userViewModel);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


            return response;
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
