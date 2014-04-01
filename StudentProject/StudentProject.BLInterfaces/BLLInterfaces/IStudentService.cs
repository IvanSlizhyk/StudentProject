﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IStudentService : IService
    {
        Student CreateStudent(string name, string surname, string patronymic, string email);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
        Student GetStudentById(int studentId);
        HashSet<Group> GetGroupsOfStudent(int studentId);
        HashSet<Progress> GetProgressesOfStudent(int studentId);
    }
}
