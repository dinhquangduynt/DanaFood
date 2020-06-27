using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThucPham.Data.Infrastructure;
using ThucPham.Service;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/feedback")]
    public class FeedbackController : ApiController
    {
        IFeedbackService _feedbackService;
        IUnitOfWork _unitOfWord;

        public FeedbackController(IFeedbackService feedbackService, IUnitOfWork unitOfWork)
        {
            this._feedbackService = feedbackService;
            this._unitOfWord = unitOfWork;
        }


        [Route("getall")]
        [HttpGet]

        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            try
            {
                var listFeedback = _feedbackService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, listFeedback);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }

        [Route("reply")]
        [HttpPut]

        public HttpResponseMessage Update(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var feedback = _feedbackService.Update(id);
                _feedbackService.Save();
                response = request.CreateResponse(HttpStatusCode.OK, feedback);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }
    }
}
