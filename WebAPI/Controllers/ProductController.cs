using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Service;

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


    }
}
