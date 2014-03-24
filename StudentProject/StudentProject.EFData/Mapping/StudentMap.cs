using System.Data.Entity.ModelConfiguration;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(30);
            Property(e => e.Surname).IsRequired().HasMaxLength(30);
            Property(e => e.Patronymic).IsRequired().HasMaxLength(30);
            Property(e => e.Email).IsRequired().HasMaxLength(30);
            HasMany(e => e.Groups).WithMany(e => e.Students);
            HasMany(e => e.Progresses).WithRequired(e => e.Student).HasForeignKey(e => e.StudentId);
        }
    }
}
