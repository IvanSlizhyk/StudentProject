using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.BLInterfaces.BLLInterfaces;
using StudentProject.BLInterfaces.Exceptions;
using StudentProject.Core;
using StudentProject.Core.Entities;
using StudentProject.DALInterfaces;

namespace StudentProject.Services
{
    public class FormEducationService : BaseService, IFormEducationService
    {
        public FormEducationService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public FormEducation CreateFormEducation(string name)
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();
            var formEducation = new FormEducation { Name = name };
            formEducationRepository.Create(formEducation);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }

            return formEducation;
        }

        public void UpdateFormEducation(FormEducation formEducation)
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();

            try
            {
                formEducationRepository.Update(formEducation);
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }

        public void RemoveFormEducation(FormEducation formEducation)
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();

            try
            {
                formEducationRepository.Remove(formEducation);
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }

        public FormEducation GetFormEducationById(int formEducationId)
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();

            try
            {
                var formEducation = formEducationRepository.GetEntityById(formEducationId);
                return formEducation;
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }

        public FormEducation GetFormEducationByName(string name)
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();

            try
            {
                var formEducation = formEducationRepository.FindEntity(e => e.Name == name);
                return formEducation;
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }

        public IQueryable<FormEducation> GetAllFormEducation()
        {
            var formEducationRepository = RepositoryFactory.GetFormEducationRepository();

            try
            {
                var formEducation = formEducationRepository.All();
                return formEducation;
            }
            catch (RepositoryException ex)
            {
                throw new FormEducationServiceException(ex);
            }
        }
    }
}
