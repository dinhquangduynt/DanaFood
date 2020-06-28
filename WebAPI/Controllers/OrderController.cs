using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Model.Models;
using ThucPham.Service;
using WebAPI.Infrastructure.Extensions;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/order")]
    [Authorize]
    public class OrderController : ApiController
    {
        IOrderService _orderService;

        IOrderTotalService _orderTotalService;

        public OrderController(IOrderService orderService, IOrderTotalService orderTotalService) : base()
        {
            this._orderService = orderService;
            this._orderTotalService = orderTotalService;
        }

        //client + admin
        [Route("getall")]
        [Route("getall/{keyword}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword = null)
        {
            HttpResponseMessage response = null;
            try
            {
                var listOrder = _orderService.GetAll(keyword);
                response = Request.CreateResponse(HttpStatusCode.OK, listOrder);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listOrder = _orderService.GetById(id);
                response = Request.CreateResponse(HttpStatusCode.OK, listOrder);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("getorderdetailbyid/{orderId:int}")]
        [HttpGet]
        public HttpResponseMessage GetAllById(HttpRequestMessage request, int orderId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listOrder = _orderService.GetOrderById(orderId);
                response = Request.CreateResponse(HttpStatusCode.OK, listOrder);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        [Route("getordertotal/{orderId:int}")]
        [HttpGet]
        public HttpResponseMessage GetTotal(HttpRequestMessage request, int orderId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listOrder = _orderTotalService.GetById(orderId);
                response = Request.CreateResponse(HttpStatusCode.OK, listOrder);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Authorize(Roles = "Administrator")]
        [Route("updatestatus")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, Order order)
        {
            HttpResponseMessage response = null;
            try
            {
                var or = _orderService.GetById(order.ID);
                _orderService.UpdateStatus(or);
                _orderService.Save();
                
                response = Request.CreateResponse(HttpStatusCode.OK, or);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add1(HttpRequestMessage request, OrderTotal order)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newOrder = _orderService.Add(order);
                    _orderService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, newOrder);
                }
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var order = _orderTotalService.Delete(id);
                _orderService.Save();
                response = Request.CreateResponse(HttpStatusCode.OK, order);
            }
            catch (Exception ex)
            {

                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }
    }
}
