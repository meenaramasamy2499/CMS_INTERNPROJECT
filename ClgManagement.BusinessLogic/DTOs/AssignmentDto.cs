using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic.DTOs
{
    public class AssignmentDto
    {
        public int AssignmentId { get; set; }

        public string Question { get; set; }

        public string Link { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int CourseCode { get; set; }
       
        public int StudentId { get; set; }
       
    }
}
