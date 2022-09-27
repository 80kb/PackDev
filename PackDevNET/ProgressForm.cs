using System.IO;
using System.Windows.Forms;

namespace PackDevNET
{
    public partial class ProgressForm : Form
    {
        private Pack _pack;

        public ProgressForm(Pack pack)
        {
            InitializeComponent();

            MaximizeBox = false;
            _pack = pack;
        }

        public string ImageFileDir(string directoryPath)
        {
            if (!Directory.Exists(Path.Combine(directoryPath, "DATA")))
            {
                return directoryPath;
            }
            else if (Directory.Exists(Path.Combine(directoryPath, "DATA")))
            {
                return Path.Combine(directoryPath, "DATA");
            }
            else
            {
                throw new InvalidDataException("Unknown ISO Format");
            }
        }

        // Exports as riivolution pack
        //
        // path:    output directory
        // image:   path to image file
        public void ExportRiiv(string path, string image)
        {

            // wit X '.\Mario Kart Wii (USA).iso' --psel DATA -D '.\Mario Kart Wii (USA).d'

            // Initialize Progress Bar
            //-------------------------
            progressStepLabel.Text = "Extracting image file";
            progressBar.Step = 1;
            progressBar.Value = 0;
            progressBar.Maximum = 8;



            // 1. Extract image file
            //-----------------------
            string packdevWorkingDir = Path.Combine(path, "packdev-working-dir");

            // Console.WriteLine(packdevWorkingDir);
            _pack.ExtractImage(image, packdevWorkingDir);

            // Update progress bar
            progressStepLabel.Text = "Creating riivolution directories";
            progressBar.Value++;



            // 2. Create main directories
            //----------------------------
            string sdRoot = Path.Combine(path, "riiv-sd");
            Directory.CreateDirectory(sdRoot);

            string patchDir = Path.Combine(sdRoot, _pack.FormatName());
            Directory.CreateDirectory(patchDir);

            string riivDir = Path.Combine(sdRoot, "riivolution");
            Directory.CreateDirectory(riivDir);

            // Update progress bar
            progressStepLabel.Text = ("Saving CT-DEF");
            progressBar.Value++;



            // 3. Save CT-DEF.txt and create cup images
            //------------------------------------------
            string ctdef = _pack.CTDEF.Save(patchDir);

            // Update progress bar
            progressStepLabel.Text = ("Patching menu files");
            progressBar.Value++;



            // 4. Create Scene/UI
            //--------------------
            string sceneDir = Path.Combine(patchDir, "Scene");
            Directory.CreateDirectory(sceneDir);

            string uiDir = Path.Combine(sceneDir, "UI");
            Directory.CreateDirectory(uiDir);

            // Patch menu files
            string originalUIDir = Path.Combine(packdevWorkingDir, "files", "Scene", "UI");

            _pack.PatchMenuFiles(originalUIDir, uiDir);

            // Create and patch BMG files
            _pack.CreateBMGFiles(originalUIDir, ctdef, uiDir);

            // Update progress bar
            progressStepLabel.Text = ("Patching LE-CODE config files");
            progressBar.Value++;



            // 5. Create rel directory
            //-------------------------
            string relDir = Path.Combine(patchDir, "rel");
            Directory.CreateDirectory(relDir);

            // Copy StaticR.rel
            string staticR = Path.Combine(packdevWorkingDir, "files", "rel", "StaticR.rel");

            File.Copy(staticR, Path.Combine(relDir, "StaticR.rel"), true);

            // Export le-code config file
            string lecodeBin = _pack.WriteLECODEBin(image, relDir);

            // Patch le-code config file
            _pack.PatchLECODEConfig(lecodeBin);

            // Update progress bar
            progressStepLabel.Text = ("Copying SZS files");
            progressBar.Value++;



            // 6. Create Race/Course
            //-----------------------
            string raceDir = Path.Combine(patchDir, "Race");
            Directory.CreateDirectory(raceDir);

            string courseDir = Path.Combine(raceDir, "Course");
            Directory.CreateDirectory(courseDir);

            // Copy course SZS files to directory
            foreach (Cup c in _pack.Cups)
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
            _pack.PatchTracksToLECODEBin(lecodeBin, ctdef, courseDir);

            // Update progress bar
            progressStepLabel.Text = ("Patching main.dol");
            progressBar.Value++;



            // 7. Create sys directory
            //-------------------------
            string sysDir = Path.Combine(patchDir, "sys");
            Directory.CreateDirectory(sysDir);

            // Copy main.dol
            string mainDol = Path.Combine(packdevWorkingDir, "sys", "main.dol");
            File.Copy(mainDol, Path.Combine(sysDir, "main.dol"), true);

            // Patch main.dol
            _pack.PatchMainDol(Path.Combine(sysDir, "main.dol"));

            // Update progress bar
            progressStepLabel.Text = ("Writing XML");
            progressBar.Value++;



            // 8. Write XML
            //--------------
            string xml = Path.Combine(riivDir, $"{_pack.FormatName()}.xml");
            _pack.WriteRiivXML(xml, courseDir, uiDir, Path.GetFileName(lecodeBin), _pack.GetImageID(image));

            // Console.WriteLine("Process completed");
            progressStepLabel.Text = "";
            progressBar.Value++;

            MessageBox.Show("Exporting completed!");
            Close();
        }

        public void UpdateProgress(string message)
        {
            this.Invoke((MethodInvoker)delegate {
                progressStepLabel.Text = message;
            });
        }
    }
}
