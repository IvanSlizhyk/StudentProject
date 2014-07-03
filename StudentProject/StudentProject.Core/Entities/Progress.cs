using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Progress : Entity<int>
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }
        public virtual HashSet<JournalProgress> JournalProgresses { get; set; }
        public int Term { get; set; }
    }
}
