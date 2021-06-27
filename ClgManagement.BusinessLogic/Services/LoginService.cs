using ClgManagement.DataAccess;
using ClgManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic.Services
{
    /// <summary>
    /// login service will validate credentials for exisiting users
    /// </summary>
    public class LoginService
    {
      
            private readonly ClgManagementSystemContext context;
            public LoginService()
            {
                context = new ClgManagementSystemContext();
            }
            public User ValidateCredentials(string username, string password)
            {
            //return context.Users.Any(user => user.UserName.Equals(username) && user.Password.Equals(password));
               var query = (from user in context.Users
                            where user.UserName == username && user.Password == password
                            select user).SingleOrDefault();

            if(query!=null)
            {
                return query;
            }
               return query = null;
            }
            public int GetUserId(string username)
            {
                return context.Users.Single(user => user.UserName.Equals(username)).UserId;
            }

    }

}

