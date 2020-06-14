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
    public class OrderController : ApiController
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService) : base()
        {
            this._orderService = orderService;
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

        [Route("updatestatus")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, Order order)
        {
            HttpResponseMessage response = null;
            try
            {
                _orderService.UpdateStatus(order.ID);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request,Order order, List<OrderDetail> orderDetail)
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
                    var newOrder = _orderService.Create(ref order, orderDetail);
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
                var order = _orderService.Delete(id);
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
