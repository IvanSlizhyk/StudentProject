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
    public class AppraisalFormReportService : BaseService, IAppraisalFormReportService
    {
        public AppraisalFormReportService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public AppraisalFormReport CreateAppraisalFormReport(string value)
        {
            var appraisalFormReportRepository = RepositoryFactory.GetAppraisalFormReportRepository();
            var appraisalFormReport = new AppraisalFormReport { Value = value };
            appraisalFormReportRepository.Create(appraisalFormReport);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (RepositoryException ex)
            {
                throw new AppraisalFormReportServiceException(ex);
            }

            return appraisalFormReport;
        }

        public void UpdateAppraisalFormReport(AppraisalFormReport appraisalFormReport)
        {
            var appraisalFormReportRepository = RepositoryFactory.GetAppraisalFormReportRepository();

            try
            {
                appraisalFormReportRepository.Update(appraisalFormReport);
            }
            catch (RepositoryException ex)
            {
                throw new AppraisalFormReportServiceException(ex);
            }
        }

        public void RemoveAppraisalFormReport(AppraisalFormReport appraisalFormReport)
        {
            var appraisalFormReportRepository = RepositoryFactory.GetAppraisalFormReportRepository();

            try
            {
                appraisalFormReportRepository.Remove(appraisalFormReport);
            }
            catch (RepositoryException ex)
            {
                throw new AppraisalFormReportServiceException(ex);
            }
        }

        public AppraisalFormReport GetAppraisalFormReportById(int appraisalFormReportId)
        {
            var appraisalFormReportRepository = RepositoryFactory.GetAppraisalFormReportRepository();

            try
            {
                var appraisalFormReport = appraisalFormReportRepository.GetEntityById(appraisalFormReportId);
                return appraisalFormReport;
            }
            catch (RepositoryException ex)
            {
                throw new AppraisalFormReportServiceException(ex);
            }
        }

        public AppraisalFormReport GetAppraisalFormReportByValue(string value)
        {
            var appraisalFormReportRepository = RepositoryFactory.GetAppraisalFormReportRepository();

            try
            {
                var appraisalFormReport = appraisalFormReportRepository.FindEntity(e => e.Value == value);
                return appraisalFormReport;
            }
            catch (RepositoryException ex)
            {
                throw new AppraisalFormReportServiceException(ex);
            }
        }
    }
}
