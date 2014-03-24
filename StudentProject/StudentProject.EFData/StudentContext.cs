using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;
using StudentProject.EFData.Mapping;

namespace StudentProject.EFData
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Speciality> Specialties { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<JournalCurriculum> JournalCurriculum { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<JournalProgress> JournalProgresses { get; set; }
        public DbSet<FormEducation> FormEducations { get; set; }
        public DbSet<FormReport> FormReports { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<AppraisalFormReport> AppraisalFormReports { get; set; }

        public StudentContext(string connectionStringName)
            : base(connectionStringName)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SpecialityMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new ProgressMap());
            modelBuilder.Configurations.Add(new JournalProgressMap());
            modelBuilder.Configurations.Add(new CurriculumMap());
            modelBuilder.Configurations.Add(new JournalCurriculumMap());
            modelBuilder.Configurations.Add(new FormEducationMap());
            modelBuilder.Configurations.Add(new FormReportMap());
            modelBuilder.Configurations.Add(new AppraisalFormReportMap());
            modelBuilder.Configurations.Add(new DisciplineMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
