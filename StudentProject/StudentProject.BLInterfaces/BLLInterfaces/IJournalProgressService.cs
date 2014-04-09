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
        JournalProgress CreateJournalProgress();
        void UpdateJournalProgress(JournalProgress journalProgress);
        void RemoveJournalProgress(JournalProgress journalProgress);
        JournalProgress GetJournalProgressById(int journalProgressId);
        void SetDisciplineOfJournalProgress(Discipline discipline, int journalProgressId);
        void SetAppraisalFormReportOfJournalProgress(AppraisalFormReport appraisalFormReport, int journalProgressId);
        void SetProgressOfJournalProgress(Progress progress, int journalProgressId);
    }
}
