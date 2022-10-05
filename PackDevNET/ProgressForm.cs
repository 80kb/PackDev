using System.ComponentModel;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class ProgressForm : Form
    {
        private BackgroundWorker _bw;

        public ProgressForm(BackgroundWorker bw, string windowTitle)
        {
            InitializeComponent();

            this._bw = bw;

            MaximizeBox = false;
            Text = windowTitle;
        }

        public void UpdateProgress(int percentCompelete, string message)
        {
            progressStepLabel.Text = $"Exporting: {percentCompelete}%    {message}";
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
        }
    }
}
