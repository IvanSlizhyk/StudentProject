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
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Student CreateStudent(string name, string surname, string patronymic, string email)
        {
            var studentRepository = RepositoryFactory.GetStudentRepository();
            var student = new Student { Name = name, Surname = surname, Patronymic = patronymic, Email = email };
            studentRepository.Create(student);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }

            return student;
        }

        public void UpdateStudent(Student student)
        {
            var studentRepository = RepositoryFactory.GetStudentRepository();

            try
            {
                studentRepository.Update(student);
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }
        }

        public void RemoveStudent(Student student)
        {
            var studentRepository = RepositoryFactory.GetStudentRepository();

            try
            {
                studentRepository.Remove(student);
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }
        }

        public Student GetStudentById(int studentId)
        {
            var studetnRepository = RepositoryFactory.GetStudentRepository();

            try
            {
                var student = studetnRepository.GetEntityById(studentId);
                return student;
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }
        }

        public HashSet<Group> GetGroupsOfStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            return student.Groups;
        }

        public HashSet<Progress> GetProgressesOfStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            return student.Progresses;
        }

        public IQueryable<Student> GetStudentsBySurname(string surname)
        {
            var studentRepository = RepositoryFactory.GetStudentRepository();

            try
            {
                var student = studentRepository.FilterEntities(e => e.Surname == surname);
                return student;
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }
        }

        public IQueryable<Student> GetStudentsByEmail(string email)
        {
            var studentRepository = RepositoryFactory.GetStudentRepository();

            try
            {
                var student = studentRepository.FilterEntities(e => e.Email == email);
                return student;
            }
            catch (RepositoryException ex)
            {
                throw new StudentServiceException(ex);
            }
        }
    }
}
