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
    public class AttendanceController : ApiController
    {
        private readonly AttendanceService attendanceService;
        public AttendanceController()
        {
            attendanceService = new AttendanceService();
        }
        //get
        [HttpGet]
        [Route("api/attendance/getattendance")]
        public HttpResponseMessage GetAttendance()
        {
            var entry = attendanceService.GetAll();

            List<Attendance> dto = new List<Attendance>();
            foreach (var entries in entry)
            {
                dto.Add(new Attendance { AttendanceDate = entries.AttendanceDate, StudentId = entries.StudentId, FacultyId = entries.FacultyId,IsPresent=entries.IsPresent});
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);


            /*if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entry);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Failed to get data");
            }*/
        }
        //add
        [HttpPost]
        public HttpResponseMessage AddAttendanceEntry(Attendance service)
        {
            var entry = attendanceService.AddAttendance(service);
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
        [HttpGet]
        [Route("api/attendance/getattendancebyid/{studentid}")]
        public IHttpActionResult GetAttendanceById([FromUri] int studentid)
        {
            if (studentid != 0)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var res = attendanceService.GetAttendanceId(studentid);
                if (res != null)
                {
                    return Ok(res);
                }

            }
            return NotFound();
        }
    }
}