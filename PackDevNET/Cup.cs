using System.Collections.Generic;
using System.Drawing;

namespace PackDevNET
{
    internal class Cup
    {
        private string _name { get; set; }
        private Image _image { get; set; }

        private List<Track> _tracks;



        // Initialize Cup with default values
        public Cup()
        {
            this._name = string.Empty;
            this._image = Properties.Resources.icon;

            this._tracks = new List<Track>();
        }



        // Return the track at the given index
        public Track GetTrack(int index) { return this._tracks[index]; }

        // Return the length of the cup
        public int Count { get { return this._tracks.Count; } }

        // Return the name of the cup
        public string Name { get { return this._name; } }

        // Return the image of the cup
        public Image Image { get { return this._image; } }

        // Return track list
        public List<Track> Tracks { get { return this._tracks; } }



        // Set cup name
        public void SetName(string name) { this._name = name; }

        // Set cup image
        public void SetImage(Image img) { this._image = img; }

        // Add a track to the end of the list
        public void AddTrack(Track track) { this._tracks.Add(track); }

        // Insert a track to the cup at the given index
        public void InsertTrack(Track track, int index) { this._tracks[index] = track; }

        // Remove a track from the cup at the given index
        public void RemoveTrack(int index) { this._tracks.RemoveAt(index); }

        // Swap the positions of two tracks in the cup
        public void SwapTracks(int index, int newIndex)
        {
            Track trackInNewIndex = GetTrack(newIndex);

            InsertTrack(GetTrack(index), newIndex);
            InsertTrack(trackInNewIndex, index);
        }
    }
}
