using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        IProductService _productService;
        public ProductController(IProductService productService) : base()
        {
            this._productService = productService;
        }

        [Route("getall")]
        [Route("getall/{keyword}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword = null)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _productService.GetAll(keyword);
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
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
                var listProduct = _productService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("getallbycategory/{cateId:int}")]
        [HttpGet]
        public HttpResponseMessage GetListByCateId(HttpRequestMessage request, int cateId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _productService.GetAllByCategory(cateId);
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
        public HttpResponseMessage GetListByTag(HttpRequestMessage request, string tagId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _productService.GetListProductByTag(tagId);
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
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
        public HttpResponseMessage Update(HttpRequestMessage request, Product product)
        {

            HttpResponseMessage response = null;
            try
            {
                var productDb = _productService.GetById(product.ID);
                productDb.UpdateProduct(product);
                productDb.UpdatedDate = DateTime.Now;
                productDb.UpdatedBy = User.Identity.Name;

                _productService.Update(productDb);
                _productService.Save();
                response = request.CreateResponse(HttpStatusCode.OK, productDb);
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
        public HttpResponseMessage Add(HttpRequestMessage request, Product product)
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
                    var productDb = new Product();
                    productDb.CreatedBy = User.Identity.Name;
                    productDb.CreatedDate = DateTime.Now;
                    productDb = _productService.Add(product);

                    _productService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, productDb);
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
                var listProduct = _productService.Delete(id);
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

    }
}
