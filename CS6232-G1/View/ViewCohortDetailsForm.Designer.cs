namespace CS6232_G1.View
{
    partial class ViewCohortDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCohortName = new System.Windows.Forms.Label();
            this.btnAddEvaluation = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.lvMembers = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvEvaluationSchedule = new System.Windows.Forms.DataGridView();
            this.ScheduleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.evaluationScheduleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.evaluationScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deleteCohortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluationSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Members";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(886, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Evaluation Schedule";
            // 
            // lblCohortName
            // 
            this.lblCohortName.AutoSize = true;
            this.lblCohortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCohortName.Location = new System.Drawing.Point(508, 34);
            this.lblCohortName.Name = "lblCohortName";
            this.lblCohortName.Size = new System.Drawing.Size(238, 29);
            this.lblCohortName.TabIndex = 4;
            this.lblCohortName.Text = "Details for Cohort #";
            // 
            // btnAddEvaluation
            // 
            this.btnAddEvaluation.AutoSize = true;
            this.btnAddEvaluation.Location = new System.Drawing.Point(890, 396);
            this.btnAddEvaluation.Name = "btnAddEvaluation";
            this.btnAddEvaluation.Size = new System.Drawing.Size(157, 36);
            this.btnAddEvaluation.TabIndex = 5;
            this.btnAddEvaluation.Text = "Add Evaluation";
            this.btnAddEvaluation.UseVisualStyleBackColor = true;
            this.btnAddEvaluation.Click += new System.EventHandler(this.btnAddEvaluation_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(227, 396);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(129, 36);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // lvMembers
            // 
            this.lvMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvMembers.FullRowSelect = true;
            this.lvMembers.Location = new System.Drawing.Point(12, 113);
            this.lvMembers.Name = "lvMembers";
            this.lvMembers.Size = new System.Drawing.Size(607, 277);
            this.lvMembers.TabIndex = 7;
            this.lvMembers.UseCompatibleStateImageBehavior = false;
            this.lvMembers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "1";
            this.columnHeader5.Text = "Emp Id";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "2";
            this.columnHeader6.Text = "First Name";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Tag = "2";
            this.columnHeader7.Text = "Last Name";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Tag = "3";
            this.columnHeader8.Text = "Email";
            // 
            // dgvEvaluationSchedule
            // 
            this.dgvEvaluationSchedule.AllowUserToAddRows = false;
            this.dgvEvaluationSchedule.AllowUserToDeleteRows = false;
            this.dgvEvaluationSchedule.AutoGenerateColumns = false;
            this.dgvEvaluationSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvEvaluationSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvaluationSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScheduleId,
            this.TypeId,
            this.TypeName,
            this.StageId,
            this.StageName,
            this.StartDate,
            this.EndDate,
            this.EditButton,
            this.DeleteButton});
            this.dgvEvaluationSchedule.DataSource = this.evaluationScheduleBindingSource1;
            this.dgvEvaluationSchedule.Location = new System.Drawing.Point(656, 113);
            this.dgvEvaluationSchedule.Name = "dgvEvaluationSchedule";
            this.dgvEvaluationSchedule.ReadOnly = true;
            this.dgvEvaluationSchedule.RowTemplate.Height = 28;
            this.dgvEvaluationSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvaluationSchedule.Size = new System.Drawing.Size(618, 277);
            this.dgvEvaluationSchedule.TabIndex = 9;
            this.dgvEvaluationSchedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvaluationSchedule_CellContentClick);
            // 
            // ScheduleId
            // 
            this.ScheduleId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ScheduleId.DataPropertyName = "ScheduleId";
            this.ScheduleId.HeaderText = "Schedule Id";
            this.ScheduleId.Name = "ScheduleId";
            this.ScheduleId.ReadOnly = true;
            this.ScheduleId.Visible = false;
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.HeaderText = "Type Id";
            this.TypeId.Name = "TypeId";
            this.TypeId.ReadOnly = true;
            this.TypeId.Visible = false;
            // 
            // TypeName
            // 
            this.TypeName.HeaderText = "Type";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // StageId
            // 
            this.StageId.DataPropertyName = "StageId";
            this.StageId.HeaderText = "Stage Id";
            this.StageId.Name = "StageId";
            this.StageId.ReadOnly = true;
            this.StageId.Visible = false;
            // 
            // StageName
            // 
            this.StageName.HeaderText = "Stage";
            this.StageName.Name = "StageName";
            this.StageName.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle1.Format = "MM/dd/yyyy";
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            dataGridViewCellStyle2.Format = "MM/dd/yyyy";
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.EndDate.HeaderText = "End Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // EditButton
            // 
            this.EditButton.HeaderText = "";
            this.EditButton.Name = "EditButton";
            this.EditButton.ReadOnly = true;
            this.EditButton.Text = "Edit";
            this.EditButton.UseColumnTextForButtonValue = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseColumnTextForButtonValue = true;
            // 
            // evaluationScheduleBindingSource1
            // 
            this.evaluationScheduleBindingSource1.DataSource = typeof(Evaluation.Model.EvaluationSchedule);
            // 
            // evaluationScheduleBindingSource
            // 
            this.evaluationScheduleBindingSource.DataSource = typeof(Evaluation.Model.EvaluationSchedule);
            // 
            // deleteCohortButton
            // 
            this.deleteCohortButton.AutoSize = true;
            this.deleteCohortButton.Location = new System.Drawing.Point(784, 34);
            this.deleteCohortButton.Name = "deleteCohortButton";
            this.deleteCohortButton.Size = new System.Drawing.Size(118, 30);
            this.deleteCohortButton.TabIndex = 10;
            this.deleteCohortButton.Text = "Delete Cohort";
            this.deleteCohortButton.UseVisualStyleBackColor = true;
            this.deleteCohortButton.Click += new System.EventHandler(this.DeleteCohortButton_Click);
            // 
            // ViewCohortDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1331, 478);
            this.Controls.Add(this.deleteCohortButton);
            this.Controls.Add(this.dgvEvaluationSchedule);
            this.Controls.Add(this.lvMembers);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnAddEvaluation);
            this.Controls.Add(this.lblCohortName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewCohortDetailsForm";
            this.Text = "Cohort Details";
            this.Load += new System.EventHandler(this.ViewCohortDetailsForm_Load);
            this.Shown += new System.EventHandler(this.ViewCohortDetailsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluationSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationScheduleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCohortName;
        private System.Windows.Forms.Button btnAddEvaluation;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.ListView lvMembers;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.DataGridView dgvEvaluationSchedule;
        private System.Windows.Forms.BindingSource evaluationScheduleBindingSource;
        private System.Windows.Forms.BindingSource evaluationScheduleBindingSource1;
        private System.Windows.Forms.Button deleteCohortButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}