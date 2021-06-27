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
    public class FeeController : ApiController
    {
        private readonly FeeService feeService;
        public FeeController()
        {
            feeService = new FeeService();
        }
        //get
        [HttpGet]
        [Route("api/fee/viewfees")]
        public HttpResponseMessage ViewFees()
        {
            var entry = feeService.GetAll();

            List<FeeDetails> dto = new List<FeeDetails>();
            foreach (var entries in entry)
            {
                dto.Add(new FeeDetails { FeeId = entries.FeeId, Amount = entries.Amount, DateOfPayment = entries.DateOfPayment, StudentId = entries.StudentId });
            }
            return Request.CreateResponse(HttpStatusCode.OK, dto);

        }
        //add
        [HttpPost]
        public HttpResponseMessage UploadFee(FeeDetails service)
        {
            var entry = feeService.UploadFees(service);
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
        [Route("api/fee/getdetailsbyid/{studentid}")]
        public IHttpActionResult GetDetailsById([FromUri] int studentid)
        {
            if(studentid != 0)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var res = feeService.GetFeeById(studentid);
                if(res != null)
                {
                    return Ok(res);
                }
              
            }
            return NotFound();
        }
    }
}
