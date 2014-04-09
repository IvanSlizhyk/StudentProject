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
    public partial class Form6 : Form
    {
        private readonly StudentContext _context;
        private readonly UnitOfWork _unit;
        private readonly int _entityId;

        public string IdText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public int GroupNumberText
        {
            get { return Convert.ToInt32(textBox2.Text); }
            set { textBox2.Text = value.ToString(); }
        }
        public int FormationYearText
        {
            get { return Convert.ToInt32(textBox3.Text); }
            set { textBox3.Text = value.ToString(); }
        }

        public Form6(int number, int entityId)
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
                this.GetSpecialityFromDb();
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

        private void GetAllDataFromDb()
        {
            var groupService = new GroupService(_unit, _unit);
            var group = groupService.GetGroupById(_entityId);
            IdText = @group.Id.ToString();
            GroupNumberText = group.GroupNumber;
            FormationYearText = group.FormationYear;
            this.GetSpecialityFromDb();
            comboBox1.Text = group.Speciality.Name;
        }

        private void GetSpecialityFromDb()
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.GetAllSpeciality();
            comboBox1.DataSource = speciality.ToList();
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

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var groupService = new GroupService(_unit, _unit);
            var group = groupService.CreateGroup(GroupNumberText, FormationYearText, (Speciality)comboBox1.SelectedItem);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var groupService = new GroupService(_unit, _unit);
            var group = groupService.GetGroupById(_entityId);
            group.GroupNumber = GroupNumberText;
            group.FormationYear = FormationYearText;
            groupService.SetSpecialityOfGroup((Speciality)comboBox1.SelectedItem, group);
            groupService.UpdateGroup(group);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }
    }
}