﻿namespace CS6232_G1.View
{
    partial class SelectCohortForm
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
            this.SelectButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CohortComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.Enabled = false;
            this.SelectButton.Location = new System.Drawing.Point(41, 160);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(140, 160);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 1;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Cohort";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CohortComboBox
            // 
            this.CohortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CohortComboBox.FormattingEnabled = true;
            this.CohortComboBox.Location = new System.Drawing.Point(41, 87);
            this.CohortComboBox.Name = "CohortComboBox";
            this.CohortComboBox.Size = new System.Drawing.Size(174, 21);
            this.CohortComboBox.TabIndex = 3;
            this.CohortComboBox.SelectedIndexChanged += new System.EventHandler(this.CohortComboBox_SelectedIndexChanged);
            // 
            // SelectCohortForm
            // 
            this.AcceptButton = this.SelectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(268, 221);
            this.Controls.Add(this.CohortComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.SelectButton);
            this.Name = "SelectCohortForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Cohort";
            this.Load += new System.EventHandler(this.SelectCohortForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CohortComboBox;
    }
}