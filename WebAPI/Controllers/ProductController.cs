﻿using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ThucPham.Common;
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
            //string path = @"D:\workspace_\Project-CNPM\C#\ThucPham\WebAPI\Infrastructure\Extensions\MailHelper.html";
            //string content = System.IO.File.ReadAllText(path);
            //content = content.Replace("{{UserName}}", "Đinh Quang Duy");
            // content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink") + "dang-nhap.html");
            //bool rs =  MailHelper.SendMail("dinhquangduynt@gmail.com", "Đăng ký thành công", "tks");
            //response = request.CreateResponse(HttpStatusCode.OK, rs);
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


        [Route("gethot")]
        [HttpGet]
        public HttpResponseMessage GetHot(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _productService.GetHotProduct();
                response = request.CreateResponse(HttpStatusCode.OK, listProduct);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize(Roles = "Administrator")]
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



        [Authorize(Roles = "Administrator")]
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
                    // productDb.CreatedBy = User.Identity.Name;
                    // productDb.UpdateProduct(product);
                    //UploadFileController upload = new UploadFileController();
                    //product.Image = await upload.UploadFile();

                    product.CreatedDate = DateTime.Now;
                    product.CreatedBy = User.Identity.Name;
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

        [Authorize(Roles = "Administrator")]
        [Route("delete/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listProduct = _productService.Delete(id);
                _productService.Save();
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
