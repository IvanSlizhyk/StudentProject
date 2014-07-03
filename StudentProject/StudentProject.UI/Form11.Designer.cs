namespace StudentProject.UI
{
    partial class Form11
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBox_Term = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.disciplineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.add_OnLBox = new System.Windows.Forms.ListBox();
            this.addLBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.journalCurriculumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalCurriculumBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentProject.UI.Resources.Curriculum;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.label1.Name = "label1";
            // 
            // cmBox_Term
            // 
            this.cmBox_Term.FormattingEnabled = true;
            resources.ApplyResources(this.cmBox_Term, "cmBox_Term");
            this.cmBox_Term.Name = "cmBox_Term";
            this.cmBox_Term.SelectedIndexChanged += new System.EventHandler(this.cmBox_Term_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Name = "label4";
            // 
            // disciplineBindingSource
            // 
            this.disciplineBindingSource.DataSource = typeof(StudentProject.Core.Entities.Discipline);
            // 
            // add_OnLBox
            // 
            this.add_OnLBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_OnLBox.DataSource = this.disciplineBindingSource;
            this.add_OnLBox.DisplayMember = "Name";
            resources.ApplyResources(this.add_OnLBox, "add_OnLBox");
            this.add_OnLBox.FormattingEnabled = true;
            this.add_OnLBox.Name = "add_OnLBox";
            this.add_OnLBox.ValueMember = "Id";
            this.add_OnLBox.DoubleClick += new System.EventHandler(this.add_OnLBox_DoubleClick);
            // 
            // addLBox
            // 
            this.addLBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addLBox.DataSource = this.disciplineBindingSource;
            this.addLBox.DisplayMember = "Name";
            resources.ApplyResources(this.addLBox, "addLBox");
            this.addLBox.FormattingEnabled = true;
            this.addLBox.Name = "addLBox";
            this.addLBox.ValueMember = "Id";
            this.addLBox.Click += new System.EventHandler(this.addLBox_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Name = "label3";
            // 
            // journalCurriculumBindingSource
            // 
            this.journalCurriculumBindingSource.DataSource = typeof(StudentProject.Core.Entities.JournalCurriculum);
            // 
            // Form11
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLBox);
            this.Controls.Add(this.add_OnLBox);
            this.Controls.Add(this.cmBox_Term);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form11";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form11_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalCurriculumBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBox_Term;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource disciplineBindingSource;
        private System.Windows.Forms.ListBox add_OnLBox;
        private System.Windows.Forms.ListBox addLBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource journalCurriculumBindingSource;
    }
}