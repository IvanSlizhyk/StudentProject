using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;
using StudentProject.DALInterfaces;

namespace StudentProject.EFData
{
    public class UnitOfWork : IUnitOfWork, IRepositoryFactory
    {
        private readonly StudentContext _context;
        private IRepository<Student, int> _studetRepository;
        private IRepository<Group, int> _groupRepository;
        private IRepository<Speciality, int> _specialityRepository;
        private IRepository<Progress, int> _progressRepository;
        private IRepository<JournalProgress, int> _journalProgressRepository;
        private IRepository<Curriculum, int> _curriculumRepository;
        private IRepository<JournalCurriculum, int> _journalCurriculumRepository;
        private IRepository<Discipline, int> _disciplineRepository;
        private IRepository<FormEducation, int> _formEducationRepository;
        private IRepository<FormReport, int> _formReportRepository;
        private IRepository<AppraisalFormReport, int> _appraisalFormReportRepository;

        public UnitOfWork(StudentContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            
        }

        public void Rollback()
        {
            
        }

        public void PreSave()
        {
            _context.SaveChanges();
        }

        public IRepository<Student, int> GetStudentRepository()
        {
            return _studetRepository ?? (_studetRepository = new RepositoryGeneric<Student, int>(_context));
        }

        public IRepository<Group, int> GetGroupRepository()
        {
            return _groupRepository ?? (_groupRepository = new RepositoryGeneric<Group, int>(_context));
        }

        public IRepository<Speciality, int> GetSpecialityRepository()
        {
            return _specialityRepository ?? (_specialityRepository = new RepositoryGeneric<Speciality, int>(_context));
        }

        public IRepository<Curriculum, int> GetCurriculumRepository()
        {
            return _curriculumRepository ?? (_curriculumRepository = new RepositoryGeneric<Curriculum, int>(_context));
        }

        public IRepository<JournalCurriculum, int> GetJournalCurriculumRepository()
        {
            return _journalCurriculumRepository ??
                   (_journalCurriculumRepository = new RepositoryGeneric<JournalCurriculum, int>(_context));
        }

        public IRepository<Progress, int> GetProgressRepository()
        {
            return _progressRepository ?? (_progressRepository = new RepositoryGeneric<Progress, int>(_context));
        }

        public IRepository<JournalProgress, int> GetJournalProgressRepository()
        {
            return _journalProgressRepository ??
                   (_journalProgressRepository = new RepositoryGeneric<JournalProgress, int>(_context));
        }

        public IRepository<FormEducation, int> GetFormEducationRepository()
        {
            return _formEducationRepository ??
                   (_formEducationRepository = new RepositoryGeneric<FormEducation, int>(_context));
        }

        public IRepository<FormReport, int> GetFormReportRepository()
        {
            return _formReportRepository ?? (_formReportRepository = new RepositoryGeneric<FormReport, int>(_context));
        }

        public IRepository<Discipline, int> GetDisciplineRepository()
        {
            return _disciplineRepository ?? (_disciplineRepository = new RepositoryGeneric<Discipline, int>(_context));
        }

        public IRepository<AppraisalFormReport, int> GetAppraisalFormReportRepository()
        {
            return _appraisalFormReportRepository ??
                   (_appraisalFormReportRepository = new RepositoryGeneric<AppraisalFormReport, int>(_context));
        }
    }
}
