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
    public class AttendanceService
    {
        private readonly ClgManagementSystemContext context;

        public AttendanceService()
        {
            context = new ClgManagementSystemContext();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetAll()
        {
            try
            {
                var entry = from entries in context.Attendances
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
        public bool AddAttendance(Attendance entries)
        {
            try
            {
                context.Attendances.Add(entries);
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
            catch (Exception e)
            {
                throw new CollegeManagementSystemException("Unknown error", e);
            }
        }
        public IEnumerable<Attendance> GetAttendanceId(int studentid)
        {
            var Query = from attendance in context.Attendances
                        where attendance.StudentId == studentid
                        select attendance;
            return Query.ToList();
        }
    }
}