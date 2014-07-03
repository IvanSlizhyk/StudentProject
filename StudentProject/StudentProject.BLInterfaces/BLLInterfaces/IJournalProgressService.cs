using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IJournalProgressService : IService
    {
        JournalProgress CreateJournalProgress(Progress progress, JournalCurriculum journalCurriculum, AppraisalFormReport appraisalFormReport);
        void UpdateJournalProgress(JournalProgress journalProgress);
        void RemoveJournalProgress(JournalProgress journalProgress);
        JournalProgress GetJournalProgressById(int journalProgressId);
        void SetAppraisalFormReportOfJournalProgress(AppraisalFormReport appraisalFormReport, JournalProgress journalProgress);
        void SetProgressOfJournalProgress(Progress progress, JournalProgress journalProgress);
        void SetJournalCurriculumOfJournalProgress(JournalCurriculum journalCurriculum, JournalProgress journalProgress);
    }
}
