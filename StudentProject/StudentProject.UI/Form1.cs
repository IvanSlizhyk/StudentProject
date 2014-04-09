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
using StudentProject.DALInterfaces;
using StudentProject.EFData;
using StudentProject.Services;
using StudentProject.UI.Properties;

namespace StudentProject.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }





    }
}



