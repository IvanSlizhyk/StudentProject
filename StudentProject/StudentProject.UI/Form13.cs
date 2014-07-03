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
    public partial class Form13 : Form
    {
        private readonly StudentContext _context;
        private UnitOfWork _unit;
        private JournalCurriculum _journalCurriculum;

        public Form13(JournalCurriculum journalCurriculum)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _journalCurriculum = journalCurriculum;

            this.SetWorkParametr();
        }

        private void SetWorkParametr()
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var journalCurriculumService = new JournalCurriculumService(_unit, _unit);
            journalCurriculumService.RemoveJournalCurriculum(_journalCurriculum);
            _unit.Commit();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form12(2, -1, _journalCurriculum.Discipline.Id, _journalCurriculum.Id);
            form.ShowDialog();
            this.Close();
        }

    }
}
