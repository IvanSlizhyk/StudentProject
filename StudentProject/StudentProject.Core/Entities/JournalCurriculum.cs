using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class JournalCurriculum: Entity<int>
    {
        public int DisciplineId { get; set; }
        public int FormReportId { get; set; }
        public int Time { get; set; }

    }
}
