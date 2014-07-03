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
    public partial class Form14 : Form
    {
        private readonly StudentContext _context;
        private readonly UnitOfWork _unit;
        private int _studentId;
        private List<Speciality> _specialityList;
        private List<Speciality> _specialityList1; 
        
        public Form14(int number, int studentId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            _studentId = studentId;
            _specialityList = new List<Speciality>();
            _specialityList1 = new List<Speciality>();

            this.SetWorkParametr(number);
        }

        private void SetWorkParametr(int number)
        {
            if (number == 1)
            {
                this.GetAllDataFromDb();
                btn_add.Visible = true;
                btn_add.Enabled = cmBox_group.Text != "";
                cmBox_speciality.SelectedIndexChanged += GetGroupOfSpeciality;
            }
            if (number == 2)
            {
                this.GetGroupForStudent();
                btn_delete.Visible = true;
                cmBox_speciality.Enabled = false;
                this.GetSpecialityForGroup();
                cmBox_group.SelectedIndexChanged += GetSpecialityToGroup;
            }
            
        }

        private void GetAllDataFromDb()
        {
            this.GetSpecialityFromDb();
            this.GetGroupFromDb();
        }

        private void GetSpecialityFromDb()
        {
            var specialityService = new SpecialityService(_unit, _unit);
            var speciality = specialityService.GetAllSpeciality();
            cmBox_speciality.DataSource = speciality.ToList();
        }

        private void GetGroupFromDb()
        {
            cmBox_group.Text = "";
            var speciality = (Speciality) cmBox_speciality.SelectedItem;
            cmBox_group.DataSource = speciality.Groups.ToList();
        }

        private void GetGroupForStudent()
        {
            var studentService = new StudentService(_unit, _unit);
            var groups = studentService.GetGroupsOfStudent(_studentId);
            cmBox_group.DataSource = groups.ToList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var studentService = new StudentService(_unit, _unit);
            var groupService = new GroupService(_unit, _unit);
            var student = studentService.GetStudentById(_studentId);
            var group = (Group) cmBox_group.SelectedItem;

            studentService.AddGroupToStudent(group, _studentId);
            groupService.AddStudentToGroup(student, group.Id);

            _unit.Commit();
            this.Close();
        }

        private void GetSpecialityForGroup()
        {
            if (cmBox_group.Text != "")
            {
                cmBox_speciality.DataSource = _specialityList1;
                var group = (Group)cmBox_group.SelectedItem;
                _specialityList.Add(group.Speciality);
                cmBox_speciality.DataSource = _specialityList;
                _specialityList.Remove(group.Speciality);
                btn_delete.Enabled = true;
            }
        }

        private void GetSpecialityToGroup(object sender, EventArgs e)
        {
            this.GetSpecialityForGroup();
        }

        private void GetGroupOfSpeciality(object sender, EventArgs e)
        {
            this.GetGroupFromDb();
            btn_add.Enabled = cmBox_group.Text != "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var studentService = new StudentService(_unit, _unit);
            var groupService = new GroupService(_unit, _unit);
            var student = studentService.GetStudentById(_studentId);
            var group = (Group)cmBox_group.SelectedItem;

            studentService.RemoveGroupToStudent(group, _studentId);
            groupService.RemoveStudentToGroup(student, group.Id);

            _unit.Commit();
            this.Close();
        }
    }
}
