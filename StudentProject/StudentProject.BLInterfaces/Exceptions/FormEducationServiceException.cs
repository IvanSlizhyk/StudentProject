using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class FormEducationServiceException : Exception
    {
        protected FormEducationServiceException()
        {

        }

        public FormEducationServiceException(string message)
            : base(message)
        {

        }

        public FormEducationServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
