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
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService, IErrorService errorService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        //Get
        [Route("getall")]
       
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            //return CreateHttpRepose(request, () =>
            //{

            //    var listCategory = _postCategoryService.GetAll();

            //    //var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

            //    HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);

            //    return response;
            //});
            HttpResponseMessage response = null;
            try
            {
                var listCategory = _postCategoryService.GetAll();

                //var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;

            }
            catch(Exception ex)
            {
                 return request.CreateResponse(HttpStatusCode.OK,  ex.Message);
            }
           

        }


        [Route("getsinglebyid")]

        public HttpResponseMessage GetSingleById(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var postCate = _postCategoryService.GetById(id);

                //var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

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
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpRepose(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //PostCategory newPostCategory = new PostCategory();
                   // newPostCategory.UpdatePostCategory(postCategoryVM);
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }


        //Put
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpRepose(request, () =>
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
            });
        }


        //Delete
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpRepose(request, () =>
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
            });
        }


    }
}
