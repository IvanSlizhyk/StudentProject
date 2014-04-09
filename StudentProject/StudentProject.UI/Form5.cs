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
    public partial class Form5 : Form
    {
        private readonly StudentContext _context;
        private readonly UnitOfWork _unit;
        private readonly int _entityId;

        public string IdText
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; } 
        }
        public string SurnameText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string NameText
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string PatronymicText
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string EmailText
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public Form5(int number, int entityId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _entityId = entityId;

            this.SetWorkParametr(number);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var studentService = new StudentService(_unit, _unit);
            var student = studentService.CreateStudent(NameText, SurnameText, PatronymicText, EmailText);
            _unit.Commit();
            _context.Dispose();
            this.Close();
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
                this.SetTextBox(6, false);
                this.GetAllDataFromDb();
            }

        }

        private void SetTextBox(int number, bool value)
        {
            if (number == 1 || number == 6)
            {
                textBox6.Enabled = value;
            }
            if (number == 2 || number == 6)
            {
                textBox1.Enabled = value;
            }
            if (number == 3 || number == 6)
            {
                textBox2.Enabled = value;
            }
            if (number == 4 || number == 6)
            {
                textBox3.Enabled = value;
            }
            if (number == 5 || number == 6)
            {
                textBox4.Enabled = value;
            }
        }

        private void GetAllDataFromDb()
        {
            var studentService = new StudentService(_unit, _unit);
            var student = studentService.GetStudentById(_entityId);
            IdText = student.Id.ToString();
            SurnameText = student.Surname;
            NameText = student.Name;
            PatronymicText = student.Patronymic;
            EmailText = student.Email;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var studentService = new StudentService(_unit, _unit);
            var student = studentService.GetStudentById(_entityId);
            student.Surname = SurnameText;
            student.Name = NameText;
            student.Patronymic = PatronymicText;
            student.Email = EmailText;
            studentService.UpdateStudent(student);
            _unit.Commit();
            _context.Dispose();
            this.Close();
        }
    }
}