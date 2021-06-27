using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClgManagement.BusinessLogic
{
    public class CollegeManagementSystemException : Exception
    {
        public CollegeManagementSystemException() : base() { }

        public CollegeManagementSystemException(string message) : base(message) { }

        public CollegeManagementSystemException(string message, Exception innerException) : base(message, innerException) { }

    }
}
