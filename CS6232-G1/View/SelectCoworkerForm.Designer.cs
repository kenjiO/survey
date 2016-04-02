namespace CS6232_G1.View
{
    partial class SelectCoworkerForm
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
            this.cboCoworkers = new System.Windows.Forms.ComboBox();
            this.btnSelectCoworker = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Coworker";
            // 
            // cboCoworkers
            // 
            this.cboCoworkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoworkers.FormattingEnabled = true;
            this.cboCoworkers.Location = new System.Drawing.Point(227, 92);
            this.cboCoworkers.Name = "cboCoworkers";
            this.cboCoworkers.Size = new System.Drawing.Size(360, 28);
            this.cboCoworkers.TabIndex = 8;
            this.cboCoworkers.SelectedIndexChanged += new System.EventHandler(this.cboCoworkers_SelectedIndexChanged);
            // 
            // btnSelectCoworker
            // 
            this.btnSelectCoworker.Location = new System.Drawing.Point(174, 203);
            this.btnSelectCoworker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectCoworker.Name = "btnSelectCoworker";
            this.btnSelectCoworker.Size = new System.Drawing.Size(144, 35);
            this.btnSelectCoworker.TabIndex = 9;
            this.btnSelectCoworker.Text = "Select";
            this.btnSelectCoworker.UseVisualStyleBackColor = true;
            this.btnSelectCoworker.Click += new System.EventHandler(this.btnSelectCoworker_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 203);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectCoworkerForm
            // 
            this.AcceptButton = this.btnSelectCoworker;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(698, 356);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectCoworker);
            this.Controls.Add(this.cboCoworkers);
            this.Controls.Add(this.label2);
            this.Name = "SelectCoworkerForm";
            this.Text = "Select Coworker";
            this.Load += new System.EventHandler(this.SelectCoworkerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCoworkers;
        private System.Windows.Forms.Button btnSelectCoworker;
        private System.Windows.Forms.Button btnCancel;
    }
}