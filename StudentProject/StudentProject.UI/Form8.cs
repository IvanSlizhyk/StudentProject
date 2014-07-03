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
    public partial class Form8 : Form
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
        
        public Form8(int number, int entityId)
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
            var disciplineService = new DisciplineService(_unit, _unit);
            var discipline = disciplineService.GetDisciplineById(_entityId);
            IdText = discipline.Id.ToString();
            NameText = discipline.Name;
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

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            var discipline = disciplineService.CreatDiscipline(NameText);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            var discipline = disciplineService.GetDisciplineById(_entityId);
            discipline.Name = NameText;
            disciplineService.UpdateDiscipline(discipline);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }
    }
}
