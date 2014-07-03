using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentProject.Core.Entities;
using StudentProject.EFData;
using StudentProject.Services;

namespace StudentProject.UI
{
    public partial class Form16 : Form
    {
        private StudentContext _context;
        private UnitOfWork _unit;
        public List<string> TermList { get; set; }
        public List<Discipline> AddDisciplinesList { get; set; }
        public List<Discipline> AddOnDisciplinesList { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<AppraisalFormReport> AppraisalFormReports { get; set; }
        public Student Student { get; set; }
        public Curriculum Curriculum { get; set; }
        public Progress Progress { get; set; }
        
        public Form16(int studentId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            TermList = new List<string>();
            AddDisciplinesList = new List<Discipline>();
            AddOnDisciplinesList = new List<Discipline>();
            Disciplines = new List<Discipline>();

            this.SetWorkParametr(studentId);
        }

        private void SetWorkParametr(int studentId)
        {
            var studentService = new StudentService(_unit, _unit);
            Student = studentService.GetStudentById(studentId);
            
            this.GetGroupFromDb();
            this.GetTermList();
            this.GetAllDataFromDb();
        }

        private void GetAllDataFromDb()
        {
            FilterDisciplines();
            add_OnLBox.DataSource = Disciplines;
            addLBox.DataSource = Disciplines;
            add_OnLBox.DataSource = AddOnDisciplinesList;
            addLBox.DataSource = AddDisciplinesList;
        }

        private void GetGroupFromDb()
        {
            var groups = Student.Groups.ToList();
            cmBox_Group.DataSource = groups;
        }

        private void FilterDisciplines()
        {
            AddDisciplinesList = new List<Discipline>();
            AddOnDisciplinesList = new List<Discipline>();
            var curriculumService = new CurriculumService(_unit, _unit);
            var progressService = new ProgressService(_unit, _unit);
            var group = (Group) cmBox_Group.SelectedItem;
            var currculum = curriculumService.GetCurriculumBySpecialityAndTermNumber(group.Speciality, Convert.ToInt32(cmBox_Term.SelectedItem));
            Curriculum = currculum;
            var journalCurriculum = currculum.JournalCurricula;
            var progress = progressService.GetProgressByGroupAndStudentAndTermNumber(group, Student, Convert.ToInt32(cmBox_Term.SelectedItem));
            Progress = progress;
            var journalProgress = progress.JournalProgresses;
            journalCurriculum.ToList().ForEach(FilterForDiscipline);
        }

        private void FilterForDiscipline(JournalCurriculum journalCurriculum)
        {
            var pr = Progress.JournalProgresses.ToList().Find(e => e.JournalCurriculumId == journalCurriculum.Id);
            if (pr!=null) AddDisciplinesList.Add(journalCurriculum.Discipline);
            else
            {
                AddOnDisciplinesList.Add(journalCurriculum.Discipline);
            }
        }

        private void GetTermList()
        {
            TermList = new List<string>();
            var group = (Group) cmBox_Group.SelectedItem;
            this.SetTermList(group.Speciality.TermNumber);
            cmBox_Term.DataSource = TermList;
        }

        private void SetTermList(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                TermList.Add(item: i.ToString());
            }
        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void cmBox_Group_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.GetTermList();
            this.GetAllDataFromDb();
        }

        private void cmBox_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAllDataFromDb();
        }

        private void GetApprisalFormReportFromDb(Discipline discipline)
        {
            var appraisaFormReportService = new AppraisalFormReportService(_unit, _unit);
            var journalCurriculum = Curriculum.JournalCurricula.ToList().Find(g => g.Discipline.Id == discipline.Id);
            if (journalCurriculum.FormReport.Name == "зачёт")
            {
                AppraisalFormReports = new List<AppraisalFormReport>();
                AppraisalFormReports.Add(appraisaFormReportService.GetAppraisalFormReportByValue("зачтено"));
                AppraisalFormReports.Add(appraisaFormReportService.GetAppraisalFormReportByValue("незачтено"));
            }
            else
            {
                AppraisalFormReports = new List<AppraisalFormReport>();
                AppraisalFormReports = appraisaFormReportService.GetAllAppraisalFormReport().ToList();
                var x1 = AppraisalFormReports.Find(t => t.Value == "зачтено");
                var x2 = AppraisalFormReports.Find(t => t.Value == "незачтено");
                AppraisalFormReports.Remove(x1);
                AppraisalFormReports.Remove(x2);
            }
            var cleanParametr = new List<AppraisalFormReport>();
            cmBox_AppraisalFormReport.DataSource = cleanParametr;
            cmBox_AppraisalFormReport.DataSource = AppraisalFormReports;
        }

        private void add_OnLBox_Click(object sender, EventArgs e)
        {
            var discipline = (Discipline)add_OnLBox.SelectedItem;
            GetApprisalFormReportFromDb(discipline);
            btn_add.Click -= UpdateJournalProgress;
            btn_add.Click -= AddJournalProgress;
            btn_add.Click += AddJournalProgress;
        }

        private void AddJournalProgress(object sender, EventArgs e)
        {
            var journalProgressService = new JournalProgressService(_unit, _unit);
            var discipline = (Discipline) add_OnLBox.SelectedItem;
            var journalCurriculum = Curriculum.JournalCurricula.ToList().Find(g=>g.Discipline.Id == discipline.Id);
            var appraisalFormReports = (AppraisalFormReport) cmBox_AppraisalFormReport.SelectedItem;
            journalProgressService.CreateJournalProgress(Progress, journalCurriculum, appraisalFormReports);

            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);

            GetAllDataFromDb();
        }

        private void UpdateJournalProgress(object sender, EventArgs e)
        {
            var journalProgressService = new JournalProgressService(_unit, _unit);
            var discipline = (Discipline)addLBox.SelectedItem;
            var journalProgress = Progress.JournalProgresses.ToList().Find(t => t.JournalCurriculum.Discipline == discipline);
            var appraisalFormReports = (AppraisalFormReport)cmBox_AppraisalFormReport.SelectedItem;
            journalProgress.AppraisalFormReport = appraisalFormReports;
            journalProgressService.UpdateJournalProgress(journalProgress);

            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);

            GetAllDataFromDb();
        }

        private void addLBox_Click(object sender, EventArgs e)
        {
            var discipline = (Discipline)addLBox.SelectedItem;
            GetApprisalFormReportFromDb(discipline);
            btn_add.Click -= AddJournalProgress;
            btn_add.Click -= UpdateJournalProgress;
            btn_add.Click += UpdateJournalProgress;
            var journalProgress = Progress.JournalProgresses.ToList().Find(g => g.JournalCurriculum.Discipline == discipline);
            cmBox_AppraisalFormReport.Text = journalProgress.AppraisalFormReport.Value;
        }
    }
}
