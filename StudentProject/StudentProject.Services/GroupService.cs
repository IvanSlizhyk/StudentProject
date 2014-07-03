using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.BLInterfaces.BLLInterfaces;
using StudentProject.BLInterfaces.Exceptions;
using StudentProject.Core;
using StudentProject.Core.Entities;
using StudentProject.DALInterfaces;

namespace StudentProject.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Group CreateGroup(int groupNumber, int formationYear, Speciality speciality)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();
            var group = new Group { GroupNumber = groupNumber, FormationYear = formationYear };
            groupRepository.Create(group);
            this.SetSpecialityOfGroup(speciality, group);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }

            return group;
        }

        public void UpdateGroup(Group group)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                groupRepository.Update(group);
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }

        public void RemoveGroup(Group group)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                groupRepository.Remove(group);
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }

        public Group GetGroupById(int groupId)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                var group = groupRepository.GetEntityById(groupId);
                return group;
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }

        public Group GetGroupByNumber(int groupNumber)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                var group = groupRepository.FindEntity(e => e.GroupNumber == groupNumber);
                return group;
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }

        public IQueryable<Group> GetGroupsByFormationYear(int formationYear)
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                var group = groupRepository.FilterEntities(e => e.FormationYear == formationYear);
                return group;
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }

        public void AddStudentToGroup(Student student, int groupId)
        {
            var group = GetGroupById(groupId);
            group.Students.Add(student);
        }

        public void RemoveStudentToGroup(Student student, int groupId)
        {
            var group = GetGroupById(groupId);
            group.Students.Remove(student);
        }

        public HashSet<Student> GetStudentsOfGroup(int groupNumber)
        {
            var group = GetGroupByNumber(groupNumber);
            return group.Students;
        }

        public void SetSpecialityOfGroup(Speciality speciality, Group group)
        {
            group.Speciality = speciality;
            group.SpecialtyId = speciality.Id;
        }

        public IQueryable<Group> GetAllGroups()
        {
            var groupRepository = RepositoryFactory.GetGroupRepository();

            try
            {
                var group = groupRepository.All();
                return group;
            }
            catch (RepositoryException ex)
            {
                throw new GroupServiceException(ex);
            }
        }
    }
}
