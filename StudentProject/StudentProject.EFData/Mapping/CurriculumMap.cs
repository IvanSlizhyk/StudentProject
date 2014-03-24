using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class CurriculumMap : EntityTypeConfiguration<Curriculum>
    {
        public CurriculumMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Term).IsRequired();
            HasMany(e => e.JournalCurricula).WithRequired(e => e.Curriculum).HasForeignKey(e => e.CurriculumId);
            HasRequired(e => e.Speciality).WithMany(e => e.Curricula).HasForeignKey(e => e.SpecialityId);
        }
    }
}
