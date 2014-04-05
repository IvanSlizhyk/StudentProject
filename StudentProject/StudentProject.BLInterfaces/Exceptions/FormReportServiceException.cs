using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class FormReportServiceException : Exception
    {
        protected FormReportServiceException()
        {

        }

        public FormReportServiceException(string message)
            : base(message)
        {

        }

        public FormReportServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
