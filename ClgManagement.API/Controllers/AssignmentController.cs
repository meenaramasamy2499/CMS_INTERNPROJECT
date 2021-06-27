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
    public class AssignmentController : ApiController
    {
        private readonly AssignmentService assignmentService;
        public AssignmentController()
        {
            assignmentService = new AssignmentService();
        }
        [HttpPost]

        [Route("api/Assignment/UploadAssignmentQues")]
        public IHttpActionResult UploadAssignmentQues(Assignment service)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var entry = assignmentService.UploadAssignment(service);

            if (entry == true)
            {
                return Ok("Assignment Uploaded Successfully!");
            }
            else
            {
                return BadRequest("Failed to Upload Assignments");
            }

        }
        [HttpGet]
        [Route("api/Assignment/ViewAssignment")]
        public HttpResponseMessage ViewAssignment()
        {
            var Obj = new AssignmentService();
            var entry = Obj.GetAll();

            List<Assignment> dto = new List<Assignment>();
            foreach (var entries in entry)
            {
                dto.Add(new Assignment { AssignmentId = entries.AssignmentId, Question = entries.Question, SubmissionTime = entries.SubmissionTime, StudentId = entries.StudentId, CourseCode = entries.CourseCode });
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }
        [HttpGet]
        [Route("api/assignment/getassignmentbyid/{studentid}")]
        public IHttpActionResult GetAssignmentById([FromUri] int studentid)
        {
            if (studentid != 0)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var res = assignmentService.GetAssignmentById(studentid);
                if (res != null)
                {
                    return Ok(res);
                }

            }
            return NotFound();
        }
    }
}