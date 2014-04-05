using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class AppraisalFormReportServiceException : Exception
    {
        protected AppraisalFormReportServiceException()
        {

        }

        public AppraisalFormReportServiceException(string message)
            : base(message)
        {

        }

        public AppraisalFormReportServiceException(Exception ex)
            : base("See ineer exception", ex)
        {

        }
    }
}
