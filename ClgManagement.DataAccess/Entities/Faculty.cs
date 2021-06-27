using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.DataAccess.Entities
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        public string FacultyMail { get; set; }

        public long FacultyMobileNo { get; set; }

        public string FacultyAddress { get; set; }

        public DateTime FacultyDoj { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
