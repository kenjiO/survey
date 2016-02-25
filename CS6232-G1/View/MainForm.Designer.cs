namespace CS6232_G1
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
            this.menuStripEmployee = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testEmployeeMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDefault = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAdmin.SuspendLayout();
            this.menuStripEmployee.SuspendLayout();
            this.menuStripDefault.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testAdminOptionsToolStripMenuItem});
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 48);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(592, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testAdminOptionsToolStripMenuItem
            // 
            this.testAdminOptionsToolStripMenuItem.Name = "testAdminOptionsToolStripMenuItem";
            this.testAdminOptionsToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.testAdminOptionsToolStripMenuItem.Text = "Test Admin Menu";
            // 
            // menuStripEmployee
            // 
            this.menuStripEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.testEmployeeMenuToolStripMenuItem});
            this.menuStripEmployee.Location = new System.Drawing.Point(0, 24);
            this.menuStripEmployee.Name = "menuStripEmployee";
            this.menuStripEmployee.Size = new System.Drawing.Size(592, 24);
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
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testEmployeeMenuToolStripMenuItem
            // 
            this.testEmployeeMenuToolStripMenuItem.Name = "testEmployeeMenuToolStripMenuItem";
            this.testEmployeeMenuToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.testEmployeeMenuToolStripMenuItem.Text = "Test Employee Menu";
            // 
            // menuStripDefault
            // 
            this.menuStripDefault.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2});
            this.menuStripDefault.Location = new System.Drawing.Point(0, 0);
            this.menuStripDefault.Name = "menuStripDefault";
            this.menuStripDefault.Size = new System.Drawing.Size(592, 24);
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
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 417);
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
    }
}

