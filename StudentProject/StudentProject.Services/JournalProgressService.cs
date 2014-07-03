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
    public class JournalProgressService : BaseService, IJournalProgressService
    {
        public JournalProgressService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public JournalProgress CreateJournalProgress(Progress progress, JournalCurriculum journalCurriculum, AppraisalFormReport appraisalFormReport)
        {
            var journalProgressRepository = RepositoryFactory.GetJournalProgressRepository();
            var journalProgress = new JournalProgress { };
            SetAppraisalFormReportOfJournalProgress(appraisalFormReport, journalProgress);
            SetJournalCurriculumOfJournalProgress(journalCurriculum, journalProgress);
            SetProgressOfJournalProgress(progress, journalProgress);
            journalProgressRepository.Create(journalProgress);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new JournalProgressServiceException(ex);
            }

            return journalProgress;
        }

        public void UpdateJournalProgress(JournalProgress journalProgress)
        {
            var journalProgressRepository = RepositoryFactory.GetJournalProgressRepository();

            try
            {
                journalProgressRepository.Update(journalProgress);
            }
            catch (RepositoryException ex)
            {
                throw new JournalProgressServiceException(ex);
            }
        }

        public void RemoveJournalProgress(JournalProgress journalProgress)
        {
            var journalProgressRepository = RepositoryFactory.GetJournalProgressRepository();

            try
            {
                journalProgressRepository.Remove(journalProgress);
            }
            catch (RepositoryException ex)
            {
                throw new JournalProgressServiceException(ex);
            }
        }

        public JournalProgress GetJournalProgressById(int journalProgressId)
        {
            var journalProgressRepository = RepositoryFactory.GetJournalProgressRepository();

            try
            {
                var journalProgress = journalProgressRepository.GetEntityById(journalProgressId);
                return journalProgress;
            }
            catch (RepositoryException ex)
            {
                throw new JournalProgressServiceException(ex);
            }
        }

        public void SetAppraisalFormReportOfJournalProgress(AppraisalFormReport appraisalFormReport, JournalProgress journalProgress)
        {
            journalProgress.AppraisalFormReport = appraisalFormReport;
        }

        public void SetProgressOfJournalProgress(Progress progress, JournalProgress journalProgress)
        {
            journalProgress.Progress = progress;
            journalProgress.ProgressId = progress.Id;
        }

        public void SetJournalCurriculumOfJournalProgress(JournalCurriculum journalCurriculum, JournalProgress journalProgress)
        {
            journalProgress.JournalCurriculum = journalCurriculum;
            journalProgress.JournalCurriculumId = journalCurriculum.Id;
        }
    }
}
