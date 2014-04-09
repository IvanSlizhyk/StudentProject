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
            AdditionalForStudentList = new List<string> { "Просмотреть успеваемоть студента", "Просмотреть группы студента" };
            AdditionalForGroupList = new List<string> { "Просмотреть студентов группы" };
            AdditionalForSpecialityList = new List<string> { "Изменить учебный план", "Просмотреть группы специальности" };
        }

        private void PaddAllEntityLists()
        {
            AdditionalForStudentList = new List<string> { "Просмотреть всех студентов" };
            AdditionalForGroupList = new List<string> { "Просмотреть все группы" };
            AdditionalForSpecialityList = new List<string> { "Просмотреть все специальности" };
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

        private EventHandler GetEntityToDecisionTask(int number)
        {
            if (number == 1)
            {
                if (_index == 1) return DecisionStudentTask;
                if (_index == 2) return DecisionGroupTask;
                if (_index == 3) return DecisionSpecialityTask;
            }
            if (number == 2)
            {
                if (_index == 1) return DecisionAllStudentTask;
                if (_index == 2) return DecisionAllGroupTask;
                if (_index == 3) return DecisionAllSpecialityTask;
            }
            return ReturnDecision;
        }

        private void SetEntityToDecisionTask(int number)
        {
            this.ClearAdditionalLBox();
            EventHandler even = GetEntityToDecisionTask(number);
            additionalLBox.DoubleClick += even;
        }

        private void ClearAdditionalLBox()
        {
            additionalLBox.DoubleClick -= DecisionStudentTask;
            additionalLBox.DoubleClick -= DecisionGroupTask;
            additionalLBox.DoubleClick -= DecisionSpecialityTask;
            additionalLBox.DoubleClick -= DecisionAllStudentTask;
            additionalLBox.DoubleClick -= DecisionAllGroupTask;
            additionalLBox.DoubleClick -= DecisionAllSpecialityTask;
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
            this.SetEntityToDecisionTask(number);
        }

        private void DecisionSpecialityTask(object sender, EventArgs e)
        {
            if (additionalLBox.SelectedIndex == 0)
            {
                _form2.DeccisionIndex = 0;
            }
            if (additionalLBox.SelectedIndex == 1)
            {
                _form2.DeccisionIndex = 1;
            }
            _context.Dispose();
            this.Close();
        }

        private void DecisionStudentTask(object sender, EventArgs e)
        {

        }

        private void DecisionGroupTask(object sender, EventArgs e)
        {

        }

        private void DecisionAllStudentTask(object sender, EventArgs e)
        {

        }

        private void DecisionAllGroupTask(object sender, EventArgs e)
        {

        }

        private void DecisionAllSpecialityTask(object sender, EventArgs e)
        {

        }

        private void ReturnDecision(object sender, EventArgs e)
        {
            /**/
        }


    }
}
