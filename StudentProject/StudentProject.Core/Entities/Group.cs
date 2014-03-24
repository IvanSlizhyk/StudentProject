using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Group : Entity<int>
    {
        public int GroupNumber { get; set; }
        public int FormationYear { get; set; }
        public virtual HashSet<Student> Students { get; set; }
        public int SpecialtyId { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
