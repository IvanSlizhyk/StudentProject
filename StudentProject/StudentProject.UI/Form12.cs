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
    public partial class Form12 : Form
    {
        private readonly StudentContext _context;
        private UnitOfWork _unit;
        private Discipline _discipline;
        private JournalCurriculum _journalCurriculum;
        private Curriculum _curriculum;
        public int TimeText
        {
            get { return Convert.ToInt32(textBox2.Text); }
            set { textBox2.Text = value.ToString(); }
        }

        
        public Form12(int number, int curriculumId, int disciplineId, int journalCurriculumId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);

            this.GetWorkParametr(number, curriculumId, disciplineId, journalCurriculumId);
        }

        private void GetWorkParametr(int number, int curriculumId, int disciplineId, int journalCurriculumId)
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            var curriculumService = new CurriculumService(_unit, _unit);
            var journalCurriculumService = new JournalCurriculumService(_unit, _unit);
            if (disciplineId!=-1) _discipline = disciplineService.GetDisciplineById(disciplineId);
            if (journalCurriculumId!=-1) _journalCurriculum = journalCurriculumService.GetJournalCurriculumById(journalCurriculumId);
            if (curriculumId!=-1) _curriculum = curriculumService.GetCurriculumById(curriculumId);
            this.GetFormReportFromDb();
            textBox1.Text = _discipline.Name;
            if (number == 1)
            {
                btn_addDiscipline.Visible = true;
            }
            if (number == 2)
            {
                btn_updateDiscipline.Visible = true;
                TimeText = _journalCurriculum.Time;
                comboBox3.SelectedItem = _journalCurriculum.FormReport;
            }
        }

        private void GetFormReportFromDb()
        {
            var formReportService = new FormReportService(_unit, _unit);
            var formReport = formReportService.GetAllFormReport();
            comboBox3.DataSource = formReport.ToList();
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_addDiscipline_Click(object sender, EventArgs e)
        {
            var journalCurriculumService = new JournalCurriculumService(_unit, _unit);
            var journalCurriculum = journalCurriculumService.CreateJournalCurriculum(TimeText, _discipline, (FormReport)comboBox3.SelectedItem, _curriculum);
            _unit.Commit();
            this.Close();
        }

        private void btn_updateDiscipline_Click(object sender, EventArgs e)
        {
            var journalCurriculumService = new JournalCurriculumService(_unit, _unit);
            _journalCurriculum.Time = TimeText;
            _journalCurriculum.FormReport = (FormReport) comboBox3.SelectedItem;
            journalCurriculumService.UpdaterJournalCurriculum(_journalCurriculum);
            _unit.Commit();
            this.Close();
        }

    }
}
