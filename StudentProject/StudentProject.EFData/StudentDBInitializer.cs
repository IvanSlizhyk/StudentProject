using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.EFData
{
    public class StudentDbInitializer : DropCreateDatabaseIfModelChanges<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            /*var group1 = new Group { GroupNumber = 110901, FormationYear = 2011 };
            context.Groups.Add(group1);
            context.SaveChanges();
            var student1 = new Student {Name = "Иван", Surname = "Ливанов", Patronymic = "Игоревич", Email = "tr@gmail.com"};
            student1.Groups.Add(group1);
            context.Students.Add(student1);
            context.SaveChanges();
            var student2 = new Student {Name = "Даниил", Surname = "Степанов", Patronymic = "Алексеевич", Email = "fh@gmail.com"};
            student2.Groups.Add(group1);
            context.Students.Add(student2);
            context.SaveChanges();
            var discipline1 = new Discipline {Name = "ОДМ"};
            context.Disciplines.Add(discipline1);
            context.SaveChanges();
            var discipline2 = new Discipline { Name = "ПВиПИ" };
            context.Disciplines.Add(discipline2);
            context.SaveChanges();
            var formReport1 = new FormReport {Name = "экзамен"};
            context.FormReports.Add(formReport1);
            context.SaveChanges();
            var journalCurriculum1 = new JournalCurriculum {Time = 68, Discipline = discipline1, FormReport = formReport1};
            context.JournalCurriculum.Add(journalCurriculum1);
            context.SaveChanges();
            var curriculum1 = new Curriculum { Term = 1 };
            context.Curricula.Add(curriculum1);
            curriculum1.JournalCurricula.Add(journalCurriculum1);
            context.SaveChanges();
            var speciality1 = new Speciality {Name = "ИПОИТ", TermNumber = 10};
            speciality1.Groups.Add(group1);
            speciality1.Curricula.Add(curriculum1);
            context.Specialties.Add(speciality1);
            context.SaveChanges();*/

            base.Seed(context);
        }
    }
}
