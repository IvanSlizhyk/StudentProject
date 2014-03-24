using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class JournalCurriculum : Entity<int>
    {
        public virtual Curriculum Curriculum { get; set; }
        public int CurriculumId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual FormReport FormReport { get; set; }
        public int Time { get; set; }

    }
}
