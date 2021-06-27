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
    public class AssignmentService
    {
        private readonly ClgManagementSystemContext context;
        public AssignmentService()
        {

            context = new ClgManagementSystemContext();

        }
        public bool UploadAssignment(Assignment details)
        {
            try
            {
                context.Assignments.Add(details);
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
        public List<Assignment> GetAll()
        {
            try
            {
                var entry = from entries in context.Assignments
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
        public IEnumerable<Assignment> GetAssignmentById(int studentid)
        {
            var Query = from assignment in context.Assignments
                        where assignment.StudentId == studentid
                        select assignment;
            return Query.ToList();
        }

    }
}
