using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IFormReportService : IService
    {
        FormReport CreateFormReport(string name);
        void UpdateFormReport(FormReport formReport);
        void RemoveFormReport(FormReport formReport);
        FormReport GetFormReportById(int formReportId);
    }
}
