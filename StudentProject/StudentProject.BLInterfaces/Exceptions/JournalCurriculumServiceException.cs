using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class JournalCurriculumServiceException : Exception
    {
        protected JournalCurriculumServiceException()
        {

        }

        public JournalCurriculumServiceException(string message)
            : base(message)
        {

        }

        public JournalCurriculumServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
