﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Core.Entities
{
    public class Discipline : Entity<short>
    {
        public string Name { get; set; }
    }
}