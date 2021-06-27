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
    public class SubmissionService
    {
        private readonly ClgManagementSystemContext context;
        public SubmissionService()
        {

            context = new ClgManagementSystemContext();

        }
        public bool UploadAssignment(AssignmentSubmission details)
        {
            try
            {
                context.AssignmentSubmissions.Add(details);
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
        public List<AssignmentSubmission> GetAll()
        {
            try
            {
                var entry = from entries in context.AssignmentSubmissions
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
    }
}
