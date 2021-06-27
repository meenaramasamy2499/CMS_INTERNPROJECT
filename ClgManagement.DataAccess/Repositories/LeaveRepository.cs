//using ClgManagement.DataAccess.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClgManagement.DataAccess.Repositories
//{
//   public class LeaveRepository
//    {
//        private readonly ClgManagementSystemContext context;
//        public LeaveRepository()
//        {
//            context = new ClgManagementSystemContext();
//        }
//        public int Add(LeaveDetails leavedetails)
//        {
//            context.LeaveDetails.Add(leavedetails);
//            return context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
