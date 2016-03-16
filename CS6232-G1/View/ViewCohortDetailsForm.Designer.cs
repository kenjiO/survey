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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvEvaluationSchedule = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCohortName = new System.Windows.Forms.Label();
            this.btnAddEvaluation = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.lvMembers = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Members";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(921, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Evaluation Schedule";
            // 
            // lvEvaluationSchedule
            // 
            this.lvEvaluationSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvEvaluationSchedule.Location = new System.Drawing.Point(700, 113);
            this.lvEvaluationSchedule.Name = "lvEvaluationSchedule";
            this.lvEvaluationSchedule.Size = new System.Drawing.Size(610, 277);
            this.lvEvaluationSchedule.TabIndex = 3;
            this.lvEvaluationSchedule.UseCompatibleStateImageBehavior = false;
            this.lvEvaluationSchedule.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "1";
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 164;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "1";
            this.columnHeader2.Text = "Stage";
            this.columnHeader2.Width = 148;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "1";
            this.columnHeader3.Text = "Start Date";
            this.columnHeader3.Width = 218;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "1";
            this.columnHeader4.Text = "End Date";
            this.columnHeader4.Width = 154;
            // 
            // lblCohortName
            // 
            this.lblCohortName.AutoSize = true;
            this.lblCohortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCohortName.Location = new System.Drawing.Point(432, 23);
            this.lblCohortName.Name = "lblCohortName";
            this.lblCohortName.Size = new System.Drawing.Size(179, 29);
            this.lblCohortName.TabIndex = 4;
            this.lblCohortName.Text = "Cohort Details";
            // 
            // btnAddEvaluation
            // 
            this.btnAddEvaluation.AutoSize = true;
            this.btnAddEvaluation.Location = new System.Drawing.Point(904, 396);
            this.btnAddEvaluation.Name = "btnAddEvaluation";
            this.btnAddEvaluation.Size = new System.Drawing.Size(212, 36);
            this.btnAddEvaluation.TabIndex = 5;
            this.btnAddEvaluation.Text = "Add Evaluaton to Schedule";
            this.btnAddEvaluation.UseVisualStyleBackColor = true;
            this.btnAddEvaluation.Click += new System.EventHandler(this.btnAddEvaluation_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(257, 396);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(129, 36);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            // 
            // lvMembers
            // 
            this.lvMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvMembers.Location = new System.Drawing.Point(27, 113);
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
            // ViewCohortDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 504);
            this.Controls.Add(this.lvMembers);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnAddEvaluation);
            this.Controls.Add(this.lblCohortName);
            this.Controls.Add(this.lvEvaluationSchedule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewCohortDetailsForm";
            this.Text = "Cohort Details";
            this.Load += new System.EventHandler(this.ViewCohortDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvEvaluationSchedule;
        private System.Windows.Forms.Label lblCohortName;
        private System.Windows.Forms.Button btnAddEvaluation;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvMembers;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}