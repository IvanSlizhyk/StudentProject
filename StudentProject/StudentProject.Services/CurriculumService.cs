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
    public class CurriculumService : BaseService, ICurriculumService
    {
        public CurriculumService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public void UpdateCurruculum(Curriculum curriculum)
        {
            var curriculumRepositiry = RepositoryFactory.GetCurriculumRepository();

            try
            {
                curriculumRepositiry.Update(curriculum);
            }
            catch (RepositoryException ex)
            {
                throw new CurriculumServiceException(ex);
            }
        }

        public Curriculum GetCurriculumById(int curriculumId)
        {
            var curriculumRepository = RepositoryFactory.GetCurriculumRepository();

            try
            {
                var currilucum = curriculumRepository.GetEntityById(curriculumId);
                return currilucum;
            }
            catch (RepositoryException ex)
            {
                throw new CurriculumServiceException(ex);
            }
        }

        public Speciality GetSpecialityOfCurruculum(int currliculumId)
        {
            var curriculum = GetCurriculumById(currliculumId);
            return curriculum.Speciality;
        }

        public HashSet<JournalCurriculum> GetJournalCurriculaOfCurriculum(int curriculumId)
        {
            var curriculum = GetCurriculumById(curriculumId);
            return curriculum.JournalCurricula;
        }

        public void AddJournalCurriculumToCurriculum(JournalCurriculum journalCurriculum, Curriculum curriculum)
        {
            try
            {
                curriculum.JournalCurricula.Add(journalCurriculum);
            }
            catch (RepositoryException ex)
            {
                throw new CurriculumServiceException(ex);
            }
        }

        public Curriculum GetCurriculumBySpecialityAndTermNumber(Speciality speciality, int termNumber)
        {
            var curriculumRepository = RepositoryFactory.GetCurriculumRepository();

            try
            {
                var curriculum = curriculumRepository.FindEntity(e => e.SpecialityId == speciality.Id && e.Term == termNumber);
                return curriculum;
            }
            catch (RepositoryException ex)
            {
                throw new CurriculumServiceException(ex);
            }
        }
    }
}
