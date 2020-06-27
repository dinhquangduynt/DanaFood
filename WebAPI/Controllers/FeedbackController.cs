using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ThucPham.Common;
using ThucPham.Data.Infrastructure;
using ThucPham.Model.Models;
using ThucPham.Service;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/feedback")]
    public class FeedbackController : ApiController
    {
        ISupportOnlineService _supportOnlineService;
        IFeedbackService _feedbackService;
        IUnitOfWork _unitOfWord;

        public FeedbackController(IFeedbackService feedbackService, IUnitOfWork unitOfWork,
            ISupportOnlineService supportOnlineService)
        {
            this._feedbackService = feedbackService;
            this._unitOfWord = unitOfWork;
            _supportOnlineService = supportOnlineService;
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


        [Route("getbyid/{id:int}")]
        [HttpGet]

        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listFeedback = _feedbackService.GetByID(id);
                response = request.CreateResponse(HttpStatusCode.OK, listFeedback);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }


        [Route("add")]
        [HttpPost]

        public HttpResponseMessage Add(HttpRequestMessage request, Feedback feedback)
        {
            HttpResponseMessage response = null;
            try
            {
                feedback.CreatedDate = DateTime.Now;
                feedback.Status = false;
                var listFeedback = _feedbackService.Create(feedback);
                _feedbackService.Save();
                response = request.CreateResponse(HttpStatusCode.Created, listFeedback);
            }
            catch (Exception ex)
            {

                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        [Authorize(Roles = "Administrator")]
        [Route("reply/{id:int}")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, SupportOnline support ,int id)
        {
            HttpResponseMessage response = null;
            try
            {
                var feedback = _feedbackService.Update(id);
                var suppor = _supportOnlineService.Create(support);

                var content = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Infrastructure/Extensions/MailHelper.html"));

                content = content.Replace("{{UserName}}", support.Name);
                content = content.Replace("{{Content}}", support.Content);

                if (MailHelper.SendMail(support.Email,support.Title, content))
                {
                    _supportOnlineService.Save();
                    _feedbackService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, feedback);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, "Fail");
                }
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }
    }
}
