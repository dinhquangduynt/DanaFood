
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

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }



        [HttpPost]
        [Authorize]
        [Route("logout")]
        public HttpResponseMessage Logout(HttpRequestMessage request)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }
    }
}
