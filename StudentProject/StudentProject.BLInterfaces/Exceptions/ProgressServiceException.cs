using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class ProgressServiceException : Exception
    {
        protected ProgressServiceException()
        {

        }

        public ProgressServiceException(string message)
            : base(message)
        {

        }

        public ProgressServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
