using System;
using System.IO;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class ExportForm : Form
    {
        private string _imagePath;
        private string _exportPath;

        public string ImagePath { get { return _imagePath; } }
        public string ExportPath { get { return _exportPath; } }

        public ExportForm()
        {
            InitializeComponent();

            _imagePath = "C:\\";
            _exportPath = "C:\\";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mkwImageBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ISO files|*.iso";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imagePath = ofd.FileName;
                mkwImageTextBox.Text = ofd.FileName;
            }
        }

        private void riivBrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select output directory";

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                _exportPath = fbd.SelectedPath;
                riivTextBox.Text = fbd.SelectedPath;
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            // Check if an image file was input
            if (!mkwImageTextBox.Text.EndsWith(".iso"))
            {
                MessageBox.Show("Please input a valid image file");
                this.DialogResult = DialogResult.None;
            }

            // Check if image file exists
            else if (!File.Exists(mkwImageTextBox.Text))
            {
                MessageBox.Show("Please input a valid image file");
                this.DialogResult = DialogResult.None;
            }

            // Check if output directory exists
            else if (!Directory.Exists(riivTextBox.Text))
            {
                MessageBox.Show("Output folder does not exist");
                this.DialogResult = DialogResult.None;
            }

            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
