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
        JournalCurriculum CreateJournalCurriculum(int time);
        void UpdaterJournalCurriculum(JournalCurriculum journalCurriculum);
        void RemoveJournalCurriculum(JournalCurriculum journalCurriculum);
        JournalCurriculum GetJournalCurriculumById(int journalCurriculumId);
        void SetDisciplineOfJournalCurriculum(int disciplineId);
        void SetFormReportOfJournalCurriculum(int formReportId);
        void SetCurriculumOfJournalCurriculum(int curriculumId);
    }
}
