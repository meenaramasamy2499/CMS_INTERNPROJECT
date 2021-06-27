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
    public class CalendarService
    {
        private readonly ClgManagementSystemContext context;

        public CalendarService()
        {

            context = new ClgManagementSystemContext();

        }

        public List<Calendar> GetAll()
        {
            try
            {
                var entry = from entries in context.Calendars
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
        public bool AddCalendar(Calendar entries)
        {
            try
            {
                context.Calendars.Add(entries);
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
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
