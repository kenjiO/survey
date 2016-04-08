namespace CS6232_G1.View
{
    partial class AddStageForm
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
            this.stageNameTextBox = new System.Windows.Forms.TextBox();
            this.createStageButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorMsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Stage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stage Name";
            // 
            // stageNameTextBox
            // 
            this.stageNameTextBox.Location = new System.Drawing.Point(167, 69);
            this.stageNameTextBox.Name = "stageNameTextBox";
            this.stageNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.stageNameTextBox.TabIndex = 1;
            // 
            // createStageButton
            // 
            this.createStageButton.Location = new System.Drawing.Point(73, 118);
            this.createStageButton.Name = "createStageButton";
            this.createStageButton.Size = new System.Drawing.Size(96, 23);
            this.createStageButton.TabIndex = 2;
            this.createStageButton.Text = "Create Stage";
            this.createStageButton.UseVisualStyleBackColor = true;
            this.createStageButton.Click += new System.EventHandler(this.CreateStageButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(210, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // errorMsgLabel
            // 
            this.errorMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMsgLabel.Location = new System.Drawing.Point(18, 162);
            this.errorMsgLabel.Name = "errorMsgLabel";
            this.errorMsgLabel.Size = new System.Drawing.Size(342, 48);
            this.errorMsgLabel.TabIndex = 5;
            this.errorMsgLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AddStageForm
            // 
            this.AcceptButton = this.createStageButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(379, 219);
            this.Controls.Add(this.errorMsgLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createStageButton);
            this.Controls.Add(this.stageNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddStageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Stage";
            this.Load += new System.EventHandler(this.AddStageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stageNameTextBox;
        private System.Windows.Forms.Button createStageButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label errorMsgLabel;
    }
}