using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PackDevNET
{
    internal class CTDEF
    {
        private Pack _pack;
        private List<Cup> _cups;

        public CTDEF(Pack pack)
        {
            _pack = pack;
            _cups = _pack.Cups;
        }

        public string Save(string path)
        {
            string outputPath = Path.Combine(path, "CT-DEF.txt");

            StreamWriter sw = new StreamWriter(outputPath);
            sw.Write(ToString());
            sw.Close();

            return outputPath;
        }

        //-------------------
        //----- Helpers -----
        //-------------------

        private string ParseTrackMode(int mode)
        {
            switch (mode)
            {
                case 0: return "NONE";
                case 1: return "HIDE";
                case 2: return "SHOW";
                case 3: return "SWAP";
            }

            return "NONE";
        }



        //--------------------------
        //----- Public Methods -----
        //--------------------------

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            // Header stuff
            output.AppendLine("#CT-CODE");
            output.AppendLine("[RACING-TRACK-LIST]");
            output.AppendLine($"%LE-FLAGS  = {Convert.ToInt32(_pack.Flags)}");
            output.AppendLine($"%WIIMM-CUP = {Convert.ToInt32(_pack.WiimmCup)}");
            output.AppendLine($"N N${ParseTrackMode(_pack.NinTrackMode)}"); //TODO: Add variable for this

            int startSlotHex = 0x44;

            // Cups and tracks
            foreach (Cup cup in _cups)
            {
                output.AppendLine();
                output.AppendLine($"C \"{cup.Name}\"");

                foreach (Track track in cup.Tracks)
                {
                    output.AppendLine($"S 0x{startSlotHex.ToString("x2")}!");
                    output.AppendLine($"T T{(int)track.MusicSlot}; T{(int)track.PropertySlot}; 0x01; \"{Path.GetFileNameWithoutExtension(Path.GetFileName(track.File))}\"; \"{track.Name}\"; \"\"");
                    startSlotHex++;
                }
            }

            return output.ToString();
        }
    }
}
