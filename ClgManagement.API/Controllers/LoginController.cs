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
    public class LoginController : ApiController
    {
        private readonly LoginService service;

        public LoginController()
        {
            service = new LoginService();
        }

        /// <summary>
        /// Getting value from the Users and check with 
        /// the database
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>

        [HttpPost]
        public IHttpActionResult Login([FromBody] User Users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = service.ValidateCredentials(Users.UserName, Users.Password);

            if (res == null)
                return BadRequest("Invalid Username/Password");
            return Ok(res);

        }
    }

}
