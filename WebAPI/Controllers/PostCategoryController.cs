using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;
using WebAPI.Infrastructure.Core;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/postcategory")]
    //[Authorize]
    public class PostCategoryController : ApiController
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService) : base()
        {
            this._postCategoryService = postCategoryService;
        }

        //Get
        [Route("getall")]
        //search
        [Route("getall/{keyword}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword = null)
        {
            HttpResponseMessage response = null;
            try
            {
                var listCategory = _postCategoryService.GetAll(keyword);

                response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;

            }
            catch(Exception ex)
            {
                 return request.CreateResponse(HttpStatusCode.BadRequest,  ex.Message);
            }
        }


        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSingleById(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var postCate = _postCategoryService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, postCate);

                return response;

            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }


        //Post
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
           
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            
        }


        //Put
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
           HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategory.ID);
                    postCategoryDb.UpdatePostCategory(postCategory);
        
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            
        }


        //Delete
        [Route("delete/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;

        }
    }
}
