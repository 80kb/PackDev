using System;

namespace PackDevNET
{
    public class Track
    {
        private string _file;
        private string _name;
        private int _propertySlot;
        private int _musicSlot;

        // Vars to be implemented
        private int _speed;
        private int _lapCount;



        // Initialize a new empty track
        public Track()
        {
            this._file = string.Empty;
            this._name = string.Empty;
            this._propertySlot  = DetermineSlot();
            this._musicSlot     = this._propertySlot;
            this._speed       = 1; // Default speed value
            this._lapCount    = 3; // Default lap count
        }

        // Initialize a new track with the given information
        public Track(string file, string name, int propertySlot, int musicSlot)
        {
            this._file = file;
            this._name = name;
            this._propertySlot  = propertySlot;
            this._musicSlot     = musicSlot;
        }



        //TODO: Read track file to determine invalid slots for track
        private int DetermineSlot()
        {
            return 0;
        }



        // Getters
        public string File { get { return _file; } }
        public string Name { get { return _name; } }
        public int PropertySlot { get { return _propertySlot; } }
        public int MusicSlot { get { return _musicSlot; } }
        public int Speed { get { return _speed; } }
        public int lapCount { get { return _lapCount; } }

        // Setters
        public void SetFile(string file) { _file = file; }
        public void SetName(string name) { _name = name; }
        public void SetPropertySlot(int propertySlot) { _propertySlot = propertySlot; }
        public void SetMusicSlot(int musicSlot) { _musicSlot = musicSlot; }
    }
}
