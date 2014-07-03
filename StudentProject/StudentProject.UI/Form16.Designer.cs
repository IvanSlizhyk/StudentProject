namespace StudentProject.UI
{
    partial class Form16
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmBox_AppraisalFormReport = new System.Windows.Forms.ComboBox();
            this.appraisalFormReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_add = new System.Windows.Forms.Button();
            this.cmBox_Group = new System.Windows.Forms.ComboBox();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addLBox = new System.Windows.Forms.ListBox();
            this.add_OnLBox = new System.Windows.Forms.ListBox();
            this.cmBox_Term = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.appraisalFormReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(286, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "APPRAISAL FORM REPORT";
            // 
            // cmBox_AppraisalFormReport
            // 
            this.cmBox_AppraisalFormReport.DataSource = this.appraisalFormReportBindingSource;
            this.cmBox_AppraisalFormReport.DisplayMember = "Value";
            this.cmBox_AppraisalFormReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBox_AppraisalFormReport.FormattingEnabled = true;
            this.cmBox_AppraisalFormReport.Location = new System.Drawing.Point(289, 415);
            this.cmBox_AppraisalFormReport.Name = "cmBox_AppraisalFormReport";
            this.cmBox_AppraisalFormReport.Size = new System.Drawing.Size(150, 21);
            this.cmBox_AppraisalFormReport.TabIndex = 49;
            this.cmBox_AppraisalFormReport.ValueMember = "Id";
            // 
            // appraisalFormReportBindingSource
            // 
            this.appraisalFormReportBindingSource.DataSource = typeof(StudentProject.Core.Entities.AppraisalFormReport);
            // 
            // btn_add
            // 
            this.btn_add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_add.Location = new System.Drawing.Point(320, 456);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(80, 30);
            this.btn_add.TabIndex = 51;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // cmBox_Group
            // 
            this.cmBox_Group.DataSource = this.groupBindingSource;
            this.cmBox_Group.DisplayMember = "GroupNumber";
            this.cmBox_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBox_Group.FormattingEnabled = true;
            this.cmBox_Group.Location = new System.Drawing.Point(290, 179);
            this.cmBox_Group.Name = "cmBox_Group";
            this.cmBox_Group.Size = new System.Drawing.Size(150, 21);
            this.cmBox_Group.TabIndex = 53;
            this.cmBox_Group.ValueMember = "Id";
            this.cmBox_Group.SelectedIndexChanged += new System.EventHandler(this.cmBox_Group_SelectedIndexChanged_1);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(StudentProject.Core.Entities.Group);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(287, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "GROUP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Impact", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(41, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "ADD-ON DISCIPLINE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Impact", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(481, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 65;
            this.label6.Text = "ADD DISCIPLINE";
            // 
            // addLBox
            // 
            this.addLBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addLBox.DisplayMember = "Name";
            this.addLBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.addLBox.FormattingEnabled = true;
            this.addLBox.ItemHeight = 17;
            this.addLBox.Location = new System.Drawing.Point(471, 225);
            this.addLBox.Name = "addLBox";
            this.addLBox.Size = new System.Drawing.Size(224, 412);
            this.addLBox.TabIndex = 64;
            this.addLBox.ValueMember = "Id";
            this.addLBox.Click += new System.EventHandler(this.addLBox_Click);
            // 
            // add_OnLBox
            // 
            this.add_OnLBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add_OnLBox.DisplayMember = "Name";
            this.add_OnLBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.add_OnLBox.FormattingEnabled = true;
            this.add_OnLBox.ItemHeight = 17;
            this.add_OnLBox.Location = new System.Drawing.Point(31, 225);
            this.add_OnLBox.Name = "add_OnLBox";
            this.add_OnLBox.Size = new System.Drawing.Size(224, 412);
            this.add_OnLBox.TabIndex = 63;
            this.add_OnLBox.ValueMember = "Id";
            this.add_OnLBox.Click += new System.EventHandler(this.add_OnLBox_Click);
            // 
            // cmBox_Term
            // 
            this.cmBox_Term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBox_Term.FormattingEnabled = true;
            this.cmBox_Term.Location = new System.Drawing.Point(290, 221);
            this.cmBox_Term.Name = "cmBox_Term";
            this.cmBox_Term.Size = new System.Drawing.Size(150, 21);
            this.cmBox_Term.TabIndex = 62;
            this.cmBox_Term.SelectedIndexChanged += new System.EventHandler(this.cmBox_Term_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Impact", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(287, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 61;
            this.label7.Text = "TERM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.label8.Font = new System.Drawing.Font("Impact", 20.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(295, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 34);
            this.label8.TabIndex = 60;
            this.label8.Text = "PROGRESS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentProject.UI.Resources.Progress;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(718, 690);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 689);
            this.Controls.Add(this.cmBox_Group);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmBox_AppraisalFormReport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addLBox);
            this.Controls.Add(this.add_OnLBox);
            this.Controls.Add(this.cmBox_Term);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "University";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form16_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.appraisalFormReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBox_AppraisalFormReport;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmBox_Group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox addLBox;
        private System.Windows.Forms.ListBox add_OnLBox;
        private System.Windows.Forms.ComboBox cmBox_Term;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource appraisalFormReportBindingSource;
        private System.Windows.Forms.BindingSource groupBindingSource;
    }
}