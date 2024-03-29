﻿using System.Collections.Generic;
using System.IO;
using System;
using System.Drawing;
using System.Xml;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;

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

        // 0 = None
        // 1 = Hide
        // 2 = Show
        // 3 = Swap
        private int _ninTrackMode;

        private int _som;

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
            this._som = 0;
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

        // Return the pack's name
        public string Name { get { return this._name; } }

        // Returns the Speedometer Level
        public int SomLevel { get { return _som; }  }

        // Returns true if the Performance Monitor is enabled
        public bool PerfMonEnabled { get { return _perfMon; } }

        // Returns true if 200cc is enabled
        public bool MoreCC { get { return _200cc; } }
        
        // Returns true if CT Time Trials is enabled
        public bool CTTimeTrialsEnabled { get { return _ctTimeTrial; } }


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

        // Sets speed-o-meter
        public void SetSom(int som) { this._som = som; }



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
        private void WiimmCommand(string tool, string args)
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
        }

        // Exports as riivolution pack
        private async void ExportRiivHelper(string path, string image, BackgroundWorker bw)
        {

            // wit X '.\Mario Kart Wii (USA).iso' --psel DATA -D '.\Mario Kart Wii (USA).d'
            bw.ReportProgress(0);

            // 1. Extract image file
            //-----------------------
            string packdevWorkingDir = Path.Combine(path, "packdev-working-dir");

            // Console.WriteLine(packdevWorkingDir);
            ExtractImage(image, packdevWorkingDir);

            // Alert user if ISO has incorrect format and abort
            if (!Directory.Exists(Path.Combine(packdevWorkingDir, "files")))
            {
                //MessageBox.Show(
                //    "Image file is either in an unrecognized format or invalid",
                //    "Unrecognized Format",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
                throw new Exception("Image file is either in an unrecognized format or invalid");
            }

            bw.ReportProgress(30);
            if (bw.CancellationPending) return;



            // 2. Create main directories
            //----------------------------
            string sdRoot = Path.Combine(path, "riiv-sd");
            Directory.CreateDirectory(sdRoot);

            string patchDir = Path.Combine(sdRoot, FormatName());
            Directory.CreateDirectory(patchDir);

            string riivDir = Path.Combine(sdRoot, "riivolution");
            Directory.CreateDirectory(riivDir);

            bw.ReportProgress(35);
            if (bw.CancellationPending) return;



            // 3. Save CT-DEF.txt and create cup images
            //------------------------------------------
            string ctdef = CTDEF.Save(patchDir);

            bw.ReportProgress(40);
            if (bw.CancellationPending) return;




            // 4. Create Scene/UI
            //--------------------
            string sceneDir = Path.Combine(patchDir, "Scene");
            Directory.CreateDirectory(sceneDir);

            string uiDir = Path.Combine(sceneDir, "UI");
            Directory.CreateDirectory(uiDir);

            // Patch menu files
            string originalUIDir = Path.Combine(packdevWorkingDir, "files", "Scene", "UI");

            PatchMenuFiles(originalUIDir, uiDir, bw);

            // Create and patch BMG files
            CreateBMGFiles(originalUIDir, ctdef, uiDir);

            bw.ReportProgress(60);
            if (bw.CancellationPending) return;



            // 5. Create rel directory
            //-------------------------
            string relDir = Path.Combine(patchDir, "rel");
            Directory.CreateDirectory(relDir);

            // Copy StaticR.rel
            string staticR = Path.Combine(packdevWorkingDir, "files", "rel", "StaticR.rel");

            File.Copy(staticR, Path.Combine(relDir, "StaticR.rel"), true);

            // Export le-code config file
            string lecodeBin = WriteLECODEBin(image, relDir);

            // Patch le-code config file
            PatchLECODEConfig(lecodeBin);

            bw.ReportProgress(70);
            if (bw.CancellationPending) return;



            // 6. Create Race/Course
            //-----------------------
            string raceDir = Path.Combine(patchDir, "Race");
            Directory.CreateDirectory(raceDir);

            string courseDir = Path.Combine(raceDir, "Course");
            Directory.CreateDirectory(courseDir);

            // Copy course SZS files to directory
            foreach (Cup c in Cups)
            {
                foreach (Track t in c.Tracks)
                {
                    if (File.Exists(t.File))
                    {
                        File.Copy(t.File, Path.Combine(courseDir, Path.GetFileName(t.File)), true);
                    }
                }
            }

            // Patch courses to le-code config file
            PatchTracksToLECODEBin(lecodeBin, ctdef, courseDir);

            // Put original nintendo tracks into track folder if necessary
            if (NinTrackMode > 1)
            {
                string origCourse = Path.Combine(packdevWorkingDir, "files", "Race", "Course");
                List<Slot> targets = SlotDatabase.TrackSlots;
                targets.Sort((x, y) => string.Compare(x.ID.ToString(), y.ID.ToString()));
                foreach (Slot target in targets)
                {
                    foreach (string file in Directory.GetFiles(origCourse))
                    {
                        string shortName = Path.GetFileNameWithoutExtension(file);
                        if (shortName == target.FileName)
                        {
                            File.Copy(
                                file,
                                Path.Combine(courseDir, $"{target.ID.ToString("x3")}.szs")
                            );

                            File.Copy(
                                Path.Combine(origCourse, $"{shortName}_d.szs"),
                                Path.Combine(courseDir, $"{target.ID.ToString("x3")}_d.szs")
                            );

                            break;
                        }
                    }
                }
            }

            bw.ReportProgress(90);
            if (bw.CancellationPending) return;



            // 7. Create sys directory
            //-------------------------
            string sysDir = Path.Combine(patchDir, "sys");
            Directory.CreateDirectory(sysDir);

            // Copy main.dol
            string mainDol = Path.Combine(packdevWorkingDir, "sys", "main.dol");
            File.Copy(mainDol, Path.Combine(sysDir, "main.dol"), true);

            // Patch main.dol
            PatchMainDol(Path.Combine(sysDir, "main.dol"));

            bw.ReportProgress(95);
            if (bw.CancellationPending) return;



            // 8. Write XML
            //--------------
            string xml = Path.Combine(riivDir, $"{FormatName()}.xml");
            WriteRiivXML(xml, courseDir, uiDir, Path.GetFileName(lecodeBin), GetImageID(image));

            bw.ReportProgress(100);
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

        // Write lecode.bin file bytes from resources
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
        public void PatchMenuFiles(string path, string output, BackgroundWorker bw)
        {
            int currentProgress = 40;

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

                //Progress after replacing files
                bw.ReportProgress(currentProgress++);

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

                bw.ReportProgress(currentProgress++);

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
            Image outputImage = Properties.Resources.ct_icons;

            switch (_ninTrackMode)
            {
                case 0: // None
                    outputImage = Properties.Resources.ct_icons_none;
                    break;
                case 1: // Hide
                    outputImage = Properties.Resources.ct_icons_none;
                    break;
                case 2: // Show
                    outputImage = Properties.Resources.ct_icons_show;
                    break;
                case 3: // Swap
                    outputImage = Properties.Resources.ct_icons;
                    break;
            }

            if (_ninTrackMode <= 1)
                outputImage = Properties.Resources.ct_icons_none;

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
            argument.Append($"--custom-tt={(_ctTimeTrial ? "ON" : "OFF")} ");

            string somString = "";
            switch (_som)
            {
                case 0:
                    somString = "OFF";
                    break;
                case 1:
                    somString = "ON";
                    break;
                case 2:
                    somString = "1DIGIT";
                    break;
                case 3:
                    somString = "2DIGITS";
                    break;
                case 4:
                    somString = "3DIGITS";
                    break;
                default:
                    somString = "OFF";
                    break;
            }

            argument.Append($"--speedometer={somString} ");

            WiimmCommand("WLECT", argument.ToString());
            Console.WriteLine(argument);
        }

        // Adds a single new cup to the projects
        public void AddCup(string name) 
        {
            Cup newCup = new Cup();
            newCup.SetName(name);
            this._cups.Add(newCup); 
        }

        // Adds a predefined cup to the projects
        public void AddCup(Cup c)
        {
            this._cups.Add(c);
        }

        // Removes given cup from the list
        public void RemoveCupAt(int index) 
        {
            if (index < 0 || index >= this._cups.Count)
                return;

            this._cups.RemoveAt(index); 
        }

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

        // Exports as riivolution pack
        //
        // path:    output directory
        // image:   path to image file
        public void ExportRiiv(string path, string image)
        {
            BackgroundWorker bw = new BackgroundWorker();

            ProgressForm pf = new ProgressForm(bw, "Exporting riivolution pack...");
            pf.Show();

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += (sender, e) => ExportRiivHelper(path, image, bw);
            bw.ProgressChanged += (sender, e) => pf.UpdateProgress(e.ProgressPercentage);
            bw.RunWorkerCompleted += (sender, e) =>
            {
                pf.UpdateProgress(100, "Export Completed!");
                bw.Dispose();
            };

            bw.RunWorkerAsync();
        }
    }
}
