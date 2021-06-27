using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(20)]
        public string StudentDepartment { get; set; }

        public string CourseName { get; set; }

        public string StudentMail { get; set; }

        public long StudentMobile { get; set; }

        [MaxLength(50)]
        public string StudentAddress { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

       
    }
}
