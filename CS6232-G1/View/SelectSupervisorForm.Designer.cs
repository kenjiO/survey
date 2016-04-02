namespace CS6232_G1.View
{
    partial class SelectSupervisorForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectSupervisor = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboSupervisors = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Supervisor";
            // 
            // btnSelectSupervisor
            // 
            this.btnSelectSupervisor.Location = new System.Drawing.Point(177, 213);
            this.btnSelectSupervisor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectSupervisor.Name = "btnSelectSupervisor";
            this.btnSelectSupervisor.Size = new System.Drawing.Size(144, 35);
            this.btnSelectSupervisor.TabIndex = 5;
            this.btnSelectSupervisor.Text = "Select";
            this.btnSelectSupervisor.UseVisualStyleBackColor = true;
            this.btnSelectSupervisor.Click += new System.EventHandler(this.btnSelectSupervisor_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 213);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboSupervisors
            // 
            this.cboSupervisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupervisors.FormattingEnabled = true;
            this.cboSupervisors.Location = new System.Drawing.Point(240, 100);
            this.cboSupervisors.Name = "cboSupervisors";
            this.cboSupervisors.Size = new System.Drawing.Size(360, 28);
            this.cboSupervisors.TabIndex = 7;
            this.cboSupervisors.SelectedIndexChanged += new System.EventHandler(this.cboSupervisors_SelectedIndexChanged);
            // 
            // SelectSupervisorForm
            // 
            this.AcceptButton = this.btnSelectSupervisor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(656, 322);
            this.Controls.Add(this.cboSupervisors);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectSupervisor);
            this.Controls.Add(this.label2);
            this.Name = "SelectSupervisorForm";
            this.Text = "SelectSupervisorForm";
            this.Load += new System.EventHandler(this.SelectSupervisorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectSupervisor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboSupervisors;
    }
}