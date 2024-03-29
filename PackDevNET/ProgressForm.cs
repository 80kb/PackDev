﻿using System.ComponentModel;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class ProgressForm : Form
    {
        private BackgroundWorker _bw;

        public ProgressForm(BackgroundWorker bw, string windowTitle)
        {
            InitializeComponent();

            progressBar.Value = 0;
            MaximizeBox = false;
            Text = windowTitle;

            this._bw = bw;
        }

        public void UpdateProgress(int percentCompelete)
        {
            progressStepLabel.Text = $"{percentCompelete}% Complete";
            progressBar.Value = percentCompelete;
        }

        public void UpdateProgress(int percentCompelete, string message)
        {
            progressStepLabel.Text = $"{percentCompelete}% {message}";
            progressBar.Value = percentCompelete;
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._bw.IsBusy)
            {
                if (MessageBox.Show("Closing this window will cancel exporting. Are you sure you want to cancel?",
                    "Cancel export?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this._bw.CancelAsync();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            this._bw.Dispose();
        }
    }
}
