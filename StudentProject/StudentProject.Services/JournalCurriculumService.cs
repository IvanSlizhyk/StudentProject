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
    public class JournalCurriculumService : BaseService, IJournalCurriculumService
    {
        public JournalCurriculumService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public JournalCurriculum CreateJournalCurriculum(int time, Discipline discipline, FormReport formReport, Curriculum curriculum)
        {
            var journalCurriculumRepository = RepositoryFactory.GetJournalCurriculumRepository();
            var journalCurriculum = new JournalCurriculum { Time = time };
            journalCurriculum.Curriculum = curriculum;
            journalCurriculum.CurriculumId = curriculum.Id;
            this.SetDisciplineOfJournalCurriculum(discipline, journalCurriculum);
            this.SetFormReportOfJournalCurriculum(formReport, journalCurriculum);
            journalCurriculumRepository.Create(journalCurriculum);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new JournalCurriculumServiceException(ex);
            }

            return journalCurriculum;
        }

        public void UpdaterJournalCurriculum(JournalCurriculum journalCurriculum)
        {
            var journalCurricukumRepository = RepositoryFactory.GetJournalCurriculumRepository();

            try
            {
                journalCurricukumRepository.Update(journalCurriculum);
            }
            catch (RepositoryException ex)
            {
                throw new JournalCurriculumServiceException(ex);
            }
        }

        public void RemoveJournalCurriculum(JournalCurriculum journalCurriculum)
        {
            var journalCurriculumRepository = RepositoryFactory.GetJournalCurriculumRepository();

            try
            {
                journalCurriculumRepository.Remove(journalCurriculum);
            }
            catch (RepositoryException ex)
            {
                throw new JournalCurriculumServiceException(ex);
            }
        }

        public JournalCurriculum GetJournalCurriculumById(int journalCurriculumId)
        {
            var journalCurriculumRepository = RepositoryFactory.GetJournalCurriculumRepository();

            try
            {
                var journalCurriculum = journalCurriculumRepository.GetEntityById(journalCurriculumId);
                return journalCurriculum;
            }
            catch (RepositoryException ex)
            {
                throw new JournalCurriculumServiceException(ex);
            }
        }

        public void SetDisciplineOfJournalCurriculum(Discipline discipline, JournalCurriculum journalCurriculum)
        {
            journalCurriculum.Discipline = discipline;
        }

        public void SetFormReportOfJournalCurriculum(FormReport formReport, JournalCurriculum journalCurriculum)
        {
            journalCurriculum.FormReport = formReport;
        }
    }
}
