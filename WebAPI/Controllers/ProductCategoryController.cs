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
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService, IErrorService errorService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRepose(request, () =>
            {
                var listProduct = _productCategoryService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProduct);
                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, ProductCategory productCategory)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var newProductCategory = _productCategoryService.Add(productCategory);
                _productCategoryService.Save();
                response = request.CreateResponse(HttpStatusCode.Created, newProductCategory);
            }
            return response;
        }

        [Route("update")]
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


        [Route("delete")]

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
