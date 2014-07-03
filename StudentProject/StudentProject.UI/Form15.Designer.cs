namespace StudentProject.UI
{
    partial class Form15
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBox_Group = new System.Windows.Forms.ComboBox();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmBox_Term = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgressGV = new System.Windows.Forms.DataGridView();
            this.disciplineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formReportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appraisalFormReportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentProgressViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalCurriculumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.journalProgressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentProgressViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalCurriculumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalProgressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Impact", 11.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(39, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "STUDENT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Impact", 11.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(100, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "1";
            // 
            // cmBox_Group
            // 
            this.cmBox_Group.DataSource = this.groupBindingSource;
            this.cmBox_Group.DisplayMember = "GroupNumber";
            this.cmBox_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBox_Group.FormattingEnabled = true;
            this.cmBox_Group.Location = new System.Drawing.Point(49, 103);
            this.cmBox_Group.Name = "cmBox_Group";
            this.cmBox_Group.Size = new System.Drawing.Size(150, 21);
            this.cmBox_Group.TabIndex = 44;
            this.cmBox_Group.ValueMember = "Id";
            this.cmBox_Group.SelectedIndexChanged += new System.EventHandler(this.cmBox_Group_SelectedIndexChanged);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(StudentProject.Core.Entities.Group);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(46, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "GROUP";
            // 
            // cmBox_Term
            // 
            this.cmBox_Term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBox_Term.FormattingEnabled = true;
            this.cmBox_Term.Location = new System.Drawing.Point(236, 103);
            this.cmBox_Term.Name = "cmBox_Term";
            this.cmBox_Term.Size = new System.Drawing.Size(150, 21);
            this.cmBox_Term.TabIndex = 48;
            this.cmBox_Term.SelectedIndexChanged += new System.EventHandler(this.cmBox_Term_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(233, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "TERM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Impact", 11.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(39, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 49;
            this.label3.Text = "!!!!!!!";
            // 
            // ProgressGV
            // 
            this.ProgressGV.AllowUserToAddRows = false;
            this.ProgressGV.AllowUserToDeleteRows = false;
            this.ProgressGV.AutoGenerateColumns = false;
            this.ProgressGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProgressGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProgressGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disciplineDataGridViewTextBoxColumn,
            this.formReportDataGridViewTextBoxColumn,
            this.appraisalFormReportDataGridViewTextBoxColumn});
            this.ProgressGV.DataSource = this.studentProgressViewModelBindingSource;
            this.ProgressGV.Location = new System.Drawing.Point(27, 144);
            this.ProgressGV.Name = "ProgressGV";
            this.ProgressGV.ReadOnly = true;
            this.ProgressGV.Size = new System.Drawing.Size(389, 513);
            this.ProgressGV.TabIndex = 50;
            // 
            // disciplineDataGridViewTextBoxColumn
            // 
            this.disciplineDataGridViewTextBoxColumn.DataPropertyName = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.HeaderText = "Discipline";
            this.disciplineDataGridViewTextBoxColumn.Name = "disciplineDataGridViewTextBoxColumn";
            this.disciplineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formReportDataGridViewTextBoxColumn
            // 
            this.formReportDataGridViewTextBoxColumn.DataPropertyName = "FormReport";
            this.formReportDataGridViewTextBoxColumn.HeaderText = "FormReport";
            this.formReportDataGridViewTextBoxColumn.Name = "formReportDataGridViewTextBoxColumn";
            this.formReportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // appraisalFormReportDataGridViewTextBoxColumn
            // 
            this.appraisalFormReportDataGridViewTextBoxColumn.DataPropertyName = "AppraisalFormReport";
            this.appraisalFormReportDataGridViewTextBoxColumn.HeaderText = "AppraisalFormReport";
            this.appraisalFormReportDataGridViewTextBoxColumn.Name = "appraisalFormReportDataGridViewTextBoxColumn";
            this.appraisalFormReportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // studentProgressViewModelBindingSource
            // 
            this.studentProgressViewModelBindingSource.DataSource = typeof(StudentProject.UI.StudentProgressViewModel);
            // 
            // journalCurriculumBindingSource
            // 
            this.journalCurriculumBindingSource.DataSource = typeof(StudentProject.Core.Entities.JournalCurriculum);
            // 
            // journalProgressBindingSource
            // 
            this.journalProgressBindingSource.DataSource = typeof(StudentProject.Core.Entities.JournalProgress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentProject.UI.Properties.Resources.ViewProgress;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(441, 692);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 691);
            this.Controls.Add(this.ProgressGV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmBox_Term);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmBox_Group);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "University";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form15_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentProgressViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalCurriculumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journalProgressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBox_Group;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource journalProgressBindingSource;
        private System.Windows.Forms.BindingSource journalCurriculumBindingSource;
        private System.Windows.Forms.ComboBox cmBox_Term;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ProgressGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn disciplineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formReportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appraisalFormReportDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource studentProgressViewModelBindingSource;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}