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
    public class FeeService
    {
        private readonly ClgManagementSystemContext context;
        public FeeService()
        {

            context = new ClgManagementSystemContext();

        }
        //upload fees - post method
        public bool UploadFees(FeeDetails details)
        {
            try
            {
                context.FeeDetails.Add(details);
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

        public IEnumerable <FeeDetails> GetFeeById(int studentid)
        {
            var res = (from obj in context.FeeDetails
                       where obj.StudentId == studentid
                       select obj);
            
            return res.ToList();
        }
        // fee report - get all method

        public List<FeeDetails> GetAll()
        {
            try
            {
                var entry = from entries in context.FeeDetails
                            select entries;
                return entry.ToList();
            }
            catch (DbException e)
            {
                throw new CollegeManagementSystemException("Error message", e);
            }

        }
    }
}
