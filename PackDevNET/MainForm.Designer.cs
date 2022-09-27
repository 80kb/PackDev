namespace PackDevNET
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRiivolutionPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphabeticallyAZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.projectConfig = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctTTCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.perfMonCheckBox = new System.Windows.Forms.CheckBox();
            this.enable200CheckBox = new System.Windows.Forms.CheckBox();
            this.cheatModeCheckBox = new System.Windows.Forms.CheckBox();
            this.ctDefFlagsGroup = new System.Windows.Forms.GroupBox();
            this.leFlagsCheckBox = new System.Windows.Forms.CheckBox();
            this.wiimmCupCheckBox = new System.Windows.Forms.CheckBox();
            this.trackModeGroup = new System.Windows.Forms.GroupBox();
            this.swapRadBtn = new System.Windows.Forms.RadioButton();
            this.showRadBtn = new System.Windows.Forms.RadioButton();
            this.hideRadBtn = new System.Windows.Forms.RadioButton();
            this.noneRadBtn = new System.Windows.Forms.RadioButton();
            this.packNameTextBox = new System.Windows.Forms.TextBox();
            this.packNameLabel = new System.Windows.Forms.Label();
            this.tracks = new System.Windows.Forms.TabPage();
            this.trackGroupBox = new System.Windows.Forms.GroupBox();
            this.musicSlotCombo = new System.Windows.Forms.ComboBox();
            this.propSlotCombo = new System.Windows.Forms.ComboBox();
            this.musicSlotLbl = new System.Windows.Forms.Label();
            this.propertySlotLbl = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.trackFileTextBox = new System.Windows.Forms.TextBox();
            this.trackFileLbl = new System.Windows.Forms.Label();
            this.trackNameTextBox = new System.Windows.Forms.TextBox();
            this.trackNameLbl = new System.Windows.Forms.Label();
            this.trackDownBtn = new System.Windows.Forms.Button();
            this.trackUpBtn = new System.Windows.Forms.Button();
            this.trackRemoveBtn = new System.Windows.Forms.Button();
            this.trackAddBtn = new System.Windows.Forms.Button();
            this.trackList = new System.Windows.Forms.ListBox();
            this.cupName = new System.Windows.Forms.TextBox();
            this.cupImage = new System.Windows.Forms.PictureBox();
            this.cupDownBtn = new System.Windows.Forms.Button();
            this.cupUpBtn = new System.Windows.Forms.Button();
            this.cupRemoveBtn = new System.Windows.Forms.Button();
            this.cupAddBtn = new System.Windows.Forms.Button();
            this.cupList = new System.Windows.Forms.ListBox();
            this.ctDef = new System.Windows.Forms.TabPage();
            this.ctDefTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.projectConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ctDefFlagsGroup.SuspendLayout();
            this.trackModeGroup.SuspendLayout();
            this.tracks.SuspendLayout();
            this.trackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cupImage)).BeginInit();
            this.ctDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.importTracksToolStripMenuItem,
            this.importRiivolutionPackToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // importTracksToolStripMenuItem
            // 
            this.importTracksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickImportToolStripMenuItem,
            this.customImportToolStripMenuItem});
            this.importTracksToolStripMenuItem.Name = "importTracksToolStripMenuItem";
            this.importTracksToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.importTracksToolStripMenuItem.Text = "Import tracks";
            // 
            // quickImportToolStripMenuItem
            // 
            this.quickImportToolStripMenuItem.Name = "quickImportToolStripMenuItem";
            this.quickImportToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.quickImportToolStripMenuItem.Text = "Quick Import";
            this.quickImportToolStripMenuItem.Click += new System.EventHandler(this.quickImportToolStripMenuItem_Click);
            // 
            // customImportToolStripMenuItem
            // 
            this.customImportToolStripMenuItem.Enabled = false;
            this.customImportToolStripMenuItem.Name = "customImportToolStripMenuItem";
            this.customImportToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.customImportToolStripMenuItem.Text = "Custom Import";
            // 
            // importRiivolutionPackToolStripMenuItem
            // 
            this.importRiivolutionPackToolStripMenuItem.Enabled = false;
            this.importRiivolutionPackToolStripMenuItem.Name = "importRiivolutionPackToolStripMenuItem";
            this.importRiivolutionPackToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.importRiivolutionPackToolStripMenuItem.Text = "Import riivolution XML";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exportToolStripMenuItem.Text = "Export riivolution pack...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphabeticallyAZToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // alphabeticallyAZToolStripMenuItem
            // 
            this.alphabeticallyAZToolStripMenuItem.Name = "alphabeticallyAZToolStripMenuItem";
            this.alphabeticallyAZToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alphabeticallyAZToolStripMenuItem.Text = "Alphabetically [A-Z]";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.projectConfig);
            this.tabControl.Controls.Add(this.tracks);
            this.tabControl.Controls.Add(this.ctDef);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(843, 457);
            this.tabControl.TabIndex = 1;
            // 
            // projectConfig
            // 
            this.projectConfig.Controls.Add(this.groupBox1);
            this.projectConfig.Controls.Add(this.ctDefFlagsGroup);
            this.projectConfig.Controls.Add(this.trackModeGroup);
            this.projectConfig.Controls.Add(this.packNameTextBox);
            this.projectConfig.Controls.Add(this.packNameLabel);
            this.projectConfig.Location = new System.Drawing.Point(4, 22);
            this.projectConfig.Name = "projectConfig";
            this.projectConfig.Padding = new System.Windows.Forms.Padding(3);
            this.projectConfig.Size = new System.Drawing.Size(835, 431);
            this.projectConfig.TabIndex = 1;
            this.projectConfig.Text = "Project Config";
            this.projectConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctTTCheckBox);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.perfMonCheckBox);
            this.groupBox1.Controls.Add(this.enable200CheckBox);
            this.groupBox1.Controls.Add(this.cheatModeCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LPAR settings";
            // 
            // ctTTCheckBox
            // 
            this.ctTTCheckBox.AutoSize = true;
            this.ctTTCheckBox.Checked = true;
            this.ctTTCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctTTCheckBox.Location = new System.Drawing.Point(6, 88);
            this.ctTTCheckBox.Name = "ctTTCheckBox";
            this.ctTTCheckBox.Size = new System.Drawing.Size(94, 17);
            this.ctTTCheckBox.TabIndex = 0;
            this.ctTTCheckBox.Text = "CT Time Trials";
            this.ctTTCheckBox.UseVisualStyleBackColor = true;
            this.ctTTCheckBox.CheckedChanged += new System.EventHandler(this.ctTTCheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Speedometer";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // perfMonCheckBox
            // 
            this.perfMonCheckBox.AutoSize = true;
            this.perfMonCheckBox.Location = new System.Drawing.Point(6, 65);
            this.perfMonCheckBox.Name = "perfMonCheckBox";
            this.perfMonCheckBox.Size = new System.Drawing.Size(124, 17);
            this.perfMonCheckBox.TabIndex = 0;
            this.perfMonCheckBox.Text = "Performance Monitor";
            this.perfMonCheckBox.UseVisualStyleBackColor = true;
            this.perfMonCheckBox.CheckedChanged += new System.EventHandler(this.perfMonCheckBox_CheckedChanged);
            // 
            // enable200CheckBox
            // 
            this.enable200CheckBox.AutoSize = true;
            this.enable200CheckBox.Enabled = false;
            this.enable200CheckBox.Location = new System.Drawing.Point(6, 42);
            this.enable200CheckBox.Name = "enable200CheckBox";
            this.enable200CheckBox.Size = new System.Drawing.Size(92, 17);
            this.enable200CheckBox.TabIndex = 0;
            this.enable200CheckBox.Text = "Enable 200cc";
            this.enable200CheckBox.UseVisualStyleBackColor = true;
            this.enable200CheckBox.CheckedChanged += new System.EventHandler(this.enable200CheckBox_CheckedChanged);
            // 
            // cheatModeCheckBox
            // 
            this.cheatModeCheckBox.AutoSize = true;
            this.cheatModeCheckBox.Enabled = false;
            this.cheatModeCheckBox.Location = new System.Drawing.Point(6, 19);
            this.cheatModeCheckBox.Name = "cheatModeCheckBox";
            this.cheatModeCheckBox.Size = new System.Drawing.Size(83, 17);
            this.cheatModeCheckBox.TabIndex = 0;
            this.cheatModeCheckBox.Text = "Cheat mode";
            this.cheatModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctDefFlagsGroup
            // 
            this.ctDefFlagsGroup.Controls.Add(this.leFlagsCheckBox);
            this.ctDefFlagsGroup.Controls.Add(this.wiimmCupCheckBox);
            this.ctDefFlagsGroup.Location = new System.Drawing.Point(149, 56);
            this.ctDefFlagsGroup.Name = "ctDefFlagsGroup";
            this.ctDefFlagsGroup.Size = new System.Drawing.Size(120, 66);
            this.ctDefFlagsGroup.TabIndex = 3;
            this.ctDefFlagsGroup.TabStop = false;
            this.ctDefFlagsGroup.Text = "CT-DEF flags";
            // 
            // leFlagsCheckBox
            // 
            this.leFlagsCheckBox.AutoSize = true;
            this.leFlagsCheckBox.Checked = true;
            this.leFlagsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leFlagsCheckBox.Enabled = false;
            this.leFlagsCheckBox.Location = new System.Drawing.Point(6, 42);
            this.leFlagsCheckBox.Name = "leFlagsCheckBox";
            this.leFlagsCheckBox.Size = new System.Drawing.Size(67, 17);
            this.leFlagsCheckBox.TabIndex = 2;
            this.leFlagsCheckBox.Text = "LE-Flags";
            this.leFlagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // wiimmCupCheckBox
            // 
            this.wiimmCupCheckBox.AutoSize = true;
            this.wiimmCupCheckBox.Location = new System.Drawing.Point(6, 19);
            this.wiimmCupCheckBox.Name = "wiimmCupCheckBox";
            this.wiimmCupCheckBox.Size = new System.Drawing.Size(79, 17);
            this.wiimmCupCheckBox.TabIndex = 2;
            this.wiimmCupCheckBox.Text = "Wiimm Cup";
            this.wiimmCupCheckBox.UseVisualStyleBackColor = true;
            this.wiimmCupCheckBox.CheckedChanged += new System.EventHandler(this.wiimmCupCheckBox_CheckedChanged);
            // 
            // trackModeGroup
            // 
            this.trackModeGroup.Controls.Add(this.swapRadBtn);
            this.trackModeGroup.Controls.Add(this.showRadBtn);
            this.trackModeGroup.Controls.Add(this.hideRadBtn);
            this.trackModeGroup.Controls.Add(this.noneRadBtn);
            this.trackModeGroup.Location = new System.Drawing.Point(10, 56);
            this.trackModeGroup.Name = "trackModeGroup";
            this.trackModeGroup.Size = new System.Drawing.Size(122, 66);
            this.trackModeGroup.TabIndex = 3;
            this.trackModeGroup.TabStop = false;
            this.trackModeGroup.Text = "Nintendo track mode";
            // 
            // swapRadBtn
            // 
            this.swapRadBtn.AutoSize = true;
            this.swapRadBtn.Location = new System.Drawing.Point(63, 42);
            this.swapRadBtn.Name = "swapRadBtn";
            this.swapRadBtn.Size = new System.Drawing.Size(52, 17);
            this.swapRadBtn.TabIndex = 0;
            this.swapRadBtn.Text = "Swap";
            this.swapRadBtn.UseVisualStyleBackColor = true;
            this.swapRadBtn.CheckedChanged += new System.EventHandler(this.swapRadBtn_CheckedChanged);
            // 
            // showRadBtn
            // 
            this.showRadBtn.AutoSize = true;
            this.showRadBtn.Location = new System.Drawing.Point(63, 19);
            this.showRadBtn.Name = "showRadBtn";
            this.showRadBtn.Size = new System.Drawing.Size(52, 17);
            this.showRadBtn.TabIndex = 0;
            this.showRadBtn.Text = "Show";
            this.showRadBtn.UseVisualStyleBackColor = true;
            this.showRadBtn.CheckedChanged += new System.EventHandler(this.showRadBtn_CheckedChanged);
            // 
            // hideRadBtn
            // 
            this.hideRadBtn.AutoSize = true;
            this.hideRadBtn.Enabled = false;
            this.hideRadBtn.Location = new System.Drawing.Point(6, 42);
            this.hideRadBtn.Name = "hideRadBtn";
            this.hideRadBtn.Size = new System.Drawing.Size(47, 17);
            this.hideRadBtn.TabIndex = 0;
            this.hideRadBtn.Text = "Hide";
            this.hideRadBtn.UseVisualStyleBackColor = true;
            this.hideRadBtn.CheckedChanged += new System.EventHandler(this.hideRadBtn_CheckedChanged);
            // 
            // noneRadBtn
            // 
            this.noneRadBtn.AutoSize = true;
            this.noneRadBtn.Checked = true;
            this.noneRadBtn.Location = new System.Drawing.Point(6, 19);
            this.noneRadBtn.Name = "noneRadBtn";
            this.noneRadBtn.Size = new System.Drawing.Size(51, 17);
            this.noneRadBtn.TabIndex = 0;
            this.noneRadBtn.TabStop = true;
            this.noneRadBtn.Text = "None";
            this.noneRadBtn.UseVisualStyleBackColor = true;
            this.noneRadBtn.CheckedChanged += new System.EventHandler(this.noneRadBtn_CheckedChanged);
            // 
            // packNameTextBox
            // 
            this.packNameTextBox.Location = new System.Drawing.Point(10, 23);
            this.packNameTextBox.Name = "packNameTextBox";
            this.packNameTextBox.Size = new System.Drawing.Size(259, 20);
            this.packNameTextBox.TabIndex = 1;
            this.packNameTextBox.Text = "Untitled Pack";
            this.packNameTextBox.TextChanged += new System.EventHandler(this.packNameTextBox_TextChanged);
            // 
            // packNameLabel
            // 
            this.packNameLabel.AutoSize = true;
            this.packNameLabel.Location = new System.Drawing.Point(7, 7);
            this.packNameLabel.Name = "packNameLabel";
            this.packNameLabel.Size = new System.Drawing.Size(64, 13);
            this.packNameLabel.TabIndex = 0;
            this.packNameLabel.Text = "Pack name:";
            // 
            // tracks
            // 
            this.tracks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tracks.Controls.Add(this.trackGroupBox);
            this.tracks.Controls.Add(this.cupName);
            this.tracks.Controls.Add(this.cupImage);
            this.tracks.Controls.Add(this.cupDownBtn);
            this.tracks.Controls.Add(this.cupUpBtn);
            this.tracks.Controls.Add(this.cupRemoveBtn);
            this.tracks.Controls.Add(this.cupAddBtn);
            this.tracks.Controls.Add(this.cupList);
            this.tracks.Location = new System.Drawing.Point(4, 22);
            this.tracks.Name = "tracks";
            this.tracks.Padding = new System.Windows.Forms.Padding(3);
            this.tracks.Size = new System.Drawing.Size(835, 431);
            this.tracks.TabIndex = 0;
            this.tracks.Text = "Tracks";
            this.tracks.UseVisualStyleBackColor = true;
            // 
            // trackGroupBox
            // 
            this.trackGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackGroupBox.Controls.Add(this.musicSlotCombo);
            this.trackGroupBox.Controls.Add(this.propSlotCombo);
            this.trackGroupBox.Controls.Add(this.musicSlotLbl);
            this.trackGroupBox.Controls.Add(this.propertySlotLbl);
            this.trackGroupBox.Controls.Add(this.browseBtn);
            this.trackGroupBox.Controls.Add(this.trackFileTextBox);
            this.trackGroupBox.Controls.Add(this.trackFileLbl);
            this.trackGroupBox.Controls.Add(this.trackNameTextBox);
            this.trackGroupBox.Controls.Add(this.trackNameLbl);
            this.trackGroupBox.Controls.Add(this.trackDownBtn);
            this.trackGroupBox.Controls.Add(this.trackUpBtn);
            this.trackGroupBox.Controls.Add(this.trackRemoveBtn);
            this.trackGroupBox.Controls.Add(this.trackAddBtn);
            this.trackGroupBox.Controls.Add(this.trackList);
            this.trackGroupBox.Location = new System.Drawing.Point(7, 124);
            this.trackGroupBox.Name = "trackGroupBox";
            this.trackGroupBox.Size = new System.Drawing.Size(558, 299);
            this.trackGroupBox.TabIndex = 4;
            this.trackGroupBox.TabStop = false;
            this.trackGroupBox.Text = "Tracks";
            // 
            // musicSlotCombo
            // 
            this.musicSlotCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.musicSlotCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.musicSlotCombo.FormattingEnabled = true;
            this.musicSlotCombo.Items.AddRange(new object[] {
            "LC   ",
            "MMM  ",
            "MG   ",
            "TF   ",
            "MC   ",
            "CM   ",
            "DKS  ",
            "WGM  ",
            "DC   ",
            "KC   ",
            "MT   ",
            "GV   ",
            "DDR  ",
            "MH   ",
            "BC   ",
            "RR   ",
            "gPB  ",
            "dYF  ",
            "sGV2 ",
            "nMR  ",
            "nSL  ",
            "gSGB ",
            "dDS  ",
            "gWS  ",
            "dDH  ",
            "gBC3 ",
            "nDKJP",
            "gMC  ",
            "sMC3 ",
            "dPG  ",
            "gDKM ",
            "nBC  "});
            this.musicSlotCombo.Location = new System.Drawing.Point(398, 159);
            this.musicSlotCombo.Name = "musicSlotCombo";
            this.musicSlotCombo.Size = new System.Drawing.Size(154, 21);
            this.musicSlotCombo.TabIndex = 12;
            this.musicSlotCombo.SelectedIndexChanged += new System.EventHandler(this.musicSlotCombo_SelectedIndexChanged);
            // 
            // propSlotCombo
            // 
            this.propSlotCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propSlotCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propSlotCombo.FormattingEnabled = true;
            this.propSlotCombo.Items.AddRange(new object[] {
            "LC   ",
            "MMM  ",
            "MG   ",
            "TF   ",
            "MC   ",
            "CM   ",
            "DKS  ",
            "WGM  ",
            "DC   ",
            "KC   ",
            "MT   ",
            "GV   ",
            "DDR  ",
            "MH   ",
            "BC   ",
            "RR   ",
            "gPB  ",
            "dYF  ",
            "sGV2 ",
            "nMR  ",
            "nSL  ",
            "gSGB ",
            "dDS  ",
            "gWS  ",
            "dDH  ",
            "gBC3 ",
            "nDKJP",
            "gMC  ",
            "sMC3 ",
            "dPG  ",
            "gDKM ",
            "nBC  "});
            this.propSlotCombo.Location = new System.Drawing.Point(242, 159);
            this.propSlotCombo.Name = "propSlotCombo";
            this.propSlotCombo.Size = new System.Drawing.Size(150, 21);
            this.propSlotCombo.TabIndex = 12;
            this.propSlotCombo.SelectedIndexChanged += new System.EventHandler(this.propSlotCombo_SelectedIndexChanged);
            // 
            // musicSlotLbl
            // 
            this.musicSlotLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.musicSlotLbl.AutoSize = true;
            this.musicSlotLbl.Location = new System.Drawing.Point(395, 143);
            this.musicSlotLbl.Name = "musicSlotLbl";
            this.musicSlotLbl.Size = new System.Drawing.Size(54, 13);
            this.musicSlotLbl.TabIndex = 11;
            this.musicSlotLbl.Text = "Music slot";
            // 
            // propertySlotLbl
            // 
            this.propertySlotLbl.AutoSize = true;
            this.propertySlotLbl.Location = new System.Drawing.Point(239, 143);
            this.propertySlotLbl.Name = "propertySlotLbl";
            this.propertySlotLbl.Size = new System.Drawing.Size(65, 13);
            this.propertySlotLbl.TabIndex = 11;
            this.propertySlotLbl.Text = "Property slot";
            // 
            // browseBtn
            // 
            this.browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBtn.Location = new System.Drawing.Point(477, 94);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 10;
            this.browseBtn.Text = "Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // trackFileTextBox
            // 
            this.trackFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackFileTextBox.Location = new System.Drawing.Point(242, 96);
            this.trackFileTextBox.Name = "trackFileTextBox";
            this.trackFileTextBox.Size = new System.Drawing.Size(229, 20);
            this.trackFileTextBox.TabIndex = 9;
            // 
            // trackFileLbl
            // 
            this.trackFileLbl.AutoSize = true;
            this.trackFileLbl.Location = new System.Drawing.Point(239, 80);
            this.trackFileLbl.Name = "trackFileLbl";
            this.trackFileLbl.Size = new System.Drawing.Size(51, 13);
            this.trackFileLbl.TabIndex = 8;
            this.trackFileLbl.Text = "Track file";
            // 
            // trackNameTextBox
            // 
            this.trackNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackNameTextBox.Location = new System.Drawing.Point(242, 36);
            this.trackNameTextBox.Name = "trackNameTextBox";
            this.trackNameTextBox.Size = new System.Drawing.Size(310, 20);
            this.trackNameTextBox.TabIndex = 7;
            this.trackNameTextBox.TextChanged += new System.EventHandler(this.trackNameTextBox_TextChanged);
            // 
            // trackNameLbl
            // 
            this.trackNameLbl.AutoSize = true;
            this.trackNameLbl.Location = new System.Drawing.Point(239, 20);
            this.trackNameLbl.Name = "trackNameLbl";
            this.trackNameLbl.Size = new System.Drawing.Size(64, 13);
            this.trackNameLbl.TabIndex = 6;
            this.trackNameLbl.Text = "Track name";
            // 
            // trackDownBtn
            // 
            this.trackDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackDownBtn.Location = new System.Drawing.Point(181, 264);
            this.trackDownBtn.Name = "trackDownBtn";
            this.trackDownBtn.Size = new System.Drawing.Size(52, 29);
            this.trackDownBtn.TabIndex = 5;
            this.trackDownBtn.Text = "Down";
            this.trackDownBtn.UseVisualStyleBackColor = true;
            this.trackDownBtn.Click += new System.EventHandler(this.trackDownBtn_Click);
            // 
            // trackUpBtn
            // 
            this.trackUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackUpBtn.Location = new System.Drawing.Point(123, 264);
            this.trackUpBtn.Name = "trackUpBtn";
            this.trackUpBtn.Size = new System.Drawing.Size(52, 29);
            this.trackUpBtn.TabIndex = 5;
            this.trackUpBtn.Text = "Up";
            this.trackUpBtn.UseVisualStyleBackColor = true;
            this.trackUpBtn.Click += new System.EventHandler(this.trackUpBtn_Click);
            // 
            // trackRemoveBtn
            // 
            this.trackRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackRemoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackRemoveBtn.Location = new System.Drawing.Point(65, 264);
            this.trackRemoveBtn.Name = "trackRemoveBtn";
            this.trackRemoveBtn.Size = new System.Drawing.Size(52, 29);
            this.trackRemoveBtn.TabIndex = 5;
            this.trackRemoveBtn.Text = "--";
            this.trackRemoveBtn.UseVisualStyleBackColor = true;
            this.trackRemoveBtn.Click += new System.EventHandler(this.trackRemoveBtn_Click);
            // 
            // trackAddBtn
            // 
            this.trackAddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackAddBtn.Location = new System.Drawing.Point(7, 264);
            this.trackAddBtn.Name = "trackAddBtn";
            this.trackAddBtn.Size = new System.Drawing.Size(52, 29);
            this.trackAddBtn.TabIndex = 5;
            this.trackAddBtn.Text = "+";
            this.trackAddBtn.UseVisualStyleBackColor = true;
            this.trackAddBtn.Click += new System.EventHandler(this.trackAddBtn_Click);
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackList.FormattingEnabled = true;
            this.trackList.Location = new System.Drawing.Point(7, 20);
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(226, 238);
            this.trackList.TabIndex = 0;
            this.trackList.SelectedIndexChanged += new System.EventHandler(this.trackList_SelectedIndexChanged);
            // 
            // cupName
            // 
            this.cupName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cupName.Location = new System.Drawing.Point(113, 7);
            this.cupName.Name = "cupName";
            this.cupName.Size = new System.Drawing.Size(452, 20);
            this.cupName.TabIndex = 3;
            this.cupName.TextChanged += new System.EventHandler(this.cupName_TextChanged);
            // 
            // cupImage
            // 
            this.cupImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cupImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cupImage.Location = new System.Drawing.Point(7, 7);
            this.cupImage.Name = "cupImage";
            this.cupImage.Size = new System.Drawing.Size(100, 100);
            this.cupImage.TabIndex = 2;
            this.cupImage.TabStop = false;
            this.cupImage.DoubleClick += new System.EventHandler(this.cupImage_DoubleClick);
            // 
            // cupDownBtn
            // 
            this.cupDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cupDownBtn.Location = new System.Drawing.Point(777, 394);
            this.cupDownBtn.Name = "cupDownBtn";
            this.cupDownBtn.Size = new System.Drawing.Size(52, 29);
            this.cupDownBtn.TabIndex = 1;
            this.cupDownBtn.Text = "Down";
            this.cupDownBtn.UseVisualStyleBackColor = true;
            this.cupDownBtn.Click += new System.EventHandler(this.cupDownBtn_Click);
            // 
            // cupUpBtn
            // 
            this.cupUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cupUpBtn.Location = new System.Drawing.Point(709, 394);
            this.cupUpBtn.Name = "cupUpBtn";
            this.cupUpBtn.Size = new System.Drawing.Size(52, 29);
            this.cupUpBtn.TabIndex = 1;
            this.cupUpBtn.Text = "Up";
            this.cupUpBtn.UseVisualStyleBackColor = true;
            this.cupUpBtn.Click += new System.EventHandler(this.cupUpBtn_Click);
            // 
            // cupRemoveBtn
            // 
            this.cupRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cupRemoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cupRemoveBtn.Location = new System.Drawing.Point(641, 394);
            this.cupRemoveBtn.Name = "cupRemoveBtn";
            this.cupRemoveBtn.Size = new System.Drawing.Size(52, 29);
            this.cupRemoveBtn.TabIndex = 1;
            this.cupRemoveBtn.Text = "--";
            this.cupRemoveBtn.UseVisualStyleBackColor = true;
            this.cupRemoveBtn.Click += new System.EventHandler(this.cupRemoveBtn_Click);
            // 
            // cupAddBtn
            // 
            this.cupAddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cupAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cupAddBtn.Location = new System.Drawing.Point(573, 394);
            this.cupAddBtn.Name = "cupAddBtn";
            this.cupAddBtn.Size = new System.Drawing.Size(52, 29);
            this.cupAddBtn.TabIndex = 1;
            this.cupAddBtn.Text = "+";
            this.cupAddBtn.UseVisualStyleBackColor = true;
            this.cupAddBtn.Click += new System.EventHandler(this.cupAddBtn_Click);
            // 
            // cupList
            // 
            this.cupList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cupList.FormattingEnabled = true;
            this.cupList.Location = new System.Drawing.Point(571, 0);
            this.cupList.Name = "cupList";
            this.cupList.Size = new System.Drawing.Size(264, 381);
            this.cupList.TabIndex = 0;
            this.cupList.SelectedIndexChanged += new System.EventHandler(this.cupList_SelectedIndexChanged);
            // 
            // ctDef
            // 
            this.ctDef.Controls.Add(this.ctDefTextBox);
            this.ctDef.Location = new System.Drawing.Point(4, 22);
            this.ctDef.Name = "ctDef";
            this.ctDef.Size = new System.Drawing.Size(835, 431);
            this.ctDef.TabIndex = 2;
            this.ctDef.Text = "CT-DEF";
            this.ctDef.UseVisualStyleBackColor = true;
            // 
            // ctDefTextBox
            // 
            this.ctDefTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctDefTextBox.Location = new System.Drawing.Point(3, 3);
            this.ctDefTextBox.Name = "ctDefTextBox";
            this.ctDefTextBox.ReadOnly = true;
            this.ctDefTextBox.Size = new System.Drawing.Size(829, 425);
            this.ctDefTextBox.TabIndex = 0;
            this.ctDefTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(867, 496);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PackDev";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.projectConfig.ResumeLayout(false);
            this.projectConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctDefFlagsGroup.ResumeLayout(false);
            this.ctDefFlagsGroup.PerformLayout();
            this.trackModeGroup.ResumeLayout(false);
            this.trackModeGroup.PerformLayout();
            this.tracks.ResumeLayout(false);
            this.tracks.PerformLayout();
            this.trackGroupBox.ResumeLayout(false);
            this.trackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cupImage)).EndInit();
            this.ctDef.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickImportToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tracks;
        private System.Windows.Forms.TabPage projectConfig;
        private System.Windows.Forms.ListBox cupList;
        private System.Windows.Forms.Button cupDownBtn;
        private System.Windows.Forms.Button cupUpBtn;
        private System.Windows.Forms.Button cupRemoveBtn;
        private System.Windows.Forms.Button cupAddBtn;
        private System.Windows.Forms.PictureBox cupImage;
        private System.Windows.Forms.TextBox cupName;
        private System.Windows.Forms.GroupBox trackGroupBox;
        private System.Windows.Forms.Button trackDownBtn;
        private System.Windows.Forms.Button trackUpBtn;
        private System.Windows.Forms.Button trackRemoveBtn;
        private System.Windows.Forms.Button trackAddBtn;
        private System.Windows.Forms.ListBox trackList;
        private System.Windows.Forms.Label trackNameLbl;
        private System.Windows.Forms.TextBox trackNameTextBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox trackFileTextBox;
        private System.Windows.Forms.Label trackFileLbl;
        private System.Windows.Forms.ComboBox propSlotCombo;
        private System.Windows.Forms.Label propertySlotLbl;
        private System.Windows.Forms.ComboBox musicSlotCombo;
        private System.Windows.Forms.Label musicSlotLbl;
        private System.Windows.Forms.TabPage ctDef;
        private System.Windows.Forms.RichTextBox ctDefTextBox;
        private System.Windows.Forms.ToolStripMenuItem customImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRiivolutionPackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.TextBox packNameTextBox;
        private System.Windows.Forms.Label packNameLabel;
        private System.Windows.Forms.CheckBox wiimmCupCheckBox;
        private System.Windows.Forms.GroupBox trackModeGroup;
        private System.Windows.Forms.RadioButton swapRadBtn;
        private System.Windows.Forms.RadioButton showRadBtn;
        private System.Windows.Forms.RadioButton hideRadBtn;
        private System.Windows.Forms.RadioButton noneRadBtn;
        private System.Windows.Forms.GroupBox ctDefFlagsGroup;
        private System.Windows.Forms.CheckBox leFlagsCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox perfMonCheckBox;
        private System.Windows.Forms.CheckBox enable200CheckBox;
        private System.Windows.Forms.CheckBox cheatModeCheckBox;
        private System.Windows.Forms.CheckBox ctTTCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphabeticallyAZToolStripMenuItem;
    }
}

