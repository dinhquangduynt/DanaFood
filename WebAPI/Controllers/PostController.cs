using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        IPostService _postService;

        public PostController(IPostService postSevice):base()
        {
            this._postService = postSevice;
        }

        [Route("getall")]
        [Route("getall/{keyword}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword = null)
        {
            HttpResponseMessage response = null;
            try
            {
                var listPost = _postService.GetAll(keyword);
                response = request.CreateResponse(HttpStatusCode.OK, listPost);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _postService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        [Route("getallbytag/{tagId}")]
        [HttpGet]
        public HttpResponseMessage GetAllByTag(HttpRequestMessage request, string tagId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listPost= _postService.GetAllByTag(tagId);
                response = request.CreateResponse(HttpStatusCode.OK, listPost);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        [Route("getallbycategory/{cateId:int}")]
        [HttpGet]
        public HttpResponseMessage GetAllByCategory(HttpRequestMessage request, int cateId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listPost = _postService.GetAllByCategory(cateId);
                response = request.CreateResponse(HttpStatusCode.OK, listPost);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize]
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, Post post)
        {

            HttpResponseMessage response = null;
            try
            {
                var postDb = _postService.GetById(post.ID);
                postDb.UpdatePost(post);
                postDb.UpdatedBy = User.Identity.Name;
                postDb.UpdatedDate = DateTime.Now;
                _postService.Update(postDb);
                _postService.Save();
                response = request.CreateResponse(HttpStatusCode.OK, postDb);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize]
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request, Post post)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newPost = new Post();
                    newPost.CreatedBy = User.Identity.Name;
                    newPost.CreatedDate = DateTime.Now;
                    newPost = _postService.Add(post);
                    _postService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, newPost);
                }

            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize]
        [Route("delete/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var post = _postService.Delete(id);
                response = request.CreateResponse(HttpStatusCode.OK, post);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

    }
}
