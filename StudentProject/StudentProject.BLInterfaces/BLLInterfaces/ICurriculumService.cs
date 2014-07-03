using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface ICurriculumService : IService
    {
        void UpdateCurruculum(Curriculum curriculum);
        Curriculum GetCurriculumById(int curriculumId);
        Speciality GetSpecialityOfCurruculum(int currliculumId);
        HashSet<JournalCurriculum> GetJournalCurriculaOfCurriculum(int curriculumId);
        void AddJournalCurriculumToCurriculum(JournalCurriculum journalCurriculum, Curriculum curriculum);
        Curriculum GetCurriculumBySpecialityAndTermNumber(Speciality speciality, int termNumber);
    }
}
