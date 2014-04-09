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
    public class FormReportService : BaseService, IFormReportService
    {
        public FormReportService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public FormReport CreateFormReport(string name)
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();
            var formReport = new FormReport { Name = name };
            formReportRepository.Create(formReport);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }

            return formReport;
        }

        public void UpdateFormReport(FormReport formReport)
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();

            try
            {
                formReportRepository.Update(formReport);
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }
        }

        public void RemoveFormReport(FormReport formReport)
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();

            try
            {
                formReportRepository.Remove(formReport);
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }
        }

        public FormReport GetFormReportById(int formReportId)
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();

            try
            {
                var formReport = formReportRepository.GetEntityById(formReportId);
                return formReport;
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }
        }

        public FormReport GetFormReportByName(string name)
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();

            try
            {
                var formReport = formReportRepository.FindEntity(e => e.Name == name);
                return formReport;
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }
        }

        public IQueryable<FormReport> GetAllFormReport()
        {
            var formReportRepository = RepositoryFactory.GetFormReportRepository();

            try
            {
                var formReport = formReportRepository.All();
                return formReport;
            }
            catch (RepositoryException ex)
            {
                throw new FormReportServiceException(ex);
            }
        }
    }
}
