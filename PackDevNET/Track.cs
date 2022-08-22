using System;

namespace PackDevNET
{
    enum Slot
    {
        LC    = 11,
        MMM   = 12,
        MG    = 13,
        TF    = 14,
        MC    = 21,
        CM    = 22,
        DKS   = 23,
        WGM   = 24,
        DC    = 31,
        KC    = 32,
        MT    = 33,
        GV    = 34,
        DDR   = 41,
        MH    = 42,
        BC    = 43,
        RR    = 44,
        gPB   = 51,
        dYF   = 52,
        sGV2  = 53,
        nMR   = 54,
        nSL   = 61,
        gSGB  = 62,
        dDS   = 63,
        gWS   = 64,
        dDH   = 71,
        gBC3  = 72,
        nDKJP = 73,
        gMC   = 74,
        sMC3  = 81,
        dPG   = 82,
        gDKM  = 83,
        nBC   = 84
    }

    internal class Track
    {
        private string _file;
        private string _name;
        private Slot _propertySlot;
        private Slot _musicSlot;

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
        public Track(string file, string name, Slot propertySlot, Slot musicSlot)
        {
            this._file = file;
            this._name = name;
            this._propertySlot  = propertySlot;
            this._musicSlot     = musicSlot;
        }



        //TODO: Read track file to determine invalid slots for track
        private Slot DetermineSlot()
        {
            return Slot.LC;
        }



        //--------------------------
        //----- Helper Methods -----
        //--------------------------

        // Get slot id from index value
        private Slot SlotFromIndex(int index)
        {
            int slotID = ((int)Math.Ceiling((index + 1) / 4.0) * 10) + (index % 4) + 1;
            return (Slot)slotID;
        }

        // Get index value from slot id
        private int IndexFromSlot(Slot slot)
        {
            int firstDigit = (int)Math.Floor((int)slot / 10.0) - 1;
            int secondDigit = ((int)slot % 10) - 1;

            return (firstDigit * 4) + secondDigit;
        }



        // Getters
        public string File { get { return _file; } }
        public string Name { get { return _name; } }
        public Slot PropertySlot { get { return _propertySlot; } }
        public Slot MusicSlot { get { return _musicSlot; } }
        public int PropertyIndex { get { return IndexFromSlot(_propertySlot); } }
        public int MusicIndex { get { return IndexFromSlot(_musicSlot); } }
        public int Speed { get { return _speed; } }
        public int lapCount { get { return _lapCount; } }

        // Setters
        public void SetFile(string file) { _file = file; }
        public void SetName(string name) { _name = name; }
        public void SetPropertySlot(Slot propertySlot) { _propertySlot = propertySlot; }
        public void SetPropertySlot(int index) { _propertySlot = SlotFromIndex(index); }
        public void SetMusicSlot(Slot musicSlot) { _musicSlot = musicSlot; }
        public void SetMusicSlot(int index) { _musicSlot = SlotFromIndex(index); }
    }
}
