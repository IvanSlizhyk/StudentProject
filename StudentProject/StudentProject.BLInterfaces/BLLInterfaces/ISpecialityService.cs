using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface ISpecialityService : IService
    {
        Speciality CreateSpeciality(string name, int termNumber, FormEducation formEducation);
        void UpdateSpeciality(Speciality speciality);
        void RemoveSpeciality(Speciality speciality);
        Speciality GetSpecialityById(int specialityId);
        void SetFormEducationOfSpeciality(FormEducation formEducation, Speciality speciality);
        HashSet<Group> GetGroupsOfSpeciality(int specialityId);
        HashSet<Curriculum> GetCurriculaOfSpeciality(int specialityId);
        IQueryable<Speciality> GetSpecialitiesByName(string name);
        IQueryable<Speciality> GetSpecialitiesByFormEducation(int formEducationId);
        IQueryable<Speciality> GetAllSpeciality();
    }
}
