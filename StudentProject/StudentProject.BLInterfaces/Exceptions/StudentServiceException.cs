using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class StudentServiceException : Exception
    {
        protected StudentServiceException()
        {

        }

        public StudentServiceException(string message)
            : base(message)
        {

        }

        public StudentServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
