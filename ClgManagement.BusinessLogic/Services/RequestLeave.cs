using ClgManagement.BusinessLogic.DTOs;
using ClgManagement.DataAccess;
using ClgManagement.DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic.Services
{
    public class RequestLeave : IDisposable
    {

        private readonly ClgManagementSystemContext context; 

        public RequestLeave()
        {
            context = new ClgManagementSystemContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

      public bool requestingforLeave(LeaveDetails leaveDetails)
        {
            var query = context.LeaveDetails.Add(leaveDetails);
            var res = context.SaveChanges();
            if(res==1)
            {
                return true;
            }
            return false;
        }
        public List<LeaveDetails> GetAll()
        {
            try
            {
                var entry = from entries in context.LeaveDetails
                            select entries;
                return entry.ToList();
            }
            catch (DbException e)
            {
                throw new CollegeManagementSystemException("Error message", e);
            }
            catch (Exception e)
            {
                throw new CollegeManagementSystemException("Unknown error", e);
            }
        }
        public IEnumerable <LeaveDetails> GetUserDetails(int LeaveId)
        {
            var Obj = (from users in context.LeaveDetails
                       where users.UserId == LeaveId
                       select users);

            return Obj.ToList();
        }

        //public LeaveDetails GetLeaveById(int studentId)
        //{
        //    var Obj = (from leave in context.LeaveDetails
        //               where leave.UserId == studentId
        //               select leave).SingleOrDefault();
        //    if (Obj != null)
        //    {
        //        return Obj;
        //    }
        //    return Obj = null;
        //}

        public bool IsApproved (int LeaveDetailsId)
        {
            var Obj = context.LeaveDetails.Find(LeaveDetailsId);
            if (Obj == null)
                return false;
            else
            {
                if (Obj.IsApproved == false)
                {
                    Obj.IsApproved = true;
                    context.SaveChanges();
                    return true;
                }

                return false;

            }
        }
    }
}
