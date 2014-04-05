using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class SpecialityServiceException : Exception
    {
        protected SpecialityServiceException()
        {

        }

        public SpecialityServiceException(string message)
            : base(message)
        {

        }

        public SpecialityServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
