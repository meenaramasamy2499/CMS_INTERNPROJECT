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
    public class IssueController : ApiController
    {
        private readonly IssueService issueService;
        public IssueController()
        {
            issueService = new IssueService();
        }
        //get
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var entry = issueService.GetAll();

            List<IssueReport> dto = new List<IssueReport>();
            foreach (var entries in entry)
            {
                dto.Add(new IssueReport { Ticket = entries.Ticket, Description = entries.Description, UserId = entries.UserId });
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);
        }
        //add
        [HttpPost]
        public HttpResponseMessage RaiseIssue(IssueReport service)
        {
            var entry = issueService.RaiseIssue(service);

            if (entry == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add data");
            }

        }

        [HttpGet]
        [Route("api/issue/getissuebyid/{userId}")]
        //issue report by user id
        public IHttpActionResult GetIssueById([FromUri] int userId)
        {

            if (userId != 0)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var res = issueService.GetIssueById(userId);

                if (res != null)
                {
                    return Ok(res);
                }

            }

            return NotFound();
        }

        [HttpPut]
        [Route("api/issue/put/{ticketId}")]
        public IHttpActionResult put(int ticketId)
        {
            var Obj = issueService.IsResolved(ticketId);
            if (Obj == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
