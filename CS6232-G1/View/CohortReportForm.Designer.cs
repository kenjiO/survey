﻿namespace CS6232_G1.View
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CohortReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cohortComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.typeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.noDataPanel = new System.Windows.Forms.Panel();
            this.noDataLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CohortReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.noDataPanel.SuspendLayout();
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
            this.typeComboBox});
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
            this.cohortComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectBoxChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel3.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(100, 25);
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectBoxChanged);
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
            // noDataPanel
            // 
            this.noDataPanel.Controls.Add(this.noDataLabel);
            this.noDataPanel.Location = new System.Drawing.Point(0, 25);
            this.noDataPanel.Name = "noDataPanel";
            this.noDataPanel.Size = new System.Drawing.Size(699, 443);
            this.noDataPanel.TabIndex = 9;
            this.noDataPanel.Visible = false;
            // 
            // noDataLabel
            // 
            this.noDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noDataLabel.Location = new System.Drawing.Point(0, 44);
            this.noDataLabel.Name = "noDataLabel";
            this.noDataLabel.Size = new System.Drawing.Size(699, 43);
            this.noDataLabel.TabIndex = 0;
            this.noDataLabel.Text = "label1";
            this.noDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CohortReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 468);
            this.Controls.Add(this.noDataPanel);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CohortReportForm";
            this.Text = "Cohort Report";
            ((System.ComponentModel.ISupportInitialize)(this.CohortReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserReportBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.noDataPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cohortComboBox;
        private System.Windows.Forms.ToolStripComboBox typeComboBox;
        private System.Windows.Forms.BindingSource UserReportBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource CohortReportBindingSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Panel noDataPanel;
        private System.Windows.Forms.Label noDataLabel;
    }
}