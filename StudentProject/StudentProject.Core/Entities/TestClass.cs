using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public static class TestClass
    {
        public static string Do(this Group group, int i)
        {
            return group.FormationYear + " " + i;
        }
    }
}
