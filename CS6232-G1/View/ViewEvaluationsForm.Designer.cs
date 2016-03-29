namespace CS6232_G1.View
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
            this.dgvSelfEvaluations = new System.Windows.Forms.DataGridView();
            this.evaluationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvOtherEvaluations = new System.Windows.Forms.DataGridView();
            this.evaluationScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scheduleIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.scheduleIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenButton1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelfEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource)).BeginInit();
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
            this.scheduleIdDataGridViewTextBoxColumn1,
            this.TypeName,
            this.StageName,
            this.CloseDate,
            this.OpenButton});
            this.dgvSelfEvaluations.DataSource = this.evaluationsBindingSource;
            this.dgvSelfEvaluations.Location = new System.Drawing.Point(75, 139);
            this.dgvSelfEvaluations.Name = "dgvSelfEvaluations";
            this.dgvSelfEvaluations.ReadOnly = true;
            this.dgvSelfEvaluations.RowTemplate.Height = 28;
            this.dgvSelfEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelfEvaluations.Size = new System.Drawing.Size(930, 277);
            this.dgvSelfEvaluations.TabIndex = 10;
            // 
            // evaluationsBindingSource
            // 
            this.evaluationsBindingSource.DataSource = typeof(Evaluation.Model.OpenEvaluation);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Your Evaluations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Self Evaluations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Evaluate Others";
            // 
            // dgvOtherEvaluations
            // 
            this.dgvOtherEvaluations.AllowUserToAddRows = false;
            this.dgvOtherEvaluations.AllowUserToDeleteRows = false;
            this.dgvOtherEvaluations.AutoGenerateColumns = false;
            this.dgvOtherEvaluations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOtherEvaluations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvOtherEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scheduleIdDataGridViewTextBoxColumn,
            this.employeeName,
            this.roleId,
            this.roleName,
            this.typeName1,
            this.stageName1,
            this.closeDate1,
            this.OpenButton1});
            this.dgvOtherEvaluations.DataSource = this.evaluationsBindingSource;
            this.dgvOtherEvaluations.Location = new System.Drawing.Point(75, 511);
            this.dgvOtherEvaluations.Name = "dgvOtherEvaluations";
            this.dgvOtherEvaluations.ReadOnly = true;
            this.dgvOtherEvaluations.RowTemplate.Height = 28;
            this.dgvOtherEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOtherEvaluations.Size = new System.Drawing.Size(930, 277);
            this.dgvOtherEvaluations.TabIndex = 14;
            // 
            // evaluationScheduleBindingSource
            // 
            this.evaluationScheduleBindingSource.DataSource = typeof(Evaluation.Model.OpenEvaluation);
            // 
            // scheduleIdDataGridViewTextBoxColumn1
            // 
            this.scheduleIdDataGridViewTextBoxColumn1.DataPropertyName = "scheduleId";
            this.scheduleIdDataGridViewTextBoxColumn1.HeaderText = "scheduleId";
            this.scheduleIdDataGridViewTextBoxColumn1.Name = "scheduleIdDataGridViewTextBoxColumn1";
            this.scheduleIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.scheduleIdDataGridViewTextBoxColumn1.Visible = false;
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
            // CloseDate
            // 
            this.CloseDate.DataPropertyName = "closeDate";
            this.CloseDate.HeaderText = "Close Date";
            this.CloseDate.Name = "CloseDate";
            this.CloseDate.ReadOnly = true;
            // 
            // OpenButton
            // 
            this.OpenButton.HeaderText = "";
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.ReadOnly = true;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseColumnTextForButtonValue = true;
            // 
            // scheduleIdDataGridViewTextBoxColumn
            // 
            this.scheduleIdDataGridViewTextBoxColumn.DataPropertyName = "scheduleId";
            this.scheduleIdDataGridViewTextBoxColumn.HeaderText = "scheduleId";
            this.scheduleIdDataGridViewTextBoxColumn.Name = "scheduleIdDataGridViewTextBoxColumn";
            this.scheduleIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.scheduleIdDataGridViewTextBoxColumn.Visible = false;
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
            // closeDate1
            // 
            this.closeDate1.DataPropertyName = "closeDate";
            this.closeDate1.HeaderText = "Close Date";
            this.closeDate1.Name = "closeDate1";
            this.closeDate1.ReadOnly = true;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.ClientSize = new System.Drawing.Size(1082, 840);
            this.Controls.Add(this.dgvOtherEvaluations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSelfEvaluations);
            this.Name = "ViewEvaluationsForm";
            this.Text = "ViewEvaluationDetailsForm";
            this.Load += new System.EventHandler(this.ViewEvaluationDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelfEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelfEvaluations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource evaluationScheduleBindingSource;
        private System.Windows.Forms.DataGridView dgvOtherEvaluations;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageId;
        private System.Windows.Forms.BindingSource evaluationsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StageId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseDate;
        private System.Windows.Forms.DataGridViewButtonColumn OpenButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDate1;
        private System.Windows.Forms.DataGridViewButtonColumn OpenButton1;
    }
}