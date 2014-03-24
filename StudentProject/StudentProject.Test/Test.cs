using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using StudentProject.Core.Entities;
using StudentProject.EFData;

namespace StudentProject.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void FirstTest()
        {
            Database.SetInitializer(new StudentDbInitializer());
            var context = new StudentContext("Test");
            var student = new Student { Email = "ef", Name = "wef", Patronymic = "wef", Surname = "wegw" };
            var student1 = new Student { Email = "ef", Name = "wef", Patronymic = "wef", Surname = "wegw" };
            context.Students.Add(student);
            context.Students.Add(student1);
            context.SaveChanges();

            var progress = new Progress { Term = 1 };
            context.Progresses.Add(progress);
            progress.Student = student1;
            context.SaveChanges();

            context.Dispose();
        }
    }
}
