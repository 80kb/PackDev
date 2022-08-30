using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class MainForm : Form
    {
        private Pack _pack;
        private int _selectedCup;
        private int _selectedTrack;

        public MainForm()
        {
            InitializeComponent();

            _pack = new Pack();
            UpdateCupList();

            _selectedCup    = -1;
            _selectedTrack  = -1;
        }



        //---------------------------
        //----- Helper Methods ------
        //---------------------------

        // Update the button accessibility of the item manipulation buttons
        // Update the items in the list. To be called after a button is pressed
        private void UpdateCupList()
        {
            // Update button accessibility
            if (_pack.Cups.Count == 0)
            {
                cupRemoveBtn.Enabled    = false;
                cupUpBtn.Enabled        = false;
                cupDownBtn.Enabled      = false;

                ToggleCupInfoUI(false);
            }
            else if (_pack.Cups.Count == 1)
            {
                cupRemoveBtn.Enabled    = true;
                cupUpBtn.Enabled        = false;
                cupDownBtn.Enabled      = false;

                ToggleCupInfoUI(true);
            }
            else
            {
                cupRemoveBtn.Enabled    = true;
                cupUpBtn.Enabled        = true;
                cupDownBtn.Enabled      = true;

                ToggleCupInfoUI(true);
            }

            // Update list items
            cupList.Items.Clear();

            foreach (Cup cup in _pack.Cups)
            {
                cupList.Items.Add(cup.Name);
            }

            // Update CT-DEF
            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // Updates the items in the track list
        // Updates the accessibility of the item manipulation buttons
        private void UpdateTrackList()
        {
            Cup selectedCup = _pack.Cups[_selectedCup];

            // Update button accessibility
            if (selectedCup.Tracks.Count == 0)
            {
                trackRemoveBtn.Enabled  = false;
                trackUpBtn.Enabled      = false;
                trackDownBtn.Enabled    = false;

                ToggleTrackInfoUI(false);
            }
            else if (selectedCup.Tracks.Count == 1)
            {
                trackRemoveBtn.Enabled  = true;
                trackUpBtn.Enabled      = false;
                trackDownBtn.Enabled    = false;

                ToggleTrackInfoUI(true);
            }
            else
            {
                trackRemoveBtn.Enabled  = true;
                trackUpBtn.Enabled      = true;
                trackDownBtn.Enabled    = true;

                ToggleTrackInfoUI(true);
            }

            // Update list items
            trackList.Items.Clear();

            foreach (Track track in selectedCup.Tracks)
            {
                trackList.Items.Add(track.Name);
            }

            // Update CT-DEF
            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // Fill in the cup information
        private void PopulateCupInfo()
        {
            if (_selectedCup < 0)
                return;

            Cup selectedCup = _pack.Cups[_selectedCup];

            cupName.Text = selectedCup.Name;
            cupImage.BackgroundImage = selectedCup.Image;

            UpdateTrackList();
        }

        // Fill in the track information
        private void PopulateTrackInfo()
        {
            if (_selectedTrack < 0 || _selectedCup < 0)
                return;

            Track current = _pack.Cups[_selectedCup].Tracks[_selectedTrack];

            trackNameTextBox.Text = current.Name;
            trackFileTextBox.Text = current.File;

            propSlotCombo.SelectedIndex = current.PropertyIndex;
            musicSlotCombo.SelectedIndex = current.MusicIndex;
        }

        // Enable or disable all cup UI buttons
        private void ToggleCupInfoUI(bool enabled)
        {
            cupName.Enabled     = enabled;
            cupImage.Enabled    = enabled;

            trackAddBtn.Enabled     = enabled;
            trackRemoveBtn.Enabled  = enabled;
            trackUpBtn.Enabled      = enabled;
            trackDownBtn.Enabled    = enabled;

            trackList.Enabled = enabled;

            ToggleTrackInfoUI(enabled);
        }

        // Enable or disable all track UI buttons
        private void ToggleTrackInfoUI(bool enabled)
        {
            trackNameTextBox.Enabled = enabled;
            trackFileTextBox.Enabled = enabled;
            browseBtn.Enabled = enabled;

            propSlotCombo.Enabled   = enabled;
            musicSlotCombo.Enabled  = enabled;
        }



        //---------------------
        //----- UI Events -----
        //---------------------

        // Import a folder of tracks and add them into cups
        // Appends new cups to the end of the currently existing cups
        private void quickImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select folder containing SZS files";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Queue<Track> tracks = new Queue<Track>();

                foreach (string file in Directory.GetFiles(fbd.SelectedPath))
                {
                    // For each file in the directory, check if they are SZS files.
                    if (file.Substring(file.Length - 4) == ".szs")
                    {
                        // Create new track object
                        Track track = new Track();

                        // Fill in information
                        track.SetFile(file);
                        track.SetName(Path.GetFileNameWithoutExtension(file));

                        // Add to queue
                        tracks.Enqueue(track);
                    }
                }

                // Create cups from queue
                _pack.AddCupsFromTracks(tracks);
                UpdateCupList();
            }
        }

        #region cupList manipulation
        private void cupAddBtn_Click(object sender, EventArgs e)
        {
            _pack.AddCup( "Cup " + _pack.Cups.Count );
            UpdateCupList();

            // Update selected index
            cupList.SelectedIndex = _pack.Cups.Count - 1;
        }

        private void cupRemoveBtn_Click(object sender, EventArgs e)
        {
            _pack.RemoveCupAt(_selectedCup);
            UpdateCupList();

            // Update selected index
            if (_pack.Cups.Count > 0 && _selectedCup > 0)
            {
                cupList.SelectedIndex = _selectedCup - 1;
            }
            else if (_pack.Cups.Count > 0 && _selectedCup == 0)
            {
                cupList.SelectedIndex = 0;
            }
        }

        private void cupUpBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCup == 0)
                return;

            _pack.SwapCups(_selectedCup, _selectedCup - 1);
            UpdateCupList();

            // Update selected index
            cupList.SelectedIndex = _selectedCup - 1;
        }

        private void cupDownBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCup == _pack.Cups.Count - 1)
                return;

            _pack.SwapCups(_selectedCup, _selectedCup + 1);
            UpdateCupList();

            // Update selected index
            cupList.SelectedIndex = _selectedCup + 1;
        }

        private void cupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCup = cupList.SelectedIndex;
            PopulateCupInfo();
        }

        private void cupName_TextChanged(object sender, EventArgs e)
        {
            if (_selectedCup < 0 || _pack.Cups.Count <= 0)
                return;

            _pack.Cups[_selectedCup].SetName(cupName.Text);
            UpdateCupList();
        }

        private void cupImage_DoubleClick(object sender, EventArgs e)
        {
            if (_selectedCup < 0 || _pack.Cups.Count <= 0)
                return;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);

                _pack.Cups[_selectedCup].SetImage(img);
                PopulateCupInfo();
            }
        }
        #endregion

        #region trackList manipulation
        // Add new track to the list of tracks in the cup object, then populate the trackList UI element
        private void trackAddBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCup < 0)
                return;

            Cup current = _pack.Cups[_selectedCup];

            if (current.Tracks.Count >= 4)
                return;

            Track track = new Track();
            track.SetName("Track " + current.Tracks.Count);

            _pack.Cups[_selectedCup].AddTrack(track);
            UpdateTrackList();

            // Update selected index
            trackList.SelectedIndex = current.Tracks.Count - 1;
        }

        // Remove selected track from the cup object, and update the tracklist UI element
        private void trackRemoveBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCup < 0)
                return;

            Cup current = _pack.Cups[_selectedCup];

            current.RemoveTrack(_selectedTrack);
            UpdateTrackList();

            // Update selected index
            if (current.Tracks.Count > 0 && _selectedTrack > 0)
            {
                trackList.SelectedIndex = _selectedTrack - 1;
            }
            else if (current.Tracks.Count > 0 && _selectedTrack == 0)
            {
                trackList.SelectedIndex = 0;
            }
        }

        // Swaps the position of adjacent list items and then updates UI element
        private void trackUpBtn_Click(object sender, EventArgs e)
        {
            if (_selectedTrack == 0)
                return;

            if (_selectedCup < 0)
                return;

            Cup current = _pack.Cups[_selectedCup];

            current.SwapTracks(_selectedTrack, _selectedTrack - 1);
            UpdateTrackList();

            // Update selected index
            trackList.SelectedIndex = _selectedTrack - 1;
        }

        // Swaps the position of adjacent list items and then updates UI element
        private void trackDownBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCup < 0)
                return;

            Cup current = _pack.Cups[_selectedCup];

            if (_selectedTrack == current.Tracks.Count - 1)
                return;

            current.SwapTracks(_selectedTrack, _selectedTrack + 1);
            UpdateTrackList();

            // Update selected index
            trackList.SelectedIndex = _selectedTrack + 1;
        }

        // Change the selectedTrack variable to the selected index of the trackList UI element
        private void trackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedTrack = trackList.SelectedIndex;
            PopulateTrackInfo();
        }

        // Update name in track object then reload UI
        private void trackNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedTrack < 0 || _selectedCup < 0)
                return;

            Track current = _pack.Cups[_selectedCup].Tracks[_selectedTrack];

            current.SetName(trackNameTextBox.Text);
            UpdateTrackList();
        }

        // Update file in track object then reload UI
        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SZS Files|*.szs";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (_selectedTrack < 0 || _selectedCup < 0)
                    return;

                Track current = _pack.Cups[_selectedCup].Tracks[_selectedTrack];

                current.SetFile(ofd.FileName);
                PopulateTrackInfo();
            }
        }

        // Update propSlot in track object then reload UI
        private void propSlotCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedTrack < 0 || _selectedCup < 0)
                return;

            Track current = _pack.Cups[_selectedCup].Tracks[_selectedTrack];
            current.SetPropertySlot((sender as ComboBox).SelectedIndex);
            UpdateTrackList();
        }

        // Update musicSlot in track object then reload UI
        private void musicSlotCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedTrack < 0 || _selectedCup < 0)
                return;

            Track current = _pack.Cups[_selectedCup].Tracks[_selectedTrack];
            current.SetMusicSlot((sender as ComboBox).SelectedIndex);
            UpdateTrackList();
        }
        #endregion

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm ef = new ExportForm();

            if (ef.ShowDialog() == DialogResult.OK)
            {
                ProgressForm pf = new ProgressForm(_pack);
                pf.Show();
                pf.ExportRiiv(ef.ExportPath, ef.ImagePath);
            }
        }

        private void showRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                _pack.SetNinTrackMode(2);

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        private void noneRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                _pack.SetNinTrackMode(0);

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        private void hideRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                _pack.SetNinTrackMode(1);

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        private void swapRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                _pack.SetNinTrackMode(3);

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        private void wiimmCupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetWiimmCup((sender as CheckBox).Checked);
            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        private void packNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _pack.SetName((sender as TextBox).Text);
        }

        private void enable200CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.Set200cc((sender as CheckBox).Checked);
        }

        private void perfMonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetPerfMon((sender as CheckBox).Checked);
        }

        private void ctTTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetCTTimeTrial((sender as CheckBox).Checked);
        }
    }
}
