using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace PackDevNET
{
    public class PackSaverLoader
    {
        private static int _trackMode;
        private static bool _wiimm;
        private static bool _200cc;
        private static bool _perfMon;
        private static bool _ctTimeAttack;
        private static int _som;

        public static Pack Load(string xml)
        {
            Pack p = new Pack();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList xNodeList = xmlDoc.SelectNodes("/Pack");
            p.SetName(xNodeList[0].Attributes["Name"].Value);

            xNodeList = xmlDoc.SelectNodes("/Pack/Properties");
            foreach (XmlNode node in xNodeList[0])
            {
                switch (node.Name)
                {
                    case "NintendoTrackMode":
                        _trackMode = Convert.ToInt32(node.InnerText);
                        p.SetNinTrackMode(_trackMode);
                        break;

                    case "WiimmCup":
                        _wiimm = Convert.ToBoolean(node.InnerText);
                        p.SetWiimmCup(_wiimm);
                        break;

                    case "CheatMode":
                        // Not Implemented
                        break;

                    case "CCEnabled":
                        _200cc = Convert.ToBoolean(node.InnerText);
                        p.Set200cc(_200cc);
                        break;

                    case "PerfMonitor":
                        _perfMon = Convert.ToBoolean(node.InnerText);
                        p.SetPerfMon(_perfMon);
                        break;

                    case "CTTimeAttack":
                        _ctTimeAttack = Convert.ToBoolean(node.InnerText);
                        p.SetCTTimeTrial(_ctTimeAttack);
                        break;

                    case "Speedometer":
                        _som = Convert.ToInt32(node.InnerText);
                        p.SetSom(_som);
                        break;
                }
            }

            xNodeList = xmlDoc.SelectNodes("/Pack/Cups/Cup");

            List<Cup> cups = new List<Cup>();

            foreach (XmlNode node in xNodeList)
            {
                Cup c = new Cup();
                Image i = new Bitmap(Base64ToImage(node.Attributes["ImageBase64"].Value), 128, 128);

                c.SetName(node.Attributes["Name"].Value);
                c.SetImage(i);

                XmlNodeList xmlNodeList2 = node.ChildNodes;
                foreach (XmlNode tracknode in xmlNodeList2)
                {
                    string name = tracknode.Attributes["Name"].Value;
                    string file = tracknode.Attributes["File"].Value;

                    int propertyslot = Convert.ToInt32(tracknode.Attributes["PropertySlot"].Value);
                    int musicslot = Convert.ToInt32(tracknode.Attributes["MusicSlot"].Value);

                    int laps = Convert.ToInt32(tracknode.Attributes["Laps"].Value);
                    int speed = Convert.ToInt32(tracknode.Attributes["Speed"].Value);

                    Track t = new Track(file, name, propertyslot, musicslot);
                    t.SetLapCount(laps);
                    t.SetSpeed(speed);
                    c.AddTrack(t);
                }
                cups.Add(c);
            }

            foreach (Cup cup in cups)
                p.AddCup(cup);

            return p;
        }

        public static void Save(Pack p) => Save(p, p.Name + ".pd");

        public static void Save(Pack p, string filename)
        {
            File.Delete(filename);
            XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("Pack");
            writer.WriteAttributeString("Name", p.Name);

            // Properties
            writer.WriteStartElement("Properties");

            writer.WriteStartElement("NintendoTrackMode");
            writer.WriteString(p.NinTrackMode.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("WiimmCup");
            writer.WriteString(p.WiimmCup.ToString());
            writer.WriteEndElement();

            // Not Implemented
            writer.WriteStartElement("CheatMode");
            writer.WriteString(false.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("CCEnabled");
            writer.WriteString(p.MoreCC.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("PerfMonitor");
            writer.WriteString(p.PerfMonEnabled.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("CTTimeAttack");
            writer.WriteString(p.CTTimeTrialsEnabled.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Speedometer");
            writer.WriteString(p.SomLevel.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement(); // Properties

            writer.WriteStartElement("Cups");

            foreach (Cup c in p.Cups)
            {
                writer.WriteStartElement("Cup");
                writer.WriteAttributeString("Name", c.Name);
                writer.WriteAttributeString("ImageBase64", ImageToBase64(c.Image));

                foreach (Track t in c.Tracks)
                {
                    writer.WriteStartElement("Track");

                    writer.WriteAttributeString("Name", t.Name);
                    writer.WriteAttributeString("File", t.File);
                    writer.WriteAttributeString("PropertySlot", t.PropertySlot.ToString());
                    writer.WriteAttributeString("MusicSlot", t.MusicSlot.ToString());
                    writer.WriteAttributeString("Laps", t.lapCount.ToString());
                    writer.WriteAttributeString("Speed", t.Speed.ToString());

                    writer.WriteEndElement(); // Track
                }

                writer.WriteEndElement(); // Cup
            }

            writer.WriteEndElement(); // Cups

            writer.WriteEndElement(); // Pack
            writer.WriteEndDocument();

            writer.Close();
        }

        private static string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }

}
