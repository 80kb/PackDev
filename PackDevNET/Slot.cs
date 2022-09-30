namespace PackDevNET
{
    internal class Slot
    {
        public int ID { get; set; }
        public int MusicID { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        public Slot(int id, int musicId, string name, string fileName)
        {
            ID = id;
            MusicID = musicId;
            Name = name;
            FileName = fileName;
        }
    }
}
