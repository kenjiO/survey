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
            this.membersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvEvaluationSchedule = new System.Windows.Forms.ListView();
            this.lblCohortName = new System.Windows.Forms.Label();
            this.btnAddEvaluation = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // membersCheckedListBox
            // 
            this.membersCheckedListBox.FormattingEnabled = true;
            this.membersCheckedListBox.Location = new System.Drawing.Point(64, 113);
            this.membersCheckedListBox.Name = "membersCheckedListBox";
            this.membersCheckedListBox.Size = new System.Drawing.Size(232, 277);
            this.membersCheckedListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Members";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(721, 90);
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
            this.lvEvaluationSchedule.Location = new System.Drawing.Point(448, 113);
            this.lvEvaluationSchedule.Name = "lvEvaluationSchedule";
            this.lvEvaluationSchedule.Size = new System.Drawing.Size(702, 277);
            this.lvEvaluationSchedule.TabIndex = 3;
            this.lvEvaluationSchedule.UseCompatibleStateImageBehavior = false;
            this.lvEvaluationSchedule.View = System.Windows.Forms.View.Details;
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
            this.btnAddEvaluation.Location = new System.Drawing.Point(687, 417);
            this.btnAddEvaluation.Name = "btnAddEvaluation";
            this.btnAddEvaluation.Size = new System.Drawing.Size(212, 36);
            this.btnAddEvaluation.TabIndex = 5;
            this.btnAddEvaluation.Text = "Add Evaluaton to Schedule";
            this.btnAddEvaluation.UseVisualStyleBackColor = true;
            this.btnAddEvaluation.Click += new System.EventHandler(this.btnAddEvaluation_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(105, 417);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(129, 36);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stage";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start Date";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "EndDate";
            // 
            // ViewCohortDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 504);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnAddEvaluation);
            this.Controls.Add(this.lblCohortName);
            this.Controls.Add(this.lvEvaluationSchedule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.membersCheckedListBox);
            this.Name = "ViewCohortDetailsForm";
            this.Text = "Cohort Details";
            this.Load += new System.EventHandler(this.ViewCohortDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox membersCheckedListBox;
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
    }
}