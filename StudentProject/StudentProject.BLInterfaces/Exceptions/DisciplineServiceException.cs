using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class DisciplineServiceException : Exception
    {
        protected DisciplineServiceException()
        {

        }

        public DisciplineServiceException(string message)
            : base(message)
        {

        }

        public DisciplineServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
