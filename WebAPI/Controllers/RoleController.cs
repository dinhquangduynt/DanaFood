using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        IRoleService _roleService;

        public RoleController(IRoleService roleService) :base()
        {
            this._roleService = roleService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            var model = _roleService.GetAll();

            response = request.CreateResponse(HttpStatusCode.OK, model);

            return request.CreateResponse(HttpStatusCode.OK, model);
        }


        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request)
        {
            //HttpResponseMessage response = null;
            //var model = _roleService.GetAll();

            //response = request.CreateResponse(HttpStatusCode.OK, model);

            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request, Role role)
        {
            HttpResponseMessage response = null;
            try
            {
               
                var model = _roleService.Add(role);
                _roleService.Save();
                response = request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {

                 response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message );
            }

            //response = request.CreateResponse(HttpStatusCode.OK, model);

            return response;
        }
    }
}
