using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using StudentProject.Core.Entities;
using StudentProject.EFData;
using StudentProject.Services;
using StudentProject.UI;

namespace StudentProject.UI
{
    public partial class Form2 : Form
    {
        private StudentContext _context;
        private UnitOfWork _unit;
        public int EntitiesIndex { get; set; }
        private string _tBox_searchValue;
        public int DeccisionIndex { get; set; }
        public List<string> StudentFields { get; set; }
        public List<string> GroupFields { get; set; }
        public List<string> SpecialityFields { get; set; }
        public List<string> DisciplineFields { get; set; }
        public List<string> FormReportFields { get; set; }
        public List<string> AppraisalFormReportFields { get; set; }

        public Form2()
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            EntitiesIndex = 0;
            this.SetFieldLists();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(1, StudentFields, AddStudent, SearchForStudent, DeleteStudent, UpdateStudent, ViewStudent, AdditionalForStudent);
        }

        private void btn_group_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(2, GroupFields, AddGroup, SearchForGroup, DeleteGroup, UpdateGroup, ViewGroup, AdditionalForGroup);
        }

        private void btn_speciality_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(3, SpecialityFields, AddSpeciality, SearchForSpeciality, DeleteSpeciality, UpdateSpeciality, ViewSpeciality, AdditionalForSpeciality);
        }

        private void btn_discipline_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(4, DisciplineFields, AddDiscipline, SearchForDiscipline, DeleteDiscipline, UpdateDiscipline, ViewDiscipline, ReturnAdditional);
        }

        private void btn_formReport_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(5, FormReportFields, AddFormReport, SearchForFormReport, DeleteFormReport, UpdateFormReport, ViewFormReport, ReturnAdditional);
        }

        private void btn_appraisalFormReport_Click(object sender, EventArgs e)
        {
            this.SetWorkParametr(6, AppraisalFormReportFields, AddAppraisalFormReport, SearchForAppraisalFormReport, DeleteAppraisalFormReport, UpdateAppraisalFormReport, ViewAppraisalFormReport, ReturnAdditional);
        }

        private void AddStudent(object sender, EventArgs e)
        {
            var form = new Form5(1, 0);
            form.ShowDialog();
        }

        private void AddGroup(object sender, EventArgs e)
        {
            var form = new Form6(1, 0);
            form.ShowDialog();
        }

        private void AddSpeciality(object sender, EventArgs e)
        {
            var form = new Form7(1, 0);
            form.ShowDialog();
        }

        private void AddDiscipline(object sender, EventArgs e)
        {
            var form = new Form8(1, 0);
            form.ShowDialog();
        }

        private void AddFormReport(object sender, EventArgs e)
        {
            var form = new Form9(1, 0);
            form.ShowDialog();
        }

        private void AddAppraisalFormReport(object sender, EventArgs e)
        {
            var form = new Form10(1, 0);
            form.ShowDialog();
        }

        private void SetAddButtonParametr(List<string> field, EventHandler even)
        {
            this.ClearAddBtn();
            cmBox_search.DataSource = field;
            btn_add.Click += even;
        }

        private void ClearAddBtn()
        {
            btn_add.Click -= AddStudent;
            btn_add.Click -= AddGroup;
            btn_add.Click -= AddSpeciality;
            btn_add.Click -= AddDiscipline;
            btn_add.Click -= AddFormReport;
            btn_add.Click -= AddAppraisalFormReport;
        }

        private void SetFieldLists()
        {
            StudentFields = new List<string> { "Id", "Surname", "Email" };
            GroupFields = new List<string> { "Id", "GroupNumber", "FormationYear" };
            SpecialityFields = new List<string> { "Id", "Name", "FormEducation" };
            DisciplineFields = new List<string> { "Id", "Name" };
            FormReportFields = new List<string> { "Id", "Name" };
            AppraisalFormReportFields = new List<string> { "Id", "Name" };
        }

        private void SetGriedView(int number, bool value)
        {
            if (number == 1 || number == 8)
            {
                studentGV.Visible = value;
                studentGV.DataSource = null;
            }
            if (number == 2 || number == 8)
            {
                groupGV.Visible = value;
                groupGV.DataSource = null;
            }
            if (number == 3 || number == 8)
            {
                specialityGV.Visible = value;
                specialityGV.DataSource = null;
            }
            if (number == 4 || number == 8)
            {
                disciplineGV.Visible = value;
                disciplineGV.DataSource = null;
            }
            if (number == 5 || number == 8)
            {
                formReportGV.Visible = value;
                formReportGV.DataSource = null;
            }
            if (number == 6 || number == 8)
            {
                appraisalFormReportGV.Visible = value;
                appraisalFormReportGV.DataSource = null;
            }
            if (number == 7 || number == 8)
            {
                screenGV.Visible = value;
            }
        }

        private void SetAdditionalGriedView(int number, bool value)
        {
            if (number == 1 || number == 6)
            {
                studentAGV.Visible = value;
                studentAGV.DataSource = null;
            }
            if (number == 2 || number == 6)
            {
                groupAGV.Visible = value;
                groupAGV.DataSource = null;
            }
            if (number == 3 || number == 6)
            {
                specialityAGV.Visible = value;
                specialityAGV.DataSource = null;
            }
            if (number == 4 || number == 6)
            {
                screenAGV.Visible = value;
                screenAGV.DataSource = null;
            }
            if (number == 5 || number == 6)
            {
                AllEntityGV.Visible = value;
                AllEntityGV.DataSource = null;
            }
        }

        private void SetGriedViewParametr(int index)
        {
            this.SetGriedView(8, false);
            this.SetGriedView(index, true);
        }

        private void SetAdditionalGriedViewParametr(int index)
        {
            this.SetAdditionalGriedView(6, false);
            this.SetAdditionalGriedView(index, true);
        }

        private void SetWorkParametr(int index, List<string> field, EventHandler event1, KeyPressEventHandler event2, EventHandler event3, EventHandler event4, EventHandler event5, EventHandler event6)
        {
            EntitiesIndex = index;
            this.SetGriedViewParametr(index);
            this.SetAdditionalGriedViewParametr(index);
            this.SetAddButtonParametr(field, event1);
            this.SetDeleteButtonParametr(event3);
            this.SetUpdateButtonParametr(event4);
            this.SetSearchBoxParametr(event2);
            this.SetViewButtonParametr(event5);
            this.SetAdditionalButtonParametr(event6);
            btn_additional.Enabled = index <= 3;
        }

        private void SetSearchBoxParametr(KeyPressEventHandler even)
        {
            this.ClearSearchBox();
            tBox_search.KeyPress += even;
        }

        private void SearchForStudent(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchStudent(e.KeyChar, _tBox_searchValue);
        }

        private void SearchStudent(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 1)
            {
                var studentService = new StudentService(_unit, _unit);
                var student = studentService.GetStudentById(Convert.ToInt32(_tBox_searchValue));
                studentGV.DataSource = new List<Student>() { student };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var studentService = new StudentService(_unit, _unit);
                var student = studentService.GetStudentsBySurname(_tBox_searchValue);
                studentGV.DataSource = student.ToList();
            }
            if (code == 13 && cmBox_search.SelectedIndex == 2 && value != "")
            {
                var studentService = new StudentService(_unit, _unit);
                var student = studentService.GetStudentsByEmail(_tBox_searchValue);
                studentGV.DataSource = student.ToList();
            }
        }

        private void SearchForGroup(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchGroup(e.KeyChar, _tBox_searchValue);
        }

        private void SearchGroup(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 2)
            {
                var groupService = new GroupService(_unit, _unit);
                var group = groupService.GetGroupById(Convert.ToInt32(_tBox_searchValue));
                groupGV.DataSource = new List<Group>() { group };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var groupService = new GroupService(_unit, _unit);
                var group = groupService.GetGroupByNumber(Convert.ToInt32(_tBox_searchValue));
                groupGV.DataSource = new List<Group>() { group };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 2 && value != "")
            {
                var groupService = new GroupService(_unit, _unit);
                var group = groupService.GetGroupsByFormationYear(Convert.ToInt32(_tBox_searchValue));
                groupGV.DataSource = group.ToList();
            }
        }

        private void SearchForSpeciality(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchSpeciality(e.KeyChar, _tBox_searchValue);
        }

        private void SearchSpeciality(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 3)
            {
                var specialityService = new SpecialityService(_unit, _unit);
                var speciality = specialityService.GetSpecialityById(Convert.ToInt32(_tBox_searchValue));
                specialityGV.DataSource = new List<Speciality>() { speciality };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var specialityService = new SpecialityService(_unit, _unit);
                var speciality = specialityService.GetSpecialitiesByName(_tBox_searchValue);
                specialityGV.DataSource = speciality.ToList();
            }
            if (code == 13 && cmBox_search.SelectedIndex == 2 && value != "")
            {
                var specialityService = new SpecialityService(_unit, _unit);
                var formEducationService = new FormEducationService(_unit, _unit);
                var formEducation = formEducationService.GetFormEducationByName(_tBox_searchValue);
                var speciality = specialityService.GetSpecialitiesByFormEducation(formEducation.Id);
                specialityGV.DataSource = speciality.ToList();
            }
        }

        private void SearchForDiscipline(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchDiscipline(e.KeyChar, _tBox_searchValue);
        }

        private void SearchDiscipline(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 4)
            {
                var disciplineService = new DisciplineService(_unit, _unit);
                var discipline = disciplineService.GetDisciplineById(Convert.ToInt32(_tBox_searchValue));
                disciplineGV.DataSource = new List<Discipline>() { discipline };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var disciplineService = new DisciplineService(_unit, _unit);
                var discipline = disciplineService.GetDisciplineByName(_tBox_searchValue);
                disciplineGV.DataSource = new List<Discipline>() { discipline };
            }
        }

        private void SearchForFormReport(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchFormReport(e.KeyChar, _tBox_searchValue);
        }

        private void SearchFormReport(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 5)
            {
                var formReportService = new FormReportService(_unit, _unit);
                var formReport = formReportService.GetFormReportById(Convert.ToInt32(_tBox_searchValue));
                formReportGV.DataSource = new List<FormReport>() { formReport };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var formReportService = new FormReportService(_unit, _unit);
                var formReport = formReportService.GetFormReportByName(_tBox_searchValue);
                formReportGV.DataSource = new List<FormReport>() { formReport };
            }
        }

        private void SearchForAppraisalFormReport(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _tBox_searchValue = tBox_search.Text;
                tBox_search.Text = "";
            }
            this.SearchAppraisalFormReport(e.KeyChar, _tBox_searchValue);
        }

        private void SearchAppraisalFormReport(int code, string value)
        {
            if (code == 13 && cmBox_search.SelectedIndex == 0 && value != "" && EntitiesIndex == 6)
            {
                var appraisalFormReportService = new AppraisalFormReportService(_unit, _unit);
                var appraisalFormReport = appraisalFormReportService.GetAppraisalFormReportById(Convert.ToInt32(_tBox_searchValue));
                appraisalFormReportGV.DataSource = new List<AppraisalFormReport>() { appraisalFormReport };
            }
            if (code == 13 && cmBox_search.SelectedIndex == 1 && value != "")
            {
                var appraisalFormReportService = new AppraisalFormReportService(_unit, _unit);
                var appraisalFormReport = appraisalFormReportService.GetAppraisalFormReportByValue(_tBox_searchValue);
                appraisalFormReportGV.DataSource = new List<AppraisalFormReport>() { appraisalFormReport };
            }
        }

        private void ClearSearchBox()
        {
            tBox_search.KeyPress -= SearchForStudent;
            tBox_search.KeyPress -= SearchForGroup;
            tBox_search.KeyPress -= SearchForSpeciality;
            tBox_search.KeyPress -= SearchForDiscipline;
            tBox_search.KeyPress -= SearchForFormReport;
            tBox_search.KeyPress -= SearchForAppraisalFormReport;
        }

        private void DeleteStudent(object sender, EventArgs e)
        {
            var studentService = new StudentService(_unit, _unit);
            var student = (Student) studentGV.CurrentRow.DataBoundItem;
            student.Groups = null;
            studentService.RemoveStudent(student);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchStudent(13, _tBox_searchValue);
        }

        private void DeleteGroup(object sender, EventArgs e)
        {
            var groupService = new GroupService(_unit, _unit);
            var group = (Group) groupGV.CurrentRow.DataBoundItem;
            group.Students = null;
            groupService.RemoveGroup(group);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchGroup(13, _tBox_searchValue);
        }

        private void DeleteSpeciality(object sender, EventArgs e)
        {
            var specialityService = new SpecialityService(_unit, _unit);
            specialityService.RemoveSpeciality((Speciality)specialityGV.CurrentRow.DataBoundItem);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchSpeciality(13, _tBox_searchValue);
        }

        private void DeleteDiscipline(object sender, EventArgs e)
        {
            var disciplineService = new DisciplineService(_unit, _unit);
            disciplineService.RemoveDiscipline((Discipline)disciplineGV.CurrentRow.DataBoundItem);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchDiscipline(13, _tBox_searchValue);
        }

        private void DeleteFormReport(object sender, EventArgs e)
        {
            var formReport = new FormReportService(_unit, _unit);
            formReport.RemoveFormReport((FormReport)formReportGV.CurrentRow.DataBoundItem);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchFormReport(13, _tBox_searchValue);
        }

        private void DeleteAppraisalFormReport(object sender, EventArgs e)
        {
            var appraisalFormReport = new AppraisalFormReportService(_unit, _unit);
            appraisalFormReport.RemoveAppraisalFormReport((AppraisalFormReport)appraisalFormReportGV.CurrentRow.DataBoundItem);
            _unit.Commit();
            _unit = new UnitOfWork(_context);
            this.SearchAppraisalFormReport(13, _tBox_searchValue);
        }

        private void SetDeleteButtonParametr(EventHandler even)
        {
            this.ClearDeleteBtn();
            btn_delete.Click += even;
        }

        private void ClearDeleteBtn()
        {
            btn_delete.Click -= DeleteStudent;
            btn_delete.Click -= DeleteGroup;
            btn_delete.Click -= DeleteSpeciality;
            btn_delete.Click -= DeleteDiscipline;
            btn_delete.Click -= DeleteFormReport;
            btn_delete.Click -= DeleteAppraisalFormReport;
        }

        private void UpdateStudent(object sender, EventArgs e)
        {
            var student = (Student)studentGV.CurrentRow.DataBoundItem;
            var form = new Form5(2, student.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchStudent(13, _tBox_searchValue);
        }

        private void UpdateGroup(object sender, EventArgs e)
        {
            var group = (Group)groupGV.CurrentRow.DataBoundItem;
            var form = new Form6(2, group.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchGroup(13, _tBox_searchValue);
        }

        private void UpdateSpeciality(object sender, EventArgs e)
        {
            var speciality = (Speciality)specialityGV.CurrentRow.DataBoundItem;
            var form = new Form7(2, speciality.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchSpeciality(13, _tBox_searchValue);
        }

        private void UpdateDiscipline(object sender, EventArgs e)
        {
            var discipline = (Discipline)disciplineGV.CurrentRow.DataBoundItem;
            var form = new Form8(2, discipline.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchDiscipline(13, _tBox_searchValue);
        }

        private void UpdateFormReport(object sender, EventArgs e)
        {
            var formReport = (FormReport)formReportGV.CurrentRow.DataBoundItem;
            var form = new Form9(2, formReport.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchFormReport(13, _tBox_searchValue);
        }

        private void UpdateAppraisalFormReport(object sender, EventArgs e)
        {
            var appraisalFormReport = (AppraisalFormReport)appraisalFormReportGV.CurrentRow.DataBoundItem;
            var form = new Form10(2, appraisalFormReport.Id);
            form.ShowDialog();
            _unit.Commit();
            _context.Dispose();
            _context = new StudentContext(Resources.ConnectionString);
            _unit = new UnitOfWork(_context);
            this.SearchAppraisalFormReport(13, _tBox_searchValue);
        }

        private void ClearUpdateBtn()
        {
            btn_update.Click -= UpdateStudent;
            btn_update.Click -= UpdateGroup;
            btn_update.Click -= UpdateSpeciality;
            btn_update.Click -= UpdateDiscipline;
            btn_update.Click -= UpdateFormReport;
            btn_update.Click -= UpdateAppraisalFormReport;
        }

        private void SetUpdateButtonParametr(EventHandler even)
        {
            this.ClearUpdateBtn();
            btn_update.Click += even;
        }

        private void ViewStudent(object sender, EventArgs e)
        {
            var student = (Student)studentGV.CurrentRow.DataBoundItem;
            var form = new Form5(3, student.Id);
            form.ShowDialog();
        }

        private void ViewGroup(object sender, EventArgs e)
        {
            var group = (Group)groupGV.CurrentRow.DataBoundItem;
            var form = new Form6(3, group.Id);
            form.ShowDialog();
        }

        private void ViewSpeciality(object sender, EventArgs e)
        {
            var speciality = (Speciality)specialityGV.CurrentRow.DataBoundItem;
            var form = new Form7(3, speciality.Id);
            form.ShowDialog();
        }

        private void ViewDiscipline(object sender, EventArgs e)
        {
            var discipline = (Discipline)disciplineGV.CurrentRow.DataBoundItem;
            var form = new Form8(3, discipline.Id);
            form.ShowDialog();
        }

        private void ViewFormReport(object sender, EventArgs e)
        {
            var formReport = (FormReport)formReportGV.CurrentRow.DataBoundItem;
            var form = new Form9(3, formReport.Id);
            form.ShowDialog();
        }

        private void ViewAppraisalFormReport(object sender, EventArgs e)
        {
            var appraisalFormReport = (AppraisalFormReport)appraisalFormReportGV.CurrentRow.DataBoundItem;
            var form = new Form10(3, appraisalFormReport.Id);
            form.ShowDialog();
        }

        private void SetViewButtonParametr(EventHandler even)
        {
            this.ClearViewBtn();
            btn_view.Click += even;
        }

        private void ClearViewBtn()
        {
            btn_view.Click -= ViewStudent;
            btn_view.Click -= ViewGroup;
            btn_view.Click -= ViewSpeciality;
            btn_view.Click -= ViewDiscipline;
            btn_view.Click -= ViewFormReport;
            btn_view.Click -= ViewAppraisalFormReport;
        }

        private void AdditionalForStudent(object sender, EventArgs e)
        {
            if (studentGV.CurrentRow != null)
            {
                var student = (Student)studentGV.CurrentRow.DataBoundItem;
                var form = new Form4(1, student.Id, 1, this);
                form.ShowDialog();
                if (DeccisionIndex == 0)
                {
                    var form0 = new Form15(student.Id);
                    form0.ShowDialog();
                }
                if (DeccisionIndex == 1)
                {
                    var form1 = new Form16(student.Id);
                    form1.ShowDialog();
                }
                if (DeccisionIndex == 2)
                {
                    this.groupAGV.Visible = true;
                    this.studentAGV.Visible = false;
                    this.groupAGV.DataSource = student.Groups.ToList();
                }
                if (DeccisionIndex == 3)
                {
                    var form3 = new Form14(1, student.Id);
                    form3.ShowDialog();

                }
                if (DeccisionIndex == 4)
                {
                    var form4 = new Form14(2, student.Id);
                    form4.ShowDialog();
                }
            }
            else
            {
                var form = new Form4(2, 0, 1, this);
                form.ShowDialog();
                var studentService = new StudentService(_unit, _unit);
                if (DeccisionIndex == 0)
                {
                    this.studentAGV.Visible = true;
                    var allStudent = studentService.GetAllStudents();
                    studentAGV.DataSource = allStudent.ToList();
                }
                if (DeccisionIndex == 1)
                {

                }
            }
            DeccisionIndex = -1;
        }

        private void AdditionalForGroup(object sender, EventArgs e)
        {
            if (groupGV.CurrentRow != null)
            {
                var group = (Group)groupGV.CurrentRow.DataBoundItem;
                var form = new Form4(1, group.Id, 2, this);
                form.ShowDialog();
                if (DeccisionIndex == 0)
                {
                    this.studentAGV.Visible = true;
                    this.groupAGV.Visible = false;
                    this.studentAGV.DataSource = group.Students.ToList();
                }
                if (DeccisionIndex == 1)
                {

                }
            }
            else
            {
                var form = new Form4(2, 0, 2, this);
                form.ShowDialog();
                var groupService = new GroupService(_unit, _unit);
                if (DeccisionIndex == 0)
                {
                    this.groupAGV.Visible = true;
                    var allGroup = groupService.GetAllGroups();
                    groupAGV.DataSource = allGroup.ToList();
                }
                if (DeccisionIndex == 1)
                {

                }
            }
            DeccisionIndex = -1;
        }

        private void AdditionalForSpeciality(object sender, EventArgs e)
        {
            if (specialityGV.CurrentRow != null)
            {
                var speciality = (Speciality)specialityGV.CurrentRow.DataBoundItem;
                var form = new Form4(1, speciality.Id, 3, this);
                form.ShowDialog();
                if (DeccisionIndex == 0)
                {
                    var form1 = new Form11(speciality);
                    form1.ShowDialog();
                }
                if (DeccisionIndex == 1)
                {
                    this.groupAGV.Visible = true;
                    this.specialityAGV.Visible = false;
                    this.groupAGV.DataSource = speciality.Groups.ToList();
                }
            }
            else
            {
                var form = new Form4(2, 0, 3, this);
                form.ShowDialog();
                var specialityService = new SpecialityService(_unit, _unit);
                if (DeccisionIndex == 0)
                {
                    this.specialityAGV.Visible = true;
                    var allSpeciality = specialityService.GetAllSpeciality();
                    specialityAGV.DataSource = allSpeciality.ToList();
                }
                if (DeccisionIndex == 1)
                {
                    MessageBox.Show(@"dsgsdgs");
                }
            }
            DeccisionIndex = -1;
        }

        private void ReturnAdditional(object sender, EventArgs e)
        {
            /*No question...*/
        }

        private void SetAdditionalButtonParametr(EventHandler even)
        {
            this.ClearAdditionalBtn();
            btn_additional.Click += even;
        }

        private void ClearAdditionalBtn()
        {
            btn_additional.Click -= AdditionalForStudent;
            btn_additional.Click -= AdditionalForGroup;
            btn_additional.Click -= AdditionalForSpeciality;
            btn_additional.Click -= ReturnAdditional;
            btn_additional.Click -= ReturnAdditional;
            btn_additional.Click -= ReturnAdditional;
        }

    }
}

