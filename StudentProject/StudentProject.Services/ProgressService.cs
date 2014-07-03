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
    public class ProgressService : BaseService, IProgressService
    {
        public ProgressService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public void UpdateProgress(Progress progress)
        {
            var progressRepository = RepositoryFactory.GetProgressRepository();

            try
            {
                progressRepository.Update(progress);
            }
            catch (RepositoryException ex)
            {
                throw new ProgressServiceException(ex);
            }
        }

        public void RemoveProgress(Progress progress)
        {
            var progressRepository = RepositoryFactory.GetProgressRepository();

            try
            {
                progressRepository.Remove(progress);
            }
            catch (RepositoryException ex)
            {
                throw new ProgressServiceException(ex);
            }
        }

        public Progress GetProgressById(int progressId)
        {
            var progressRepository = RepositoryFactory.GetProgressRepository();

            try
            {
                var progress = progressRepository.GetEntityById(progressId);
                return progress;
            }
            catch (RepositoryException ex)
            {
                throw new ProgressServiceException(ex);
            }
        }

        public void SetStudentOfProgress(Student student, int progressId)
        {
            var progress = GetProgressById(progressId);
            progress.Student = student;
            progress.StudentId = student.Id;
        }

        public HashSet<JournalProgress> GetJournalProgressesOfProgresses(int progressId)
        {
            var progress = GetProgressById(progressId);
            return progress.JournalProgresses;
        }

        public Progress GetProgressByGroupAndStudentAndTermNumber(Group group, Student student, int termNumber)
        {
            var progressRepository = RepositoryFactory.GetProgressRepository();

            try
            {
                var progress = progressRepository.FindEntity(e => e.GroupId == group.Id && e.Term == termNumber && e.StudentId == student.Id);
                return progress;
            }
            catch (RepositoryException ex)
            {
                throw new CurriculumServiceException(ex);
            }
        }
    }
}
