using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.BLInterfaces.Exceptions
{
    public class GroupServiceException : Exception
    {
        protected GroupServiceException()
        {

        }

        public GroupServiceException(string message)
            : base(message)
        {

        }

        public GroupServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
