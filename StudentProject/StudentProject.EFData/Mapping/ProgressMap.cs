using System.Data.Entity.ModelConfiguration;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class ProgressMap : EntityTypeConfiguration<Progress>
    {
        public ProgressMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Term).IsRequired();
            HasMany(e => e.JournalProgresses).WithRequired(e => e.Progress).HasForeignKey(e => e.ProgressId);
            HasRequired(e => e.Student).WithMany(e => e.Progresses).HasForeignKey(e => e.StudentId);
            HasRequired(e => e.Group).WithMany().HasForeignKey(e => e.GroupId);
        }
    }
}
