using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class CurriculumServiceException : Exception
    {
        protected CurriculumServiceException()
        {

        }

        public CurriculumServiceException(string message)
            : base(message)
        {

        }

        public CurriculumServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
