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
    public class DisciplineService : BaseService, IDisciplineService
    {
        public DisciplineService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Discipline CreatDiscipline(string name)
        {
            var disciplineReposiroty = RepositoryFactory.GetDisciplineRepository();
            var discipline = new Discipline { Name = name };
            disciplineReposiroty.Create(discipline);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }

            return discipline;
        }

        public void UpdateDiscipline(Discipline discipline)
        {
            var disciplineRepository = RepositoryFactory.GetDisciplineRepository();

            try
            {
                disciplineRepository.Update(discipline);
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            var disciplineRepository = RepositoryFactory.GetDisciplineRepository();

            try
            {
                disciplineRepository.Remove(discipline);
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }
        }

        public Discipline GetDisciplineById(int disciplineId)
        {
            var disciplineRepository = RepositoryFactory.GetDisciplineRepository();

            try
            {
                var discipline = disciplineRepository.GetEntityById(disciplineId);
                return discipline;
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }
        }

        public Discipline GetDisciplineByName(string name)
        {
            var disciplineRepository = RepositoryFactory.GetDisciplineRepository();

            try
            {
                var discipline = disciplineRepository.FindEntity(e => e.Name == name);
                return discipline;
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }
        }

        public IQueryable<Discipline> GetAllDiscipline()
        {
            var disciplineRepository = RepositoryFactory.GetDisciplineRepository();

            try
            {
                var discipline = disciplineRepository.All();
                return discipline;
            }
            catch (RepositoryException ex)
            {
                throw new DisciplineServiceException(ex);
            }
        }
    }
}
