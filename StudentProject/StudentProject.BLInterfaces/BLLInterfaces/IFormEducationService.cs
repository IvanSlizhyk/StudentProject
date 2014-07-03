using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IFormEducationService : IService
    {
        FormEducation CreateFormEducation(string name);
        void UpdateFormEducation(FormEducation formEducation);
        void RemoveFormEducation(FormEducation formEducation);
        FormEducation GetFormEducationById(int formEducationId);
        FormEducation GetFormEducationByName(string name);
        IQueryable<FormEducation> GetAllFormEducation();
    }
}
