using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic.DTOs
{
    public class CalendarDto
    {
        public int CalendarId { get; set; }

        public DateTime DateOfEdit { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }
    }
}
