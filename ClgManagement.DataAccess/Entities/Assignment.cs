using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public string Question { get; set; }

        public DateTime SubmissionTime { get; set; }

        [ForeignKey("Course")]
        public int CourseCode { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
