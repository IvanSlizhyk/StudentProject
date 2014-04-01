using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly DbContextTransaction _transaction;
        private bool _isTransactionActive;
        private bool _disposed;
        private IRepositoryGeneric<Student, int> _studetRepository;
        private IRepositoryGeneric<Group, int> _groupRepository;
        private IRepositoryGeneric<Speciality, int> _specialityRepository;
        private IRepositoryGeneric<Progress, int> _progressRepository;
        private IRepositoryGeneric<JournalProgress, int> _journalProgressRepository;
        private IRepositoryGeneric<Curriculum, int> _curriculumRepository;
        private IRepositoryGeneric<JournalCurriculum, int> _journalCurriculumRepository;
        private IRepositoryGeneric<Discipline, int> _disciplineRepository;
        private IRepositoryGeneric<FormEducation, int> _formEducationRepository;
        private IRepositoryGeneric<FormReport, int> _formReportRepository;
        private IRepositoryGeneric<AppraisalFormReport, int> _appraisalFormReportRepository;

        public UnitOfWork(StudentContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
            _isTransactionActive = true;
        }

        public void Commit()
        {
            try
            {
                if (_isTransactionActive && !_disposed)
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
                throw;
            }
        }

        public void Rollback()
        {
            if (_isTransactionActive && !_disposed)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
            }
        }

        public void PreSave()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_isTransactionActive)
            {
                try
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
                catch (Exception e)
                {
                    _transaction.Rollback();
                    _isTransactionActive = false;

                    _context.Dispose();
                    _disposed = true;
                    throw;
                }
            }
            if (_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        public IRepositoryGeneric<Student, int> GetStudentRepository()
        {
            return _studetRepository ?? (_studetRepository = new RepositoryGeneric<Student, int>(_context));
        }

        public IRepositoryGeneric<Group, int> GetGroupRepository()
        {
            return _groupRepository ?? (_groupRepository = new RepositoryGeneric<Group, int>(_context));
        }

        public IRepositoryGeneric<Speciality, int> GetSpecialityRepository()
        {
            return _specialityRepository ?? (_specialityRepository = new RepositoryGeneric<Speciality, int>(_context));
        }

        public IRepositoryGeneric<Curriculum, int> GetCurriculumRepository()
        {
            return _curriculumRepository ?? (_curriculumRepository = new RepositoryGeneric<Curriculum, int>(_context));
        }

        public IRepositoryGeneric<JournalCurriculum, int> GetJournalCurriculumRepository()
        {
            return _journalCurriculumRepository ??
                   (_journalCurriculumRepository = new RepositoryGeneric<JournalCurriculum, int>(_context));
        }

        public IRepositoryGeneric<Progress, int> GetProgressRepository()
        {
            return _progressRepository ?? (_progressRepository = new RepositoryGeneric<Progress, int>(_context));
        }

        public IRepositoryGeneric<JournalProgress, int> GetJournalProgressRepository()
        {
            return _journalProgressRepository ??
                   (_journalProgressRepository = new RepositoryGeneric<JournalProgress, int>(_context));
        }

        public IRepositoryGeneric<FormEducation, int> GetFormEducationRepository()
        {
            return _formEducationRepository ??
                   (_formEducationRepository = new RepositoryGeneric<FormEducation, int>(_context));
        }

        public IRepositoryGeneric<FormReport, int> GetFormReportRepository()
        {
            return _formReportRepository ?? (_formReportRepository = new RepositoryGeneric<FormReport, int>(_context));
        }

        public IRepositoryGeneric<Discipline, int> GetDisciplineRepository()
        {
            return _disciplineRepository ?? (_disciplineRepository = new RepositoryGeneric<Discipline, int>(_context));
        }

        public IRepositoryGeneric<AppraisalFormReport, int> GetAppraisalFormReportRepository()
        {
            return _appraisalFormReportRepository ??
                   (_appraisalFormReportRepository = new RepositoryGeneric<AppraisalFormReport, int>(_context));
        }
    }
}
