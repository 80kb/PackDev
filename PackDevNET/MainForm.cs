using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class MainForm : Form
    {
        private Pack _pack;
        private int _selectedCup;
        private int _selectedTrack;
        private bool _previouslySaved = false;
        private string _fileName;

        public MainForm()
        {
            InitializeComponent();

            _pack = new Pack();
            UpdateCupList();

            _selectedCup = -1;
            _selectedTrack = -1;
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
                cupRemoveBtn.Enabled = false;
                cupUpBtn.Enabled = false;
                cupDownBtn.Enabled = false;

                ToggleCupInfoUI(false);
            }
            else if (_pack.Cups.Count == 1)
            {
                cupRemoveBtn.Enabled = true;
                cupUpBtn.Enabled = false;
                cupDownBtn.Enabled = false;

                ToggleCupInfoUI(true);
            }
            else
            {
                cupRemoveBtn.Enabled = true;
                cupUpBtn.Enabled = true;
                cupDownBtn.Enabled = true;

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
                trackRemoveBtn.Enabled = false;
                trackUpBtn.Enabled = false;
                trackDownBtn.Enabled = false;

                ToggleTrackInfoUI(false);
            }
            else if (selectedCup.Tracks.Count == 1)
            {
                trackRemoveBtn.Enabled = true;
                trackUpBtn.Enabled = false;
                trackDownBtn.Enabled = false;

                ToggleTrackInfoUI(true);
            }
            else
            {
                trackRemoveBtn.Enabled = true;
                trackUpBtn.Enabled = true;
                trackDownBtn.Enabled = true;

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

            propSlotCombo.SelectedIndex = current.PropertySlot;
            musicSlotCombo.SelectedIndex = current.MusicSlot;
        }

        // Enable or disable all cup UI buttons
        private void ToggleCupInfoUI(bool enabled)
        {
            cupName.Enabled = enabled;
            cupImage.Enabled = enabled;

            trackAddBtn.Enabled = enabled;
            trackRemoveBtn.Enabled = enabled;
            trackUpBtn.Enabled = enabled;
            trackDownBtn.Enabled = enabled;

            trackList.Enabled = enabled;

            ToggleTrackInfoUI(enabled);
        }

        // Enable or disable all track UI buttons
        private void ToggleTrackInfoUI(bool enabled)
        {
            trackNameTextBox.Enabled = enabled;
            trackFileTextBox.Enabled = enabled;
            browseBtn.Enabled = enabled;

            propSlotCombo.Enabled = enabled;
            musicSlotCombo.Enabled = enabled;
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
            _pack.AddCup("Cup " + _pack.Cups.Count);
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

        // Opens the export form and exports riivolution pack
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm ef = new ExportForm();

            if (ef.ShowDialog() == DialogResult.OK)
            {
                _pack.ExportRiiv(ef.ExportPath, ef.ImagePath);
            }
        }

        // UI Event for SHOW nintendo track mode
        //
        // Enables wiimm cup accessibility when checked
        private void showRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                wiimmCupCheckBox.Enabled = true;
                _pack.SetNinTrackMode(2);
            }

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // UI Event for NONE nintendo track mode
        //
        // Disables wiimm cup when checked
        private void noneRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                wiimmCupCheckBox.Enabled = false;
                wiimmCupCheckBox.Checked = false;
                _pack.SetNinTrackMode(0);
            }

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // UI Event for HIDE nintendo track mode (currently inaccessible)
        private void hideRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                _pack.SetNinTrackMode(1);

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // UI Event for SWAP nintendo track mode
        //
        // Enables wiimm cup accessibility when checked
        private void swapRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                wiimmCupCheckBox.Enabled = true;
                _pack.SetNinTrackMode(3);
            }

            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // UI Event for toggling wiimm cup
        private void wiimmCupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetWiimmCup((sender as CheckBox).Checked);
            ctDefTextBox.Text = _pack.CTDEF.ToString();
        }

        // UI Event for changing pack name
        private void packNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _pack.SetName((sender as TextBox).Text);
        }

        // UI Event for enabling 200cc (currently inaccessible)
        private void enable200CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.Set200cc((sender as CheckBox).Checked);
        }

        // UI Event for toggling performance monitor
        private void perfMonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetPerfMon((sender as CheckBox).Checked);
        }

        // UI Event for toggling Custom Track Time Trials
        private void ctTTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _pack.SetCTTimeTrial((sender as CheckBox).Checked);
        }

        // UI Event for sorting tracks alphabetically
        private void alphabeticallyAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pack.SortTracks();
            UpdateCupList();
            //UpdateTrackList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            somComboBox.Enabled = (sender as CheckBox).Checked;

            if (!(sender as CheckBox).Checked)
            {
                if (_pack.SomLevel != 0)
                    _pack.SetSom(0);
            }
            else
            {
                somComboBox.SelectedIndex = 0;
            }
        }

        private void somComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pack.SetSom(somComboBox.SelectedIndex + 1);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pack p = new Pack();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "PackDev Projects (*.pd)|*.pd";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    p = PackSaverLoader.Load(File.ReadAllText(openFileDialog.FileName));
                }
            }

            _pack = p;
            packNameTextBox.Text = p.Name;

            checkBox1.Checked = true;

            somComboBox.SelectedIndex = p.SomLevel;
            wiimmCupCheckBox.Checked = p.WiimmCup;

            switch (p.NinTrackMode)
            {
                case 0:
                    noneRadBtn.Checked = true;
                    hideRadBtn.Checked = false;
                    showRadBtn.Checked = false;
                    swapRadBtn.Checked = false;
                    break;
                case 1:
                    noneRadBtn.Checked = false;
                    hideRadBtn.Checked = true;
                    showRadBtn.Checked = false;
                    swapRadBtn.Checked = false;
                    break;
                case 2:
                    noneRadBtn.Checked = false;
                    hideRadBtn.Checked = false;
                    showRadBtn.Checked = true;
                    swapRadBtn.Checked = false;
                    break;
                case 3:
                    noneRadBtn.Checked = false;
                    hideRadBtn.Checked = false;
                    showRadBtn.Checked = false;
                    swapRadBtn.Checked = true;
                    break;
            }

            if(p.PerfMonEnabled)
                perfMonCheckBox.Checked = true;

            _selectedCup = 0;
            _selectedTrack = 0;
            if (p.Cups.Count > 0)
            {
                UpdateCupList();
                UpdateTrackList();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_previouslySaved)
            {
                _fileName = _pack.Name + ".pd";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.FileName = _fileName;
                saveFileDialog1.Filter = "PackDev project files (*.pd)|*.pd|All files (*.*)|*.*";
                saveFileDialog1.RestoreDirectory = true;

                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _fileName = saveFileDialog1.FileName;
                    _previouslySaved = true;
                }
                else if (dr == DialogResult.Abort)
                {
                    return;
                }
            }
            PackSaverLoader.Save(_pack, _fileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = _pack.Name + ".pd";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = filename;
            saveFileDialog1.Filter = "PackDev project files (*.pd)|*.pd|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }
            PackSaverLoader.Save(_pack, filename);
        }
    }
}
