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
            this.SuspendLayout();
            // 
            // lblGeneral
            // 
            this.lblGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneral.Location = new System.Drawing.Point(32, 32);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(851, 70);
            this.lblGeneral.TabIndex = 3;
            this.lblGeneral.Text = "As you know, Company XXX utilizes a 360-degree performance appraisal methodology." +
    " Peer review is a critical part of this process. You have been selected to provi" +
    "de a peer review for ";
            this.lblGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(394, 123);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(100, 72);
            this.lblInstructions.TabIndex = 4;
            this.lblInstructions.Text = "Instructions";
            // 
            // QuestionnaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 30);
            this.ClientSize = new System.Drawing.Size(914, 424);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblGeneral);
            this.Name = "QuestionnaireForm";
            this.Text = "Evaluation Questionnaire";
            this.Load += new System.EventHandler(this.QuestionnaireForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGeneral;
        private System.Windows.Forms.Label lblInstructions;
    }
}