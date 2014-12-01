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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;


namespace StudentProject.UI
{
    public partial class Form15 : Form
    {
        private StudentContext _context;
        private UnitOfWork _unit;
        public List<string> TermList { get; set; }
        public Student Student { get; set; }

        public Form15(int studentId)
        {
            InitializeComponent();
            var context = new StudentContext(Resources.ConnectionString);
            _context = context;
            _unit = new UnitOfWork(_context);
            TermList = new List<string>();

            this.SetWorkParametr(studentId);
        }

        private void SetWorkParametr(int studentId)
        {
            var studentService = new StudentService(_unit, _unit);
            Student = studentService.GetStudentById(studentId);

            label1.Text = Student.Surname + @" " + Student.Name + @" " + Student.Patronymic;

            GetAllDataFromDb();
        }

        private void GetAllDataFromDb()
        {
            GetGroupFromDb();
            GetTermList();
            GetProgressFromDb();

        }

        private void GetProgressFromDb()
        {
            var group = (Group)cmBox_Group.SelectedItem;
            var curriculum = group.Speciality.Curricula.ToList().Find(e => e.Term == Convert.ToInt32(cmBox_Term.Text));
            var journalCurriculum = curriculum.JournalCurricula.ToList();
            var progresses = Student.Progresses.ToList().Find(e => e.Term == Convert.ToInt32(cmBox_Term.Text) && e.GroupId == group.Id);
            var journalProgresses = progresses.JournalProgresses.ToList();

            var data = GenerateStudentProgressData(journalCurriculum, journalProgresses);
            ProgressGV.DataSource = data;
        }

        private void GetTermList()
        {
            TermList = new List<string>();
            var group = (Group)cmBox_Group.SelectedItem;
            this.SetTermList(group.Speciality.TermNumber);
            cmBox_Term.DataSource = TermList;
        }

        private void SetTermList(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                TermList.Add(item: i.ToString());
            }
        }

        private void GetGroupFromDb()
        {
            var groups = Student.Groups.ToList();
            cmBox_Group.DataSource = groups;
        }

        private List<StudentProgressViewModel> GenerateStudentProgressData(List<JournalCurriculum> journalCurriculum, List<JournalProgress> journalProgresses)
        {
            var studentProgresses = new List<StudentProgressViewModel>();

            for (var i = 0; i < journalCurriculum.Count; i++)
            {
                var a = new StudentProgressViewModel(journalCurriculum[i], journalProgresses[i]);
                studentProgresses.Add(a);
            }

            return studentProgresses;
        }

        private void cmBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTermList();
            GetProgressFromDb();
        }

        private void cmBox_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProgressFromDb();
        }

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, new System.IO.FileStream("St_s.pdf", System.IO.FileMode.Create));
            document.Open();
            var baseFont = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);
            var textFont = new Font(baseFont, 12, 2);
            textFont.Color = Color.BLACK;
            document.Add(new Paragraph("Успеваемость: \nСтудент -  " + Student.Surname + " " + Student.Name + " " +
                                       Student.Patronymic + "\nГруппа -  " + ((Group)cmBox_Group.SelectedItem).GroupNumber + "\nСеместр -  " +
                                       cmBox_Term.SelectedItem + "\n\n", textFont));
            var table = new PdfPTable(ProgressGV.ColumnCount);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            var cell = new PdfPCell(new Phrase("cell", textFont));
            cell.FixedHeight = 20.0F;
            cell.BorderColor = Color.BLACK;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Phrase = new Phrase("Дисциплина", textFont);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Форма отчётности", textFont);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Отметка формы отчётности", textFont);
            table.AddCell(cell);
            for (int i = 0; i < ProgressGV.RowCount; i++)
                for (int j = 0; j < ProgressGV.ColumnCount; j++)
                {
                    cell.Phrase = new Phrase(ProgressGV.Rows[i].Cells[j].Value.ToString(), textFont);
                    table.AddCell(cell);
                }
            document.Add(table);
            document.Close();
            writer.Close();
            //System.Diagnostics.Process.Start("Opera.exe", System.IO.Directory.GetCurrentDirectory() + @"\St_s.pdf");
            System.Diagnostics.Process.Start("St_s.pdf");
        }
    }
}
