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
        IRepository<Student, int> GetStudentRepository();
        IRepository<Group, int> GetGroupRepository();
        IRepository<Speciality, int> GetSpecialityRepository();
        IRepository<Curriculum, int> GetCurriculumRepository();
        IRepository<JournalCurriculum, int> GetJournalCurriculumRepository();
        IRepository<Progress, int> GetProgressRepository();
        IRepository<JournalProgress, int> GetJournalProgressRepository();
        IRepository<FormEducation, int> GetFormEducationRepository();
        IRepository<FormReport, int> GetFormReportRepository();
        IRepository<Discipline, int> GetDisciplineRepository();
        IRepository<AppraisalFormReport, int> GetAppraisalFormReportRepository();
    }
}
