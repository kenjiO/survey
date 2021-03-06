﻿namespace CS6232_G1.View
{
    partial class ViewEvaluationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSelfEvaluations = new System.Windows.Forms.DataGridView();
            this.scheduleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.evaluationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelfEvaluations = new System.Windows.Forms.Label();
            this.lblPeerEvaluations = new System.Windows.Forms.Label();
            this.dgvPeerEvaluations = new System.Windows.Forms.DataGridView();
            this.scheduleId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluationId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenButton1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelfEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeerEvaluations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelfEvaluations
            // 
            this.dgvSelfEvaluations.AllowUserToAddRows = false;
            this.dgvSelfEvaluations.AllowUserToDeleteRows = false;
            this.dgvSelfEvaluations.AutoGenerateColumns = false;
            this.dgvSelfEvaluations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelfEvaluations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvSelfEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelfEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduleId,
            this.TypeName,
            this.StageName,
            this.EndDate,
            this.OpenButton});
            this.dgvSelfEvaluations.DataSource = this.evaluationsBindingSource;
            this.dgvSelfEvaluations.Location = new System.Drawing.Point(50, 90);
            this.dgvSelfEvaluations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSelfEvaluations.Name = "dgvSelfEvaluations";
            this.dgvSelfEvaluations.ReadOnly = true;
            this.dgvSelfEvaluations.RowTemplate.Height = 28;
            this.dgvSelfEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelfEvaluations.Size = new System.Drawing.Size(620, 140);
            this.dgvSelfEvaluations.TabIndex = 10;
            this.dgvSelfEvaluations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelfEvaluations_CellContentClick);
            // 
            // scheduleId
            // 
            this.scheduleId.DataPropertyName = "scheduleId";
            this.scheduleId.HeaderText = "scheduleId";
            this.scheduleId.Name = "scheduleId";
            this.scheduleId.ReadOnly = true;
            this.scheduleId.Visible = false;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "typeName";
            this.TypeName.HeaderText = "Type";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // StageName
            // 
            this.StageName.DataPropertyName = "stageName";
            this.StageName.HeaderText = "Stage";
            this.StageName.Name = "StageName";
            this.StageName.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "endDate";
            dataGridViewCellStyle1.Format = "MM/dd/yyyy";
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.EndDate.HeaderText = "Close Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // OpenButton
            // 
            this.OpenButton.HeaderText = "";
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.ReadOnly = true;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseColumnTextForButtonValue = true;
            // 
            // evaluationsBindingSource
            // 
            this.evaluationsBindingSource.DataSource = typeof(Evaluation.Model.OpenEvaluation);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Your Evaluations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelfEvaluations
            // 
            this.lblSelfEvaluations.AutoSize = true;
            this.lblSelfEvaluations.Location = new System.Drawing.Point(47, 67);
            this.lblSelfEvaluations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelfEvaluations.Name = "lblSelfEvaluations";
            this.lblSelfEvaluations.Size = new System.Drawing.Size(83, 13);
            this.lblSelfEvaluations.TabIndex = 12;
            this.lblSelfEvaluations.Text = "Self Evaluations";
            // 
            // lblPeerEvaluations
            // 
            this.lblPeerEvaluations.AutoSize = true;
            this.lblPeerEvaluations.Location = new System.Drawing.Point(47, 263);
            this.lblPeerEvaluations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeerEvaluations.Name = "lblPeerEvaluations";
            this.lblPeerEvaluations.Size = new System.Drawing.Size(87, 13);
            this.lblPeerEvaluations.TabIndex = 13;
            this.lblPeerEvaluations.Text = "Peer Evaluations";
            // 
            // dgvPeerEvaluations
            // 
            this.dgvPeerEvaluations.AllowUserToAddRows = false;
            this.dgvPeerEvaluations.AllowUserToDeleteRows = false;
            this.dgvPeerEvaluations.AutoGenerateColumns = false;
            this.dgvPeerEvaluations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeerEvaluations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvPeerEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeerEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduleId1,
            this.evaluationId1,
            this.employeeName,
            this.roleId,
            this.roleName,
            this.typeName1,
            this.stageName1,
            this.endDate1,
            this.OpenButton1});
            this.dgvPeerEvaluations.DataSource = this.evaluationsBindingSource;
            this.dgvPeerEvaluations.Location = new System.Drawing.Point(50, 292);
            this.dgvPeerEvaluations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPeerEvaluations.Name = "dgvPeerEvaluations";
            this.dgvPeerEvaluations.ReadOnly = true;
            this.dgvPeerEvaluations.RowTemplate.Height = 28;
            this.dgvPeerEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeerEvaluations.Size = new System.Drawing.Size(620, 140);
            this.dgvPeerEvaluations.TabIndex = 14;
            this.dgvPeerEvaluations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeerEvaluations_CellContentClick);
            // 
            // scheduleId1
            // 
            this.scheduleId1.DataPropertyName = "scheduleId";
            this.scheduleId1.HeaderText = "scheduleId";
            this.scheduleId1.Name = "scheduleId1";
            this.scheduleId1.ReadOnly = true;
            this.scheduleId1.Visible = false;
            // 
            // evaluationId1
            // 
            this.evaluationId1.DataPropertyName = "evaluationId";
            this.evaluationId1.HeaderText = "evaluationId";
            this.evaluationId1.Name = "evaluationId1";
            this.evaluationId1.ReadOnly = true;
            this.evaluationId1.Visible = false;
            // 
            // employeeName
            // 
            this.employeeName.DataPropertyName = "employeeName";
            this.employeeName.FillWeight = 150F;
            this.employeeName.HeaderText = "Name";
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            // 
            // roleId
            // 
            this.roleId.DataPropertyName = "roleId";
            this.roleId.HeaderText = "roleId";
            this.roleId.Name = "roleId";
            this.roleId.ReadOnly = true;
            this.roleId.Visible = false;
            // 
            // roleName
            // 
            this.roleName.DataPropertyName = "roleName";
            this.roleName.HeaderText = "Evaluate As";
            this.roleName.Name = "roleName";
            this.roleName.ReadOnly = true;
            // 
            // typeName1
            // 
            this.typeName1.DataPropertyName = "typeName";
            this.typeName1.HeaderText = "Type";
            this.typeName1.Name = "typeName1";
            this.typeName1.ReadOnly = true;
            // 
            // stageName1
            // 
            this.stageName1.DataPropertyName = "stageName";
            this.stageName1.HeaderText = "Stage";
            this.stageName1.Name = "stageName1";
            this.stageName1.ReadOnly = true;
            // 
            // endDate1
            // 
            this.endDate1.DataPropertyName = "endDate";
            dataGridViewCellStyle2.Format = "MM/dd/yyyy";
            this.endDate1.DefaultCellStyle = dataGridViewCellStyle2;
            this.endDate1.HeaderText = "Close Date";
            this.endDate1.Name = "endDate1";
            this.endDate1.ReadOnly = true;
            // 
            // OpenButton1
            // 
            this.OpenButton1.HeaderText = "";
            this.OpenButton1.Name = "OpenButton1";
            this.OpenButton1.ReadOnly = true;
            this.OpenButton1.Text = "Open";
            this.OpenButton1.UseColumnTextForButtonValue = true;
            // 
            // ViewEvaluationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.ClientSize = new System.Drawing.Size(721, 471);
            this.Controls.Add(this.dgvPeerEvaluations);
            this.Controls.Add(this.lblPeerEvaluations);
            this.Controls.Add(this.lblSelfEvaluations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSelfEvaluations);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewEvaluationsForm";
            this.Text = "View Evaluations";
            this.Load += new System.EventHandler(this.ViewEvaluationDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelfEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeerEvaluations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelfEvaluations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelfEvaluations;
        private System.Windows.Forms.Label lblPeerEvaluations;
        private System.Windows.Forms.DataGridView dgvPeerEvaluations;
        private System.Windows.Forms.BindingSource evaluationsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewButtonColumn OpenButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluationId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate1;
        private System.Windows.Forms.DataGridViewButtonColumn OpenButton1;
    }
}