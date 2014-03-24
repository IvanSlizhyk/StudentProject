using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.Core
{
    public class Entity<T> : Entity
    {
        public T Id { get; set; }
    }
}
