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
    public partial class Form11 : Form
    {
        private StudentContext _context;
        private UnitOfWork _unit;
        private Speciality _speciality;
        private Curriculum _curriculum;
        public List<string> TermList { get; set; }
        public List<Discipline> AddDisciplinesList { get; set; }
        public List<Discipline> AddOnDisciplinesList { get; set; }

        public Form11(Speciality speciality)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _speciality = speciality;
            TermList = new List<string>();
            AddDisciplinesList = new List<Discipline>();
            AddOnDisciplinesList = new List<Discipline>();

            this.SetWorkParametr();
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void SetWorkParametr()
        {
            this.GetTermList();
            this.GetAllDataFromDb();
        }

        private void GetAllDataFromDb()
        {
            var disciplines = GetDisciplineFromDb();
            AddOnDisciplinesList = disciplines;
            FilterDisciplines(AddOnDisciplinesList);
            add_OnLBox.DataSource = AddOnDisciplinesList;
            addLBox.DataSource = AddDisciplinesList;
        }

        private void FilterDisciplines(List<Discipline> disciplines)
        {
            var curriculumService = new CurriculumService(_unit, _unit);
            var currculum = curriculumService.GetCurriculumBySpecialityAndTermNumber(_speciality, Convert.ToInt32(cmBox_Term.SelectedItem));
            _curriculum = currculum;
            var journalCurriculum = currculum.JournalCurricula;
            journalCurriculum.ToList().ForEach(DeleteForDiscipline);
            journalCurriculum.ToList().ForEach(GetDisciplinesForCurriculum);
        }

        private void GetDisciplinesForCurriculum(JournalCurriculum journalCurriculum)
        {
            AddDisciplinesList.Add(journalCurriculum.Discipline);
        }

        private void DeleteForDiscipline(JournalCurriculum journalCurriculum)
        {
            var deletedDiscipline = AddOnDisciplinesList.Find(e => e.Name == journalCurriculum.Discipline.Name);
            if (deletedDiscipline != null)  AddOnDisciplinesList.Remove(deletedDiscipline);
        }

        private List<Discipline> GetDisciplineFromDb()
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            var discipline = disciplineService.GetAllDiscipline();
            return discipline.ToList();
        }

        private void GetTermList()
        {
            this.SetTermList(_speciality.TermNumber);
            cmBox_Term.DataSource = TermList;
        }

        private void SetTermList(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                TermList.Add(i.ToString());
            }
        }

        private void UpdateAllDataFromDb()
        {
            AddDisciplinesList = new List<Discipline>();
            AddOnDisciplinesList = new List<Discipline>();
            this.GetAllDataFromDb();
        }

        private void cmBox_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateAllDataFromDb();
        }

        private void add_OnLBox_DoubleClick(object sender, EventArgs e)
        {
            var discipline = (Discipline) add_OnLBox.SelectedItem;
            var form = new Form12(1, _curriculum.Id, discipline.Id, -1);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.UpdateAllDataFromDb();
        }

        private void addLBox_Click(object sender, EventArgs e)
        {
            var journalCurriculum = _curriculum.JournalCurricula.ToList().Find(t => t.Discipline == (Discipline) addLBox.SelectedItem);
            var form = new Form13(journalCurriculum);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.UpdateAllDataFromDb();
        }

    }
}
