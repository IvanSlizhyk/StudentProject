using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Specialty :Entity<int>
    {
        public string Name { get; set; }
        public int TermNumber { get; set; }
        public virtual HashSet<Group> Groups { get; set; }
        public virtual int FormEducationId { get; set; }
        public virtual HashSet<Curriculum> Curricula { get; set; }

    }
}
