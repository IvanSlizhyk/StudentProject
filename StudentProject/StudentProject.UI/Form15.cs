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
    public partial class Form15 : Form
    {
        private StudentContext _context;
        private UnitOfWork _unit;
        public List<string> TermList { get; set; }
        public Student Student { get; set; }
        
        public Form15(int studentId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            TermList = new List<string>();

            this.SetWorkParametr(studentId);
        }

        private void SetWorkParametr(int studentId)
        {
            var studentService = new StudentService(_unit, _unit);
            Student = studentService.GetStudentById(studentId);

            label1.Text = Student.Surname + @" " + Student.Name + @" " + Student.Patronymic;

            GetAllDataFromDb();
        }

        private void GetAllDataFromDb()
        {
            GetGroupFromDb();
            GetTermList();
            GetProgressFromDb();

        }

        private void GetProgressFromDb()
        {
            var group = (Group)cmBox_Group.SelectedItem;
            var curriculum = group.Speciality.Curricula.ToList().Find(e => e.Term == Convert.ToInt32(cmBox_Term.Text));
            var journalCurriculum = curriculum.JournalCurricula.ToList();
            var progresses = Student.Progresses.ToList().Find(e => e.Term == Convert.ToInt32(cmBox_Term.Text) && e.GroupId == group.Id);
            var journalProgresses = progresses.JournalProgresses.ToList();

            var data = GenerateStudentProgressData(journalCurriculum, journalProgresses);
            ProgressGV.DataSource = data;
        }

        private void GetTermList()
        {
            TermList = new List<string>();
            var group = (Group)cmBox_Group.SelectedItem;
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

        private void GetGroupFromDb()
        {
            var groups = Student.Groups.ToList();
            cmBox_Group.DataSource = groups;
        }

        private List<StudentProgressViewModel> GenerateStudentProgressData(List<JournalCurriculum> journalCurriculum, List<JournalProgress> journalProgresses)
        {
            var studentProgresses = new List<StudentProgressViewModel>();

            for (var i = 0; i < journalCurriculum.Count; i++)
            {
                var a = new StudentProgressViewModel(journalCurriculum[i], journalProgresses[i]);
                studentProgresses.Add(a);
            }

            return studentProgresses;
        }

        private void cmBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTermList();
            GetProgressFromDb();
        }

        private void cmBox_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProgressFromDb();
        }

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }
    }
}
