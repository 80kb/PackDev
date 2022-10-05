namespace PackDevNET
{
    partial class ProgressForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressStepLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 34);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(351, 23);
            this.progressBar.TabIndex = 0;
            // 
            // progressStepLabel
            // 
            this.progressStepLabel.AutoSize = true;
            this.progressStepLabel.Location = new System.Drawing.Point(12, 9);
            this.progressStepLabel.Name = "progressStepLabel";
            this.progressStepLabel.Size = new System.Drawing.Size(71, 13);
            this.progressStepLabel.TabIndex = 1;
            this.progressStepLabel.Text = "Exporting: 0%";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 73);
            this.Controls.Add(this.progressStepLabel);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressForm";
            this.Text = "Exporting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressStepLabel;
    }
}