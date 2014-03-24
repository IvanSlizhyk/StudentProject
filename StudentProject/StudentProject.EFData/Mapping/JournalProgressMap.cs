using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class JournalProgressMap : EntityTypeConfiguration<JournalProgress>
    {
        public JournalProgressMap()
        {
            HasKey(e => e.Id);
            HasRequired(e => e.Progress).WithMany(e => e.JournalProgresses).HasForeignKey(e => e.ProgressId);
        }
    }
}
