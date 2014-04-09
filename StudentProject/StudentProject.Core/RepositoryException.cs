using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core
{
    public class RepositoryException : Exception
    {
        protected RepositoryException()
        {

        }

        public RepositoryException(string message)
            : base(message)
        {

        }

        public RepositoryException(Exception ex)
            : base("See innner exception", ex)
        {

        }
    }
}
