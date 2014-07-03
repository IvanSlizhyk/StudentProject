using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IDisciplineService : IService
    {
        Discipline CreatDiscipline(string name);
        void UpdateDiscipline(Discipline discipline);
        void RemoveDiscipline(Discipline discipline);
        Discipline GetDisciplineById(int disciplineId);
        Discipline GetDisciplineByName(string name);
        IQueryable<Discipline> GetAllDiscipline();
    }
}
