using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class FormEducationMap : EntityTypeConfiguration<FormEducation>
    {
        public FormEducationMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(30);
        }
    }
}
