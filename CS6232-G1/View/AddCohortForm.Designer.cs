namespace CS6232_G1.View
{
    partial class AddCohortForm
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
            this.CohortNameTextBox = new System.Windows.Forms.TextBox();
            this.CreateCohortButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Cohort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cohort Name";
            // 
            // CohortNameTextBox
            // 
            this.CohortNameTextBox.Location = new System.Drawing.Point(167, 69);
            this.CohortNameTextBox.Name = "CohortNameTextBox";
            this.CohortNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.CohortNameTextBox.TabIndex = 1;
            // 
            // CreateCohortButton
            // 
            this.CreateCohortButton.Location = new System.Drawing.Point(73, 118);
            this.CreateCohortButton.Name = "CreateCohortButton";
            this.CreateCohortButton.Size = new System.Drawing.Size(96, 23);
            this.CreateCohortButton.TabIndex = 2;
            this.CreateCohortButton.Text = "Create Cohort";
            this.CreateCohortButton.UseVisualStyleBackColor = true;
            this.CreateCohortButton.Click += new System.EventHandler(this.CreateCohortButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(210, 118);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(93, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorMsgLabel.Location = new System.Drawing.Point(18, 162);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(342, 48);
            this.ErrorMsgLabel.TabIndex = 5;
            this.ErrorMsgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AddCohortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 219);
            this.Controls.Add(this.ErrorMsgLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateCohortButton);
            this.Controls.Add(this.CohortNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCohortForm";
            this.Text = "Add New Cohort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CohortNameTextBox;
        private System.Windows.Forms.Button CreateCohortButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ErrorMsgLabel;
    }
}