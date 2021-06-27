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
    public class CalendarController : ApiController
    {
        private readonly CalendarService calendarService;
        public CalendarController()
        {
            calendarService = new CalendarService();
        }
        //get
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var entry = calendarService.GetAll();

            List<CalendarDto> dto = new List<CalendarDto>();
            foreach (var entries in entry)
            {
                dto.Add(new CalendarDto { DateOfEdit = entries.DateOfEdit, Reason = entries.Reason, Status = entries.Status });
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
        public HttpResponseMessage AddCalendarEntry(Calendar service)
        {
            var entry = calendarService.AddCalendar(service);

            if (entry == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add data");
            }

        }
    }
}

