
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
using static WebAPI.App_Start.Startup;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        ApplicationSignInManager _signInManager;
        ApplicationUserManager _userManager;

        public AccountController()
        {

        }

        public AccountController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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
                try
                {
                    User user = await UserManager.FindAsync(model.Username, model.Password);
                    if (user != null)
                    {
                        ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);

                        response = request.CreateResponse(HttpStatusCode.OK, identity);
                    }
                }
                catch (Exception ex)
                {
                  
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }


            }

            return response;
        }
    }
}
