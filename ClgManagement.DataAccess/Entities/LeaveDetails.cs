using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class LeaveDetails
    {
        [Key]
        public int LeaveDetailsId { get; set; }

        public string Reason { get; set; }

        public DateTime DateOfLeave { get; set; }

        public bool IsApproved { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
