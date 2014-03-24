using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    class SpecialityMap : EntityTypeConfiguration<Speciality>
    {
        public SpecialityMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(30);
            Property(e => e.TermNumber).IsRequired();
            HasMany(e => e.Groups).WithRequired(e => e.Speciality).HasForeignKey(e => e.SpecialtyId);
            HasMany(e => e.Curricula).WithRequired(e => e.Speciality).HasForeignKey(e=>e.SpecialityId);
        }
    }
}
