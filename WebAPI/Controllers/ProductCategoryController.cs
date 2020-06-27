using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiController
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService) : base()
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        [Route("getall/{keyword}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword = null)
        {
            HttpResponseMessage response = null;
            try
            {
                 var listProduct = _productCategoryService.GetAll(keyword);
                 response = request.CreateResponse(HttpStatusCode.OK, listProduct);
                
            }
            catch(Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSingleById(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var productCategory = _productCategoryService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, productCategory);

            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, ProductCategory productCategory)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newProductCategory = _productCategoryService.Add(productCategory);
                _productCategoryService.Save();
                response = request.CreateResponse(HttpStatusCode.Created, newProductCategory);
            }
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, ProductCategory productCategory)
        {
            HttpResponseMessage response = null;
            //try catch thua
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var productCateDb = _productCategoryService.GetById(productCategory.ID);

                    //update date productCate into productCateDb
                    productCateDb.UpdateProductCategory(productCategory);

                    productCateDb.UpdatedBy = User.Identity.Name;
                    productCateDb.UpdatedDate = DateTime.Now;
                    // update into db
                    _productCategoryService.Update(productCateDb);

                    _productCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [Route("delete/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    _productCategoryService.Delete(id);
                    _productCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return response;
        }
    }
}
