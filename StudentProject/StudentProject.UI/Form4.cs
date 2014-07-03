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
    public partial class Form4 : Form
    {
        private readonly StudentContext _context;
        private readonly UnitOfWork _unit;
        private readonly int _entityId;
        private readonly int _index;
        private readonly Form2 _form2;
        public List<string> AdditionalForStudentList { get; set; }
        public List<string> AdditionalForGroupList { get; set; }
        public List<string> AdditionalForSpecialityList { get; set; }

        public Form4(int number, int entityId, int index, Form2 form2)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _entityId = entityId;
            _index = index;
            _form2 = form2;

            this.SetWorkParametr(number);
        }

        private void PaddEntityLists()
        {
            this.SetValueGroupList();
            this.SetValueSpecialityList();
            this.SetValueStudentList();
        }

        private void SetValueStudentList()
        {
            AdditionalForStudentList = new List<string>();
            AdditionalForStudentList.Add("Просмотреть успеваемоть студента");
            AdditionalForStudentList.Add("Изменить успеваемоть студента");
            AdditionalForStudentList.Add("Просмотреть группы студента");
            AdditionalForStudentList.Add("Добавить студента в группу");
            AdditionalForStudentList.Add("Удалить студента из группы");
        }

        private void SetValueGroupList()
        {
            AdditionalForGroupList = new List<string>();
            AdditionalForGroupList.Add("Просмотреть студентов группы");
        }

        private void SetValueSpecialityList()
        {
            AdditionalForSpecialityList = new List<string>();
            AdditionalForSpecialityList.Add("Изменить учебный план специальности");
            AdditionalForSpecialityList.Add("Просмотреть группы специальности");
        }

        private void PaddAllEntityLists()
        {
            this.SetValueAllGroupList();
            this.SetValueAllSpecialityList();
            this.SetValueAllStudentList();
        }

        private void SetValueAllStudentList()
        {
            AdditionalForStudentList = new List<string>();
            AdditionalForStudentList.Add("Просмотреть всех студентов");
        }

        private void SetValueAllGroupList()
        {
            AdditionalForGroupList = new List<string>();
            AdditionalForGroupList.Add("Просмотреть все группы");
        }

        private void SetValueAllSpecialityList()
        {
            AdditionalForSpecialityList = new List<string>();
            AdditionalForSpecialityList.Add("Просмотреть все специальности");
        }

        private void SetEntityListToLBox()
        {
            if (_index == 1)
            {
                additionalLBox.DataSource = AdditionalForStudentList;
            }
            if (_index == 2)
            {
                additionalLBox.DataSource = AdditionalForGroupList;
            }
            if (_index == 3)
            {
                additionalLBox.DataSource = AdditionalForSpecialityList;
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void SetWorkParametr(int number)
        {
            if (number == 1)
            {
                this.PaddEntityLists();

            }
            if (number == 2)
            {
                this.PaddAllEntityLists();

            }
            this.SetEntityListToLBox();
        }

        private void ReturnDecision(object sender, EventArgs e)
        {
            _form2.DeccisionIndex = additionalLBox.SelectedIndex;

            _context.Dispose();
            this.Close();
        }


    }
}
