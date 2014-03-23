using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Curriculum: Entity<int>
    {
        public virtual int SpecialityId { get; set; }
        public virtual HashSet<JournalCurriculum> JournalCurricula { get; set; }
        public int Term { get; set; }
    }
}
