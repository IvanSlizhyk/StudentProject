using System.Data.Entity.ModelConfiguration;
using StudentProject.Core.Entities;

namespace StudentProject.EFData.Mapping
{
    internal class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            HasKey(e => e.Id);
            Property(e => e.GroupNumber).IsRequired();
            Property(e => e.FormationYear).IsRequired();
            HasMany(e => e.Students).WithMany(e => e.Groups);
            HasRequired(e => e.Speciality).WithMany(e => e.Groups).HasForeignKey(e => e.SpecialtyId);
        }
    }
}
