namespace CS6232_G1.View
{
    partial class MainForm
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
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAdminOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripEmployee = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testEmployeeMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDefault = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.createNewCohortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAdmin.SuspendLayout();
            this.menuStripEmployee.SuspendLayout();
            this.menuStripDefault.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testAdminOptionsToolStripMenuItem,
            this.stagesToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 48);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(636, 24);
            this.menuStripAdmin.TabIndex = 1;
            this.menuStripAdmin.Text = "menuStripAdmin";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testAdminOptionsToolStripMenuItem
            // 
            this.testAdminOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewCohortToolStripMenuItem});
            this.testAdminOptionsToolStripMenuItem.Name = "testAdminOptionsToolStripMenuItem";
            this.testAdminOptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.testAdminOptionsToolStripMenuItem.Text = "Cohorts";
            // 
            // stagesToolStripMenuItem
            // 
            this.stagesToolStripMenuItem.Name = "stagesToolStripMenuItem";
            this.stagesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.stagesToolStripMenuItem.Text = "Stages";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // menuStripEmployee
            // 
            this.menuStripEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.testEmployeeMenuToolStripMenuItem});
            this.menuStripEmployee.Location = new System.Drawing.Point(0, 24);
            this.menuStripEmployee.Name = "menuStripEmployee";
            this.menuStripEmployee.Size = new System.Drawing.Size(636, 24);
            this.menuStripEmployee.TabIndex = 2;
            this.menuStripEmployee.Text = "menuStripEmployee";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testEmployeeMenuToolStripMenuItem
            // 
            this.testEmployeeMenuToolStripMenuItem.Name = "testEmployeeMenuToolStripMenuItem";
            this.testEmployeeMenuToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.testEmployeeMenuToolStripMenuItem.Text = "Evaluations";
            // 
            // menuStripDefault
            // 
            this.menuStripDefault.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.testToolStripMenuItem});
            this.menuStripDefault.Location = new System.Drawing.Point(0, 0);
            this.menuStripDefault.Name = "menuStripDefault";
            this.menuStripDefault.Size = new System.Drawing.Size(636, 24);
            this.menuStripDefault.TabIndex = 3;
            this.menuStripDefault.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem2.Text = "File";
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Controls.Add(this.ErrorMsgLabel);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.PasswordTextBox);
            this.LoginPanel.Controls.Add(this.UsernameTextBox);
            this.LoginPanel.Location = new System.Drawing.Point(148, 100);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(340, 202);
            this.LoginPanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorMsgLabel.Location = new System.Drawing.Point(12, 24);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(310, 13);
            this.ErrorMsgLabel.TabIndex = 3;
            this.ErrorMsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(131, 136);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(102, 91);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(209, 20);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.Text = "admin1";
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(102, 52);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(209, 20);
            this.UsernameTextBox.TabIndex = 0;
            this.UsernameTextBox.Text = "admin1@westga.edu";
            // 
            // createNewCohortToolStripMenuItem
            // 
            this.createNewCohortToolStripMenuItem.Name = "createNewCohortToolStripMenuItem";
            this.createNewCohortToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createNewCohortToolStripMenuItem.Text = "Create New Cohort";
            this.createNewCohortToolStripMenuItem.Click += new System.EventHandler(this.createNewCohortToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 417);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.menuStripAdmin);
            this.Controls.Add(this.menuStripEmployee);
            this.Controls.Add(this.menuStripDefault);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripAdmin;
            this.Name = "MainForm";
            this.Text = "CS6232-G1 Evaluations";
            this.menuStripAdmin.ResumeLayout(false);
            this.menuStripAdmin.PerformLayout();
            this.menuStripEmployee.ResumeLayout(false);
            this.menuStripEmployee.PerformLayout();
            this.menuStripDefault.ResumeLayout(false);
            this.menuStripDefault.PerformLayout();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAdminOptionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripEmployee;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testEmployeeMenuToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripDefault;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Label ErrorMsgLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem createNewCohortToolStripMenuItem;
    }
}

