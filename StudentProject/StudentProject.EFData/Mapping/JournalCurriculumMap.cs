using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class JournalCurriculumMap : EntityTypeConfiguration<JournalCurriculum>
    {
        public JournalCurriculumMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Time).IsRequired();
            HasRequired(e => e.Curriculum).WithMany(e => e.JournalCurricula).HasForeignKey(e => e.CurriculumId);
        }
    }
}
