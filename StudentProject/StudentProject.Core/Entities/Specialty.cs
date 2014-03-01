using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    class Specialty :Entity<int>
    {
        public string Name { get; set; }
        public int TermNumber { get; set; }
    }
}
