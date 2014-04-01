using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface ICurriculumService : IService
    {
        Curriculum CreateCurriculum(int term);
        Speciality GetSpecialityOfCurruculum(int currliculumId);

    }
}
