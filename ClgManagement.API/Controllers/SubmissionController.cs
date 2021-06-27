using ClgManagement.BusinessLogic.Services;
using ClgManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClgManagement.API.Controllers
{
    public class SubmissionController : ApiController
    {
        private readonly SubmissionService submissionService;
        public SubmissionController()
        {
            submissionService = new SubmissionService();
        }
        //get
        [HttpGet]
        public HttpResponseMessage ViewSubmission()
        {
            var entry = submissionService.GetAll();

            List<AssignmentSubmission> dto = new List<AssignmentSubmission>();
            foreach (var entries in entry)
            {
                dto.Add(new AssignmentSubmission { SubmissionId = entries.SubmissionId, SubmissionDate = entries.SubmissionDate, StudentId = entries.StudentId, CourseCode = entries.CourseCode });
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);

        }
        //add
        [HttpPost]
        public HttpResponseMessage SubmitAssignment(AssignmentSubmission service)
        {
            var entry = submissionService.UploadAssignment(service);
            if (entry == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add data");
            }
        }
    }
}
