using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using StudentProject.BLInterfaces.BLLInterfaces;
using StudentProject.BLInterfaces.Exceptions;
using StudentProject.Core;
using StudentProject.Core.Entities;
using StudentProject.DALInterfaces;

namespace StudentProject.Services
{
    public class SpecialityService : BaseService, ISpecialityService
    {
        public SpecialityService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Speciality CreateSpeciality(string name, int termNumber, FormEducation formEducation)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();
            var curriculumRepository = RepositoryFactory.GetCurriculumRepository();
            var speciality = new Speciality { Name = name, TermNumber = termNumber };
            specialityRepository.Create(speciality);
            this.SetFormEducationOfSpeciality(formEducation,speciality);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }

            for (var i = 0; i < speciality.TermNumber; i++)
            {
                var curriculum = new Curriculum { Term = i + 1, Speciality = speciality, SpecialityId = speciality.Id };
                curriculumRepository.Create(curriculum);
            }

            return speciality;
        }

        public void UpdateSpeciality(Speciality speciality)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();

            try
            {
                specialityRepository.Update(speciality);
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }
        }

        public void RemoveSpeciality(Speciality speciality)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();
            var curriculumRepository = RepositoryFactory.GetCurriculumRepository();

            for (var i = 1; i <= speciality.TermNumber; i++)
            {
                var i1 = i;
                var cur = curriculumRepository.FindEntity(e => e.SpecialityId == speciality.Id && e.Term==i1);
                curriculumRepository.Remove(cur);
            }
         
            try
            {
                specialityRepository.Remove(speciality);
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }
        }

        public Speciality GetSpecialityById(int specialityId)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();

            try
            {
                var speciality = specialityRepository.GetEntityById(specialityId);
                return speciality;
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }
        }

        public IQueryable<Speciality> GetSpecialitiesByName(string name)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();

            try
            {
                var speciality = specialityRepository.FilterEntities(e => e.Name == name);
                return speciality;
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }
        }

        public IQueryable<Speciality> GetSpecialitiesByFormEducation(int formEducationId)
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();

            try
            {
                var speciality = specialityRepository.FilterEntities(e => e.FormEducationId == formEducationId);
                return speciality;
            }
            catch (RepositoryException ex)
            {
                throw new SpecialityServiceException(ex);
            }
        }

        public void SetFormEducationOfSpeciality(FormEducation formEducation, Speciality speciality)
        {
            speciality.FormEducation = formEducation;
        }

        public HashSet<Group> GetGroupsOfSpeciality(int specialityId)
        {
            var speciality = GetSpecialityById(specialityId);
            return speciality.Groups;
        }

        public HashSet<Curriculum> GetCurriculaOfSpeciality(int specialityId)
        {
            var speciality = GetSpecialityById(specialityId);
            return speciality.Curricula;
        }

        public IQueryable<Speciality> GetAllSpeciality()
        {
            var specialityRepository = RepositoryFactory.GetSpecialityRepository();

            try
            {
                var speciality = specialityRepository.All();
                return speciality;
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }
    }
}
