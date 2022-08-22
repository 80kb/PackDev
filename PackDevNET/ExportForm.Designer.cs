namespace PackDevNET
{
    partial class ExportForm
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
            this.riivTextBox = new System.Windows.Forms.TextBox();
            this.riivLabel = new System.Windows.Forms.Label();
            this.riivBrowseBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.mkwImageLabel = new System.Windows.Forms.Label();
            this.mkwImageTextBox = new System.Windows.Forms.TextBox();
            this.mkwImageBrowseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // riivTextBox
            // 
            this.riivTextBox.Location = new System.Drawing.Point(12, 25);
            this.riivTextBox.Name = "riivTextBox";
            this.riivTextBox.Size = new System.Drawing.Size(177, 20);
            this.riivTextBox.TabIndex = 1;
            this.riivTextBox.Text = "C:\\";
            // 
            // riivLabel
            // 
            this.riivLabel.AutoSize = true;
            this.riivLabel.Location = new System.Drawing.Point(9, 9);
            this.riivLabel.Name = "riivLabel";
            this.riivLabel.Size = new System.Drawing.Size(85, 13);
            this.riivLabel.TabIndex = 2;
            this.riivLabel.Text = "Output directory:";
            // 
            // riivBrowseBtn
            // 
            this.riivBrowseBtn.Location = new System.Drawing.Point(195, 23);
            this.riivBrowseBtn.Name = "riivBrowseBtn";
            this.riivBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.riivBrowseBtn.TabIndex = 3;
            this.riivBrowseBtn.Text = "Browse...";
            this.riivBrowseBtn.UseVisualStyleBackColor = true;
            this.riivBrowseBtn.Click += new System.EventHandler(this.riivBrowseBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(12, 110);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(122, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(148, 110);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(122, 23);
            this.exportBtn.TabIndex = 5;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // mkwImageLabel
            // 
            this.mkwImageLabel.AutoSize = true;
            this.mkwImageLabel.Location = new System.Drawing.Point(9, 57);
            this.mkwImageLabel.Name = "mkwImageLabel";
            this.mkwImageLabel.Size = new System.Drawing.Size(84, 13);
            this.mkwImageLabel.TabIndex = 2;
            this.mkwImageLabel.Text = "MKW image file:";
            // 
            // mkwImageTextBox
            // 
            this.mkwImageTextBox.Location = new System.Drawing.Point(12, 73);
            this.mkwImageTextBox.Name = "mkwImageTextBox";
            this.mkwImageTextBox.Size = new System.Drawing.Size(177, 20);
            this.mkwImageTextBox.TabIndex = 1;
            this.mkwImageTextBox.Text = "C:\\";
            // 
            // mkwImageBrowseButton
            // 
            this.mkwImageBrowseButton.Location = new System.Drawing.Point(195, 71);
            this.mkwImageBrowseButton.Name = "mkwImageBrowseButton";
            this.mkwImageBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.mkwImageBrowseButton.TabIndex = 3;
            this.mkwImageBrowseButton.Text = "Browse...";
            this.mkwImageBrowseButton.UseVisualStyleBackColor = true;
            this.mkwImageBrowseButton.Click += new System.EventHandler(this.mkwImageBrowseButton_Click);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 143);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.mkwImageBrowseButton);
            this.Controls.Add(this.riivBrowseBtn);
            this.Controls.Add(this.mkwImageLabel);
            this.Controls.Add(this.riivLabel);
            this.Controls.Add(this.mkwImageTextBox);
            this.Controls.Add(this.riivTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportForm";
            this.Text = "Export Riivolution Pack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox riivTextBox;
        private System.Windows.Forms.Label riivLabel;
        private System.Windows.Forms.Button riivBrowseBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label mkwImageLabel;
        private System.Windows.Forms.TextBox mkwImageTextBox;
        private System.Windows.Forms.Button mkwImageBrowseButton;
    }
}