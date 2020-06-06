using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Service;
using WebAPI.Infrastructure.Core;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/productCategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService,IErrorService errorService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage get(HttpRequestMessage request)
        {
            return CreateHttpRepose(request, () =>
            {
                var listProduct = _productCategoryService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listProduct);
                return response;
            });
        }
    }
}
