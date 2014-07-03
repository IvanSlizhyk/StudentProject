using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.BLInterfaces.BLLInterfaces
{
    public interface IProgressService : IService
    {
        void UpdateProgress(Progress progress);
        void RemoveProgress(Progress progress);
        Progress GetProgressById(int progressId);
        void SetStudentOfProgress(Student student, int progressId);
        HashSet<JournalProgress> GetJournalProgressesOfProgresses(int progressId);
    }
}
