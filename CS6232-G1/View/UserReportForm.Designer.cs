namespace CS6232_G1.View
{
    partial class UserReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserReportForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.UserReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.employeeTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.typeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.generateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.stageComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.UserReportTitleDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportTitleDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserReportBindingSource
            // 
            this.UserReportBindingSource.DataSource = typeof(Evaluation.Model.UserReport);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.employeeTextBox,
            this.toolStripLabel3,
            this.typeComboBox,
            this.generateButton,
            this.toolStripLabel2,
            this.stageComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 28);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripLabel1.Size = new System.Drawing.Size(72, 25);
            this.toolStripLabel1.Text = "EmployeeId:";
            // 
            // employeeTextBox
            // 
            this.employeeTextBox.MaxLength = 15;
            this.employeeTextBox.Name = "employeeTextBox";
            this.employeeTextBox.Size = new System.Drawing.Size(50, 28);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 25);
            this.toolStripLabel3.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(100, 28);
            // 
            // generateButton
            // 
            this.generateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.generateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateButton.Image = ((System.Drawing.Image)(resources.GetObject("generateButton.Image")));
            this.generateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateButton.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.generateButton.Size = new System.Drawing.Size(68, 25);
            this.generateButton.Text = "Generate";
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 25);
            this.toolStripLabel2.Text = "Stage:";
            // 
            // stageComboBox
            // 
            this.stageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stageComboBox.Name = "stageComboBox";
            this.stageComboBox.Size = new System.Drawing.Size(100, 28);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "UserReportDataSet";
            reportDataSource1.Value = this.UserReportBindingSource;
            reportDataSource2.Name = "UserReportTitleDataSet";
            reportDataSource2.Value = this.UserReportTitleDataBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CS6232_G1.View.UserReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 28);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(687, 335);
            this.reportViewer.TabIndex = 8;
            // 
            // UserReportTitleDataBindingSource
            // 
            this.UserReportTitleDataBindingSource.DataSource = typeof(Evaluation.Model.UserReportTitleData);
            // 
            // UserReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 363);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UserReportForm";
            this.Text = "User Report";
            this.Load += new System.EventHandler(this.UserReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportTitleDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox employeeTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox stageComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox typeComboBox;
        private System.Windows.Forms.ToolStripButton generateButton;
        private System.Windows.Forms.BindingSource UserReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource UserReportTitleDataBindingSource;
    }
}