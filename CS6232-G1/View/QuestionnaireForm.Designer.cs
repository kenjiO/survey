namespace CS6232_G1.View
{
    partial class QuestionnaireForm
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
            this.lblGeneral = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEvaluator = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.submitPanel = new CS6232_G1.View.NonFlickerPanel();
            this.lblSubmitNotice = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.submitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGeneral
            // 
            this.lblGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneral.Location = new System.Drawing.Point(21, 62);
            this.lblGeneral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(568, 46);
            this.lblGeneral.TabIndex = 3;
            this.lblGeneral.Text = "Text";
            this.lblGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(254, 123);
            this.lblInstructions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(67, 71);
            this.lblInstructions.TabIndex = 4;
            this.lblInstructions.Text = "Instructions";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(162, 21);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(377, 27);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Performance Evaluation Questionnaire";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(26, 197);
            this.lblEmployeeName.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(150, 20);
            this.lblEmployeeName.TabIndex = 6;
            this.lblEmployeeName.Text = "Peer Review For: ";
            this.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(539, 197);
            this.lblDate.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(58, 20);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date: ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEvaluator
            // 
            this.lblEvaluator.AutoSize = true;
            this.lblEvaluator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvaluator.Location = new System.Drawing.Point(26, 229);
            this.lblEvaluator.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.lblEvaluator.Name = "lblEvaluator";
            this.lblEvaluator.Size = new System.Drawing.Size(95, 20);
            this.lblEvaluator.TabIndex = 9;
            this.lblEvaluator.Text = "Evaluator: ";
            this.lblEvaluator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(461, 229);
            this.lblRole.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(137, 20);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Evaluator Role: ";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // submitPanel
            // 
            this.submitPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.submitPanel.Controls.Add(this.lblSubmitNotice);
            this.submitPanel.Controls.Add(this.btnSubmit);
            this.submitPanel.Location = new System.Drawing.Point(38, 288);
            this.submitPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 19);
            this.submitPanel.Name = "submitPanel";
            this.submitPanel.Size = new System.Drawing.Size(559, 88);
            this.submitPanel.TabIndex = 7;
            // 
            // lblSubmitNotice
            // 
            this.lblSubmitNotice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubmitNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmitNotice.Location = new System.Drawing.Point(0, 0);
            this.lblSubmitNotice.Margin = new System.Windows.Forms.Padding(2);
            this.lblSubmitNotice.Name = "lblSubmitNotice";
            this.lblSubmitNotice.Size = new System.Drawing.Size(559, 51);
            this.lblSubmitNotice.TabIndex = 1;
            this.lblSubmitNotice.Text = "Your answers are automatically saved. You may close your form and come back to it" +
    " as many times as you wish. However, once you submit, this evaluation will be cl" +
    "osed and CANNOT be reopened.";
            this.lblSubmitNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(463, 55);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 31);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // QuestionnaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 30);
            this.ClientSize = new System.Drawing.Size(609, 561);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblEvaluator);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.submitPanel);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblGeneral);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QuestionnaireForm";
            this.Text = "Evaluation Questionnaire";
            this.Load += new System.EventHandler(this.QuestionnaireForm_Load);
            this.submitPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGeneral;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmployeeName;
        private NonFlickerPanel submitPanel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSubmitNotice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEvaluator;
        private System.Windows.Forms.Label lblRole;
    }
}