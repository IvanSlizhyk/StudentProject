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
        private readonly StudentContext _context;
        private UnitOfWork _unit;
        private readonly int _entityId;
        public List<string> TermList { get; set; }
        public List<Discipline> DisciplinesList { get; set; }

        public Form11(int number, int entityId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _entityId = entityId;
            TermList = new List<string>();
            DisciplinesList = new List<Discipline>();

            this.SetWorkParametr(number);
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_unit.Commit();
            _context.Dispose();
        }

        private void SetWorkParametr(int number)
        {
            if (number == 1)
            {
                _unit = new UnitOfWork(_context);
                btn_add.Enabled = true;
                this.GetAllDataFromDb();
            }
            if (number == 2)
            {

            }

        }



        private void GetAllDataFromDb()
        {
            this.GetTermList();
            var disciplines = GetDisciplineFromDb();
            this.GetFormReportFromDb();
            DisciplinesList = disciplines;
        }

        private List<Discipline> GetDisciplineFromDb()
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            var discipline = disciplineService.GetAllDiscipline();
            comboBox2.DataSource = discipline.ToList();
            return discipline.ToList();
        }

        private void GetTermList()
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.GetSpecialityById(_entityId);
            this.SetTermList(speciality.TermNumber);
            comboBox1.DataSource = TermList;
        }

        private void SetTermList(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                TermList.Add(i.ToString());
            }
        }

        private void GetFormReportFromDb()
        {
            var formReportService = new FormReportService(_unit, _unit);
            var formReport = formReportService.GetAllFormReport();
            comboBox3.DataSource = formReport.ToList();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var journalCurriculumService = new JournalCurriculumService(_unit, _unit);
            var curriculumService = new CurriculumService(_unit, _unit);
            var selectedDiscipline = (Discipline) comboBox2.SelectedItem;
            var speciality = specialityService.GetSpecialityById(_entityId);
            var curriculum = curriculumService.GetCurriculumBySpecialityAndTermNumber(speciality, Convert.ToInt32(comboBox1.Text));
            var journalCurriculum = journalCurriculumService.CreateJournalCurriculum(Convert.ToInt32(textBox2.Text), selectedDiscipline, (FormReport)comboBox3.SelectedItem, curriculum);
            _unit.Commit();
            
            var discipline = DisciplinesList.Find(t=>t.Name==selectedDiscipline.Name);
            DisciplinesList.Remove(discipline);
            comboBox2.DataSource = DisciplinesList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var disciplines = GetDisciplineFromDb();
            DisciplinesList = disciplines;
        }

    }
}
