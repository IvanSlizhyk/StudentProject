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
        Progress CreateProgress(int term);
        void UpdateProgress(Progress progress);
        void RemoveProgress(Progress progress);
        Progress GetProgressById(int progressId);
        void SetStudentOfProgress(int studentId);
        HashSet<JournalProgress> GetJournalProgressesOfProgresses(int progressId);
    }
}
