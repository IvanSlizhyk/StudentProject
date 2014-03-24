using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.EFData
{
    public class BaseRepository
    {
        protected StudentContext Context;

        public BaseRepository(StudentContext context)
        {
            Context = context;
        }
    }
}
