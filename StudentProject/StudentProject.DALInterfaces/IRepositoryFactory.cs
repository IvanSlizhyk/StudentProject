using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.DALInterfaces
{
    public interface IRepositoryFactory
    {
        IRepositoryGeneric<Student, int> GetStudentRepository();
        IRepositoryGeneric<Group, int> GetGroupRepository();
        IRepositoryGeneric<Speciality, int> GetSpecialityRepository();
        IRepositoryGeneric<Curriculum, int> GetCurriculumRepository();
        IRepositoryGeneric<JournalCurriculum, int> GetJournalCurriculumRepository();
        IRepositoryGeneric<Progress, int> GetProgressRepository();
        IRepositoryGeneric<JournalProgress, int> GetJournalProgressRepository();
        IRepositoryGeneric<FormEducation, int> GetFormEducationRepository();
        IRepositoryGeneric<FormReport, int> GetFormReportRepository();
        IRepositoryGeneric<Discipline, int> GetDisciplineRepository();
        IRepositoryGeneric<AppraisalFormReport, int> GetAppraisalFormReportRepository();
    }
}
