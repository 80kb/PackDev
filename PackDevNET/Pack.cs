using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Xml;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PackDevNET
{
    public class Pack
    {
        private List<Cup> _cups;
        private bool _flags;
        private bool _wiimmCup;
        private bool _ctTimeTrial;
        private bool _200cc;
        private bool _perfMon;
        private CTDEF _ctDef;
        private string _name;
        private int _ninTrackMode;

        // Initialize with default values
        public Pack()
        {
            this._cups = new List<Cup>();
            this._wiimmCup = false;
            this._flags = true;
            this._ctDef = new CTDEF(this);
            this._name = "Untitled Pack";
            this._ninTrackMode = 0;
            this._ctTimeTrial = true;
            this._200cc = false;
            this._perfMon = false;
        }



        //-----------------------------
        //----- Getters & Setters -----
        //-----------------------------

        // Returns list of cups
        public List<Cup> Cups { get { return this._cups; } }

        // Returns flag value
        public bool Flags { get { return this._flags; } }

        // Returns wiimm cup value
        public bool WiimmCup { get { return this._wiimmCup; } }

        // Returns the CT-DEF object
        public CTDEF CTDEF { get { return this._ctDef; } }

        // Returns the nintendo track mode
        public int NinTrackMode { get { return this._ninTrackMode; } }



        // Sets _ninTrackMode
        public void SetNinTrackMode(int mode) { this._ninTrackMode = mode; }

        // Sets Wiimm Cup
        public void SetWiimmCup(bool wiimmCup) { this._wiimmCup = wiimmCup; }

        // Sets pack name
        public void SetName(string name) { this._name = name; }

        // Sets CT Time Trial
        public void SetCTTimeTrial(bool ctTimeTrial) { this._ctTimeTrial = ctTimeTrial; }

        // Sets 200cc
        public void Set200cc(bool p200cc) { this._200cc = p200cc; }

        // Sets performance monitor
        public void SetPerfMon(bool perfMon) { this._perfMon = perfMon; }



        //--------------------------
        //----- Helper Methods -----
        //--------------------------

        // Finds the cups with the least amount of tracks and returns them as a queue
        private Queue<Cup> FindSmallestCups()
        {
            Queue<Cup> result = new Queue<Cup>();

            foreach (Cup cup in this._cups)
            {
                if (cup.Count < 4)
                {
                    result.Enqueue(cup);
                }
            }

            return result;
        }

        // Calls a wiimms tool command
        private bool WiimmCommand(string tool, string args)
        {
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;
            string WITPath = Path.Combine(workingDir, "Wiimm", $"{tool}.exe");

            using (Process wit = new Process())
            {
                wit.StartInfo.FileName = WITPath;
                wit.StartInfo.Arguments = args;

                wit.StartInfo.RedirectStandardOutput = true;
                wit.StartInfo.RedirectStandardError = true;
                wit.StartInfo.UseShellExecute = false;
                wit.StartInfo.CreateNoWindow = true;

                wit.Start();
                wit.WaitForExit();
            }

            return true;
        }



        //--------------------------
        //----- Public Methods -----
        //--------------------------

        // Sorts tracks alphabetically by name
        public void SortTracks()
        {
            // Get list of all tracks
            List<Track> allTracks = new List<Track>();
            foreach(Cup c in _cups)
            {
                foreach(Track t in c.Tracks)
                {
                    allTracks.Add(t);
                }
            }

            // Sort allTracks
            allTracks.Sort((x, y) => string.Compare(x.Name, y.Name));

            // Reinsert tracks into cups
            Queue<Track> allTrackQueue = new Queue<Track>(allTracks);
            foreach (Cup c in _cups)
            {
                if (allTrackQueue.Count <= 0)
                    break;

                c.Clear();

                for(int i = 0; i < 4; i++)
                {
                    if (allTrackQueue.Count <= 0)
                        break;

                    c.Tracks.Add(allTrackQueue.Dequeue());
                }
            }
        }

        // returns the name of the pack formatted for the files
        public string FormatName()
        {
            return Regex.Replace(_name, @"\s+", "");
        }

        // Get the ID of an MKW Image file
        //
        // path: path to image file
        public string GetImageID(string path)
        {
            StringBuilder sb = new StringBuilder();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                for (int i = 0; i < 6; i++)
                    sb.Append((char)fs.ReadByte());
            }

            return sb.ToString();
        }

        // Extract the MKW Image file
        //
        // path:    path to image file
        // output:  path to extracted image folder
        public void ExtractImage(string path, string output)
        {
            WiimmCommand("WIT", $"X \"{path}\" -q -o --psel DATA -D \"{output}\"");
        }

        // Build the MKW Image file
        //
        // path:    path to the folder containing the extracted image
        // output:  path to new image file
        public void BuildImage(string path, string output)
        {
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;

            string WITPath = Path.Combine(workingDir, "Wiimm", "WIT.exe");
            Process wit = Process.Start(WITPath, $"COPY \"{path}\" -D \"{output}\" -o");
            wit.WaitForExit();
        }

        // Patch the main.dol to run le-code
        //
        // path: path to main.dol file
        public void PatchMainDol(string path)
        {
            WiimmCommand("WSTRT", $"patch \"{path}\" --clean-dol --add-lecode -o");
        }

        // Write lecode.bin file
        //
        // image:   path to the image file
        // path:    path to the output folder
        public string WriteLECODEBin(string image, string path)
        {
            string ID = GetImageID(image);
            if (ID == "RMCE01")
            {
                string outputFile = Path.Combine(path, "lecode-USA.bin");
                File.WriteAllBytes(outputFile, Properties.Resources.lecode_USA);
                return outputFile;
            }
            else if (ID == "RMCJ01")
            {
                string outputFile = Path.Combine(path, "lecode-JAP.bin");
                File.WriteAllBytes(outputFile, Properties.Resources.lecode_JAP);
                return outputFile;
            }
            else if (ID == "RMCK01")
            {
                string outputFile = Path.Combine(path, "lecode-KOR.bin");
                File.WriteAllBytes(outputFile, Properties.Resources.lecode_KOR);
                return outputFile;
            }
            else if (ID == "RMCP01")
            {
                string outputFile = Path.Combine(path, "lecode-PAL.bin");
                File.WriteAllBytes(outputFile, Properties.Resources.lecode_PAL);
                return outputFile;
            }

            return string.Empty;
        }

        // Patch tracks to lecode.bin and copy them to new location
        //
        // lecodeBin:   Path to lecode.bin file
        // ctDefTxt:    Path to CT-DEF.txt file
        // directory:   Path to track directory
        public void PatchTracksToLECODEBin(string lecodeBin, string ctDefTxt, string directory)
        {
            StringBuilder patchTracksArgs = new StringBuilder();
            patchTracksArgs.Append($"patch \"{lecodeBin}\" --le-define \"{ctDefTxt}\"");
            patchTracksArgs.Append($" --track-dir \"{directory}\"");
            patchTracksArgs.Append($" --move-tracks \"{directory}\" -o");

            // Console.WriteLine(patchTracksArgs.ToString());

            WiimmCommand("WLECT", patchTracksArgs.ToString());
        }

        // Patch the menu files in the given ui folder
        //
        // path:    path to folder containing menu files
        // output:  path to output folder
        public void PatchMenuFiles(string path, string output)
        {
            string[] files = new string[] {
                "Channel.szs",
                "Event.szs",
                "Globe.szs",
                "MenuMulti.szs",
                "MenuOther.szs",
                "MenuSingle.szs",
                "Present.szs",
                "Race.szs",
                "Title.szs"
            };

            foreach (string file in files)
            {
                string currentPath = Path.Combine(path, file);
                string dynamicDir = Path.Combine(path, Path.GetFileNameWithoutExtension(file) + ".d");
                string outputFile = Path.Combine(output, file);

                WiimmCommand("WSZST", $"X \"{currentPath}\"");

                if (File.Exists(Path.Combine(dynamicDir, "button", "blyt", "cup_icon_64x64_common.brlyt")))
                {
                    File.Delete(Path.Combine(dynamicDir, "button", "blyt", "cup_icon_64x64_common.brlyt"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "button", "blyt", "cup_icon_64x64_common.brlyt"), Properties.Resources.cup_icon_64x64_common);
                }

                if (File.Exists(Path.Combine(dynamicDir, "button", "ctrl", "Back.brctr")))
                {
                    File.Delete(Path.Combine(dynamicDir, "button", "ctrl", "Back.brctr"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "button", "ctrl", "Back.brctr"), Properties.Resources.Back);
                }

                if (File.Exists(Path.Combine(dynamicDir, "button", "ctrl", "CupSelectCup.brctr")))
                {
                    File.Delete(Path.Combine(dynamicDir, "button", "ctrl", "CupSelectCup.brctr"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "button", "ctrl", "CupSelectCup.brctr"), Properties.Resources.CupSelectCup);
                }

                if (File.Exists(Path.Combine(dynamicDir, "control", "blyt", "cup_icon_64x64_common.brlyt")))
                {
                    File.Delete(Path.Combine(dynamicDir, "control", "blyt", "cup_icon_64x64_common.brlyt"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "control", "blyt", "cup_icon_64x64_common.brlyt"), Properties.Resources.cup_icon_64x64_common);
                }

                if (File.Exists(Path.Combine(dynamicDir, "control", "ctrl", "CourseSelectCup.brctr")))
                {
                    File.Delete(Path.Combine(dynamicDir, "control", "ctrl", "CourseSelectCup.brctr"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "control", "ctrl", "CourseSelectCup.brctr"), Properties.Resources.CourseSelectCup);
                }

                if (File.Exists(Path.Combine(dynamicDir, "demo", "blyt", "course_name.brlyt")))
                {
                    File.Delete(Path.Combine(dynamicDir, "demo", "blyt", "course_name.brlyt"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "demo", "blyt", "course_name.brlyt"), Properties.Resources.course_name);
                }

                if (File.Exists(Path.Combine(dynamicDir, "demo", "timg", "tt_hatena_64x64.tpl.brlyt")))
                {
                    File.Delete(Path.Combine(dynamicDir, "demo", "timg", "tt_hatena_64x64.tpl.brlyt"));
                    File.WriteAllBytes(Path.Combine(dynamicDir, "demo", "timg", "tt_hatena_64x64.tpl.brlyt"), Properties.Resources.course_name);
                }

                // Cup Images
                if (Path.GetFileNameWithoutExtension(file) == "MenuMulti" || Path.GetFileNameWithoutExtension(file) == "MenuSingle")
                {
                    string imgOutput0 = Path.Combine(dynamicDir, "button", "timg", "ct_icons.tpl");
                    try
                    {
                        CreateCupImages(imgOutput0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string imgOutput1 = Path.Combine(dynamicDir, "control", "timg", "ct_icons.tpl");
                    try
                    {
                        CreateCupImages(imgOutput1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                WiimmCommand("WSZST", $"CREATE \"{dynamicDir}\" -D \"{outputFile}\" -o");

                //Directory.Delete(dynamicDir, true);
            }
        }

        // Create BMG files and patch them to their corresponding menu files
        //
        // path:    path to folder containing menu files
        // ctdef:   path to ctdef text file
        // output:  path to output folder
        public void CreateBMGFiles(string path, string ctdef, string outputDir)
        {
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;
            foreach (string file in Directory.EnumerateFiles(path, "*.szs"))
            {
                string currentPath = Path.Combine(path, file);
                string dynamicDir = Path.Combine(path, Path.GetFileNameWithoutExtension(file) + ".d");
                string outputFile = Path.Combine(outputDir, Path.GetFileName(file));
                // Console.WriteLine(outputFile);

                WiimmCommand("WSZST", $"X \"{currentPath}\"");

                string commonBmg = Path.Combine(dynamicDir, "message", "Common.bmg");
                if (File.Exists(commonBmg))
                {
                    // Save all.bmg.txt, and encode it
                    string allBmg = Path.Combine(dynamicDir, "message", "all.bmg");
                    File.WriteAllText(allBmg + ".txt", Properties.Resources.all_bmg);
                    WiimmCommand("WBMGT", $"ENCODE \"{allBmg}\".txt");

                    // Convert CT-DEF into bmg.txt
                    string WCTCTPath = Path.Combine(workingDir, "Wiimm", "WCTCT.exe");
                    Process wctct = new Process();
                    wctct.StartInfo.FileName = WCTCTPath;
                    wctct.StartInfo.Arguments = $"--lecode BMG \"{ctdef}\" -l --patch-bmg INSERT=\"{allBmg}\"";
                    wctct.StartInfo.UseShellExecute = false;
                    wctct.StartInfo.RedirectStandardOutput = true;
                    wctct.StartInfo.CreateNoWindow = true;
                    wctct.Start();

                    string output = wctct.StandardOutput.ReadToEnd();
                    StreamWriter sw = new StreamWriter(commonBmg + ".txt");
                    sw.Write(output);
                    sw.Close();

                    wctct.WaitForExit();

                    // Conglomerate all BMGs and encode
                    WiimmCommand("WBMGT", $"PAT \"{commonBmg}\" -P INSERT=\"{commonBmg}.txt\" -o");
                    WiimmCommand("WSZST", $"CREATE \"{dynamicDir}\" -D \"{outputFile}\" -o");
                }

                //Directory.Delete(dynamicDir, true);
            }
        }

        // Write XML file for patching riivolution pack
        //
        // path:    path to output XML
        // courses: path to course folder
        // ui:      path to ui folder
        // id:      image file id
        // lecode:  lecode file name
        public void WriteRiivXML(string path, string courses, string ui, string lecode, string id)
        {
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            // <?xml version="1.0" encoding="utf-8"?>
            writer.WriteStartDocument();
            writer.WriteStartElement("wiidisc");
            writer.WriteAttributeString("version", "1");

            writer.WriteStartElement("id");
            writer.WriteAttributeString("game", id.Substring(0, 4));
            writer.WriteAttributeString("disc", "0");
            writer.WriteAttributeString("version", "0");
            writer.WriteEndElement(); // id

            writer.WriteStartElement("options");
            writer.WriteStartElement("section");
            writer.WriteAttributeString("name", _name);

            #region Begin options
            writer.WriteStartElement("option");
            writer.WriteAttributeString("id", _name + "-tracks");
            writer.WriteAttributeString("name", "Custom Tracks + Arenas");
            writer.WriteAttributeString("default", "1");
            writer.WriteStartElement("choice");
            writer.WriteAttributeString("name", "Enabled");

            writer.WriteStartElement("patch");
            writer.WriteAttributeString("id", _name + "_tracks");
            writer.WriteEndElement(); // patch

            writer.WriteEndElement(); // choice
            writer.WriteEndElement(); // option
            #endregion

            writer.WriteEndElement(); // section
            writer.WriteEndElement(); // options

            #region Begin patches

            writer.WriteStartElement("patch");
            writer.WriteAttributeString("id", _name + "_tracks");

            // Patch Race/Course
            foreach (string file in Directory.EnumerateFiles(courses, "*.szs"))
            {
                string fileName = Path.GetFileName(file);

                writer.WriteStartElement("file");
                writer.WriteAttributeString("disc", "/Race/Course/" + fileName);
                writer.WriteAttributeString("external", $"/{FormatName()}/Race/Course/{fileName}");
                writer.WriteAttributeString("create", "true");
                writer.WriteEndElement();
            }

            // Patch Scene/UI
            foreach (string file in Directory.EnumerateFiles(ui, "*.szs"))
            {
                string fileName = Path.GetFileName(file);

                writer.WriteStartElement("file");
                writer.WriteAttributeString("disc", "/Scene/UI/" + fileName);
                writer.WriteAttributeString("external", $"/{FormatName()}/Scene/UI/{fileName}");
                writer.WriteAttributeString("create", "true");
                writer.WriteEndElement();
            }

            // Patch StaticR.rel and le-code config file
            writer.WriteStartElement("file");
            writer.WriteAttributeString("disc", "/rel/StaticR.rel");
            writer.WriteAttributeString("external", $"/{FormatName()}/rel/StaticR.rel");
            writer.WriteAttributeString("create", "true");
            writer.WriteEndElement();

            writer.WriteStartElement("file");
            writer.WriteAttributeString("disc", $"/rel/{lecode}");
            writer.WriteAttributeString("external", $"/{FormatName()}/rel/{lecode}");
            writer.WriteAttributeString("create", "true");
            writer.WriteEndElement();

            // Patch main.dol
            writer.WriteStartElement("folder");
            writer.WriteAttributeString("external", $"/{FormatName()}/sys");
            writer.WriteAttributeString("recursive", "false");
            writer.WriteEndElement();

            writer.WriteStartElement("folder");
            writer.WriteAttributeString("external", $"/{FormatName()}/sys");
            writer.WriteAttributeString("disc", "/");
            writer.WriteEndElement();

            writer.WriteEndElement(); // patch

            #endregion

            writer.WriteEndElement(); // wiidisc
            writer.WriteEndDocument();

            writer.Close();
        }

        // Create cup image tpl file
        //
        // path: path to image output as a .tpl
        public void CreateCupImages(string path)
        {
            Image outputImage = _ninTrackMode <= 1 ? Properties.Resources.ct_icons_none : Properties.Resources.ct_icons;

            if (_wiimmCup)
            {
                Image cupImage = new Bitmap(Properties.Resources.wiimm_icon, 128, 128);
                Image newImage = new Bitmap(128, outputImage.Height + 128);

                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(outputImage, 0, 0);
                g.DrawImage(cupImage, 0, outputImage.Height);

                outputImage = newImage;
            }

            foreach(Cup c in _cups)
            {
                Image cupImage = new Bitmap(c.Image, 128, 128);
                Image newImage = new Bitmap(128, outputImage.Height + 128);

                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(outputImage, 0, 0);
                g.DrawImage(cupImage, 0, outputImage.Height);

                outputImage = newImage;
            }

            string pngOut = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".png");
            outputImage.Save(pngOut);

            WiimmCommand("WIMGT", $"copy \"{pngOut}\" \"{path}\" -x=cmpr -o");

            File.Delete(pngOut);
        }

        // Patches the le-code config file
        //
        // path: path to le-code config file
        public void PatchLECODEConfig(string path)
        {
            StringBuilder argument = new StringBuilder();
            argument.Append($"patch \"{path}\" -o ");
            argument.Append($"--200cc={(_200cc ? "ON" : "OFF")} ");
            argument.Append($"--perf-mon={(_perfMon ? "FORCE" : "OFF")} ");
            argument.Append($"--custom-tt={(_ctTimeTrial ? "ON" : "OFF")}");

            WiimmCommand("WLECT", argument.ToString());

        }

        // Adds a single new cup to the projects
        public void AddCup(string name) 
        {
            Cup newCup = new Cup();
            newCup.SetName(name);
            this._cups.Add(newCup); 
        }

        // Removes given cup from the list
        public void RemoveCupAt(int index) { this._cups.RemoveAt(index); }

        // Swap cups at the given indices
        public void SwapCups(int index, int newIndex)
        {
            Cup cupInNewIndex = this._cups[newIndex];

            this._cups[newIndex] = this._cups[index];
            this._cups[index] = cupInNewIndex;
        }

        // Adds cups from a list of tracks. Creates as many cups that are needed based on track amount,
        // then appends the tracks.
        public void AddCupsFromTracks(Queue<Track> tracks)
        {
            Queue<Cup> smallestCups = FindSmallestCups();
            Cup newCup = new Cup();

            while (tracks.Count > 0)
            {
                // look at the smallest cups in the list
                // fill these cups before appending more cups
                if (smallestCups.Count > 0)
                {
                    Cup current = smallestCups.Peek();

                    // 3 because it will add one more after this check
                    // so if it is 4 then you could end up with 5 tracks in a cup
                    if (current.Count >= 3)
                        current = smallestCups.Dequeue();

                    current.AddTrack(tracks.Dequeue());
                    continue;
                }

                // Fill the new cup with as many tracks as possible
                // Once full, append to list and create new cup
                if (newCup.Count < 4)
                {
                    newCup.AddTrack(tracks.Dequeue());
                }
                
                // Add the cup once it is full
                if (newCup.Count >= 4)
                {
                    newCup.SetName("Cup " + this._cups.Count);
                    this._cups.Add(newCup);
                    newCup = new Cup();
                }
            }

            // Even if the last cup is not full, make sure it is still appended
            if (newCup.Count > 0 && newCup.Count < 4)
            {
                newCup.SetName("Cup " + this._cups.Count);
                this._cups.Add(newCup);
            }
        }
    }
}
