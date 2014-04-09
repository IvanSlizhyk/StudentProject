using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentProject.EFData;
using StudentProject.Services;

namespace StudentProject.UI
{
    public partial class Form9 : Form
    {
        private readonly StudentContext _context;
        private readonly UnitOfWork _unit;
        private readonly int _entityId;

        public string IdText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string NameText
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public Form9(int number, int entityId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _entityId = entityId;

            this.SetWorkParametr(number);
        }

        private void SetWorkParametr(int number)
        {
            if (number == 1)
            {
                this.btn_add.Enabled = true;
                this.SetTextBox(1, false);
            }
            if (number == 2)
            {
                this.btn_update.Enabled = true;
                this.SetTextBox(1, false);
                this.GetAllDataFromDb();
            }
            if (number == 3)
            {
                this.SetTextBox(3, false);
                this.GetAllDataFromDb();
            }

        }

        private void GetAllDataFromDb()
        {
            var formReportService = new FormReportService(_unit, _unit);
            var formReport = formReportService.GetFormReportById(_entityId);
            IdText = formReport.Id.ToString();
            NameText = formReport.Name;
        }

        private void SetTextBox(int number, bool value)
        {
            if (number == 1 || number == 3)
            {
                textBox1.Enabled = value;
            }
            if (number == 2 || number == 3)
            {
                textBox2.Enabled = value;
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var formReportService = new FormReportService(_unit, _unit);
            var student = formReportService.CreateFormReport(NameText);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var formReportService = new FormReportService(_unit, _unit);
            var formReport = formReportService.GetFormReportById(_entityId);
            formReport.Name = NameText;
            formReportService.UpdateFormReport(formReport);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }
    }
}
