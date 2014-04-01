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
        Speciality CreateSpeciality(string name, int termNumber);
        void UpdateSpeciality(Speciality speciality);
        void RemoveSpeciality(Speciality speciality);
        Speciality GetSpecialityById(int specialityId);
        void SetFormEducationOfSpeciality(int formEducationId);
        HashSet<Group> GetGroupsOfSpeciality(int specialityId);
        HashSet<Curriculum> GetCurriculaOfSpeciality(int curriculumId);

    }
}
