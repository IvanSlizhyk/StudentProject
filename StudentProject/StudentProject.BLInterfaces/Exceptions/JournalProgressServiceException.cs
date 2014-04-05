using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class JournalProgressServiceException : Exception
    {
        protected JournalProgressServiceException()
        {

        }

        public JournalProgressServiceException(string message)
            : base(message)
        {

        }

        public JournalProgressServiceException(Exception ex)
            : base("See ineer exception", ex)
        {

        }
    }
}
