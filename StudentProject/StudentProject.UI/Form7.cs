using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentProject.Core.Entities;
using StudentProject.EFData;
using StudentProject.Services;

namespace StudentProject.UI
{
    public partial class Form7 : Form
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
        public int TermNumberText
        {
            get { return Convert.ToInt32(textBox3.Text); }
            set { textBox3.Text = value.ToString(); }
        }

        public Form7(int number, int entityId)
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
                this.GetFormEducationFromDb();
            }
            if (number == 2)
            {
                this.btn_update.Enabled = true;
                this.SetTextBox(1, false);
                this.GetAllDataFromDb();
            }
            if (number == 3)
            {
                this.SetTextBox(5, false);
                this.GetAllDataFromDb();
            }

        }

        private void SetTextBox(int number, bool value)
        {
            if (number == 1 || number == 5)
            {
                textBox1.Enabled = value;
            }
            if (number == 2 || number == 5)
            {
                textBox2.Enabled = value;
            }
            if (number == 3 || number == 5)
            {
                textBox3.Enabled = value;
            }
            if (number == 4 || number == 5)
            {
                comboBox1.Enabled = value;
            }
        }

        private void GetAllDataFromDb()
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.GetSpecialityById(_entityId);
            IdText = speciality.Id.ToString();
            NameText = speciality.Name;
            TermNumberText = speciality.TermNumber;
            this.GetFormEducationFromDb();
            comboBox1.Text = speciality.FormEducation.Name;
        }

        private void GetFormEducationFromDb()
        {
            var formEducationService = new FormEducationService(_unit, _unit);
            var formEducation = formEducationService.GetAllFormEducation();
            comboBox1.DataSource = formEducation.ToList();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.CreateSpeciality(NameText, TermNumberText, (FormEducation)comboBox1.SelectedItem);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.GetSpecialityById(_entityId);
            speciality.Name = NameText;
            speciality.TermNumber = TermNumberText;
            specialityService.SetFormEducationOfSpeciality((FormEducation)comboBox1.SelectedItem,speciality);
            specialityService.UpdateSpeciality(speciality);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }

    }
}
