using ClgManagement.BusinessLogic.DTOs;
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
    public class LeaveDetailsController : ApiController
    {
        private readonly RequestLeave requestLeave;

        public LeaveDetailsController()
        {
            requestLeave = new RequestLeave();
        }

        //protected override void Disposal(bool disposing)
        //{
        //    requestLeave.Dispose();
        //    base.Dispose(disposing);
        //}
        /// <summary>
        /// Students/Faculty can request leave & the request leave will be sent to admin.
        /// </summary>
        /// <param name="leaveDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult LeaveRequest([FromBody] LeaveDetails leaveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            var Obj = new LeaveDetails();

            Obj.DateOfLeave = leaveDetails.DateOfLeave;
            Obj.IsApproved = false;
            Obj.UserId = leaveDetails.UserId;
            Obj.Reason = leaveDetails.Reason;

            var res = requestLeave.requestingforLeave(Obj);

            if (res == true)
            {
                return Ok();
            }

            return BadRequest("Invalid Request");

        }
        [HttpGet]
        [Route("api/leavedetails/getattendance")]
        public HttpResponseMessage GetAttendance()
        {
            var Obj = new RequestLeave();
            var entry = Obj.GetAll();

            List<LeaveDetails> dto = new List<LeaveDetails>();
            foreach (var entries in entry)
            {
                dto.Add(new LeaveDetails { DateOfLeave = entries.DateOfLeave, Reason = entries.Reason, LeaveDetailsId = entries.LeaveDetailsId, UserId = entries.UserId });
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);


        }
        [HttpGet]
        [Route ("api/leavedetails/getleavebyid/{studentId}")]
        //leave details by user id
        public IHttpActionResult GetStudentDetailsById([FromUri] int studentId)
        { 

            if (studentId != 0)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var res = requestLeave.GetUserDetails(studentId);

                if(res != null)
                {
                    return Ok(res);
                }

            }

            return NotFound();
        }

        [HttpPut]
        [Route ("api/leavedetails/put/{LeaveDetailsId}")]
        public IHttpActionResult put(int LeaveDetailsId)
        {
            var Obj = requestLeave.IsApproved(LeaveDetailsId);
            if (Obj)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
