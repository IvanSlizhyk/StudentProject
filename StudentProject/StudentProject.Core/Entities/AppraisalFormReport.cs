using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class AppraisalFormReport : Entity<int>
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
