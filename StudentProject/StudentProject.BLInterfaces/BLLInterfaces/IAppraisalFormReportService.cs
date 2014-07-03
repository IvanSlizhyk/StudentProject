using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IAppraisalFormReportService : IService
    {
        AppraisalFormReport CreateAppraisalFormReport(string value);
        void UpdateAppraisalFormReport(AppraisalFormReport appraisalFormReport);
        void RemoveAppraisalFormReport(AppraisalFormReport appraisalFormReport);
        AppraisalFormReport GetAppraisalFormReportById(int appraisalFormReportId);
        AppraisalFormReport GetAppraisalFormReportByValue(string value);
    }
}
