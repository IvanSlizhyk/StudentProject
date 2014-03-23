using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class JournalProgress: Entity<int>
    {
        public int DidciplineId { get; set; }
        public int AppraisalFormReportId { get; set; }
    }
}
