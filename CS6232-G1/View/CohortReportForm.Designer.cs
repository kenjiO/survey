namespace CS6232_G1.View
{
    partial class CohortReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CohortReportForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CohortReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cohortComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.typeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.generateButton = new System.Windows.Forms.ToolStripButton();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CohortReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CohortReportBindingSource
            // 
            this.CohortReportBindingSource.DataSource = typeof(Evaluation.Model.CohortReport);
            // 
            // UserReportBindingSource
            // 
            this.UserReportBindingSource.DataSource = this.CohortReportBindingSource;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cohortComboBox,
            this.toolStripLabel3,
            this.typeComboBox,
            this.generateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(699, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripLabel2.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel2.Text = "Cohort:";
            // 
            // cohortComboBox
            // 
            this.cohortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cohortComboBox.Name = "cohortComboBox";
            this.cohortComboBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripLabel3.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel3.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(100, 25);
            // 
            // generateButton
            // 
            this.generateButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.generateButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.generateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateButton.Image = ((System.Drawing.Image)(resources.GetObject("generateButton.Image")));
            this.generateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateButton.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.generateButton.Size = new System.Drawing.Size(68, 22);
            this.generateButton.Text = "Generate";
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "CohortReportData";
            reportDataSource1.Value = this.CohortReportBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CS6232_G1.View.CohortReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 25);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowToolBar = false;
            this.reportViewer.Size = new System.Drawing.Size(699, 443);
            this.reportViewer.TabIndex = 8;
            this.reportViewer.WaitControlDisplayAfter = 100;
            // 
            // CohortReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 468);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CohortReportForm";
            this.Text = "Cohort Report";
            this.Load += new System.EventHandler(this.CohortReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CohortReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cohortComboBox;
        private System.Windows.Forms.ToolStripComboBox typeComboBox;
        private System.Windows.Forms.ToolStripButton generateButton;
        private System.Windows.Forms.BindingSource UserReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource CohortReportBindingSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
    }
}