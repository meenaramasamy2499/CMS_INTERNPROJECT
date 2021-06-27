using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic.DTOs
{
    public class LeaveDetailsDto
    {
        public int LeaveDetailsId { get; set; }

        public string Reason { get; set; }

        public DateTime DateOfLeave { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }
    }
}
