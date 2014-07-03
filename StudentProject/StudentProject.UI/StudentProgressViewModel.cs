using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentProject.Core.Entities;

namespace StudentProject.UI
{
    public class StudentProgressViewModel
    {
        public StudentProgressViewModel(JournalCurriculum journalCurriculum, JournalProgress journalProgress)
        {
            Discipline = journalCurriculum.Discipline;
            FormReport = journalCurriculum.FormReport;
            AppraisalFormReport = journalProgress.AppraisalFormReport;
        }

        public Discipline Discipline { get; set; }
        public FormReport FormReport { get; set; }
        public AppraisalFormReport AppraisalFormReport { get; set; }
    }
}
