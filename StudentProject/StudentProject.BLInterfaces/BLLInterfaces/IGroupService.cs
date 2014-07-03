using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IGroupService : IService
    {
        Group CreateGroup(int groupNumber, int formationYear, Speciality speciality);
        void UpdateGroup(Group group);
        void RemoveGroup(Group group);
        Group GetGroupById(int groupId);
        Group GetGroupByNumber(int groupNumber);
        void AddStudentToGroup(Student student, int groupId);
        void RemoveStudentToGroup(Student student, int groupId);
        HashSet<Student> GetStudentsOfGroup(int groupNumber);
        void SetSpecialityOfGroup(Speciality speciality, Group group);
        IQueryable<Group> GetAllGroups();
    }
}
