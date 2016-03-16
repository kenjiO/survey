namespace CS6232_G1.View
{
    partial class AddMembersToCohortForm
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
            this.lblAddMember = new System.Windows.Forms.Label();
            this.lvEmployeeList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddMembers = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddMember
            // 
            this.lblAddMember.AutoSize = true;
            this.lblAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddMember.Location = new System.Drawing.Point(274, 36);
            this.lblAddMember.Name = "lblAddMember";
            this.lblAddMember.Size = new System.Drawing.Size(310, 29);
            this.lblAddMember.TabIndex = 0;
            this.lblAddMember.Text = "Add Members to Cohort #";
            // 
            // lvEmployeeList
            // 
            this.lvEmployeeList.CheckBoxes = true;
            this.lvEmployeeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvEmployeeList.Location = new System.Drawing.Point(56, 98);
            this.lvEmployeeList.Name = "lvEmployeeList";
            this.lvEmployeeList.Size = new System.Drawing.Size(772, 402);
            this.lvEmployeeList.TabIndex = 1;
            this.lvEmployeeList.UseCompatibleStateImageBehavior = false;
            this.lvEmployeeList.View = System.Windows.Forms.View.Details;
            this.lvEmployeeList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvEmployeeList_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "1";
            this.columnHeader1.Text = "Emp ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "2";
            this.columnHeader2.Text = "First Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "2";
            this.columnHeader3.Text = "Last Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "3";
            this.columnHeader4.Text = "Email";
            // 
            // btnAddMembers
            // 
            this.btnAddMembers.AutoSize = true;
            this.btnAddMembers.Location = new System.Drawing.Point(56, 516);
            this.btnAddMembers.Name = "btnAddMembers";
            this.btnAddMembers.Size = new System.Drawing.Size(118, 30);
            this.btnAddMembers.TabIndex = 2;
            this.btnAddMembers.Text = "Add Members";
            this.btnAddMembers.UseVisualStyleBackColor = true;
            this.btnAddMembers.Click += new System.EventHandler(this.btnAddMembers_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(753, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddMembersToCohortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 628);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddMembers);
            this.Controls.Add(this.lvEmployeeList);
            this.Controls.Add(this.lblAddMember);
            this.Name = "AddMembersToCohortForm";
            this.Text = "AddMembersToCohort";
            this.Load += new System.EventHandler(this.AddMembersToCohortForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddMember;
        private System.Windows.Forms.ListView lvEmployeeList;
        private System.Windows.Forms.Button btnAddMembers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnCancel;
    }
}