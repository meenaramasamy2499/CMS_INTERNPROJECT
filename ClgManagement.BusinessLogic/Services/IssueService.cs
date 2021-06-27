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
    public class IssueService
    {
        private readonly ClgManagementSystemContext context;
        public IssueService()
        {

            context = new ClgManagementSystemContext();

        }
        //raise issue - post method
        public bool RaiseIssue(IssueReport details)
        {
            try
            {
                context.IssueReports.Add(details);
                var entry = context.SaveChanges();
                if (entry == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbException e)
            {
                throw new CollegeManagementSystemException("Error message", e);
            }

        }
        //view issue report - get all method

        public List<IssueReport> GetAll()
        {
            try
            {
                var entry = from entries in context.IssueReports
                            select entries;
                return entry.ToList();
            }
            catch (DbException e)
            {
                throw new CollegeManagementSystemException("Error message", e);
            }
            
        }
        public IEnumerable<IssueReport> GetIssueById(int issueId)
        {
            var Obj = (from users in context.IssueReports
                       where users.UserId == issueId
                       select users);

            return Obj.ToList();
        }

        public bool IsResolved(int ticketId)
        {
            var Obj = context.IssueReports.Find(ticketId);
            if (Obj == null)
                return false;
            else
            {
                if (Obj.IsResolved == false)
                {
                    Obj.IsResolved = true;
                    context.SaveChanges();
                    return true;
                }

                return false;

            }
        }
    }
}
