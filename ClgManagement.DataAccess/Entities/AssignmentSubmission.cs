using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }

        public string Answer { get; set; }

        public DateTime SubmissionDate { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseCode { get; set; }

        public Course Course { get; set; }

    }
}
