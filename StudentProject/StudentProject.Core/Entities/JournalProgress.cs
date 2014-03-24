using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class JournalProgress : Entity<int>
    {
        public virtual Progress Progress { get; set; }
        public int ProgressId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual AppraisalFormReport AppraisalFormReport { get; set; }
    }
}
