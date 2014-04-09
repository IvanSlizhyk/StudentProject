using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IJournalCurriculumService : IService
    {
        JournalCurriculum CreateJournalCurriculum(int time, Discipline discipline, FormReport formReport, Curriculum curriculum);
        void UpdaterJournalCurriculum(JournalCurriculum journalCurriculum);
        void RemoveJournalCurriculum(JournalCurriculum journalCurriculum);
        JournalCurriculum GetJournalCurriculumById(int journalCurriculumId);
        void SetDisciplineOfJournalCurriculum(Discipline discipline, JournalCurriculum journalCurriculum);
        void SetFormReportOfJournalCurriculum(FormReport formReport, JournalCurriculum journalCurriculum);
    }
}
