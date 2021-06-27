using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class Calendar
    {
        [Key]
        public int CalendarId { get; set; }

        public DateTime DateOfEdit { get; set; }

        public string Status { get; set; }

        public string Reason { get; set; }
    }
}
