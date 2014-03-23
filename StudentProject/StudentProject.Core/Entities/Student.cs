using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Student : Entity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public virtual HashSet<Group> Groups{ get; set; }
        public virtual HashSet<Progress> Progresses { get; set; }
    }
}
