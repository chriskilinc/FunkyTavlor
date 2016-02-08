using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
    public class Artwork
    {
        public int ArtId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public double Rum { get; set; }
        public string Image { get; set; }
        public bool Visable { get; set; }

        public Artwork(int artid, string artist, string titel, string description, double rum, string image, bool visable)
        {
            ArtId = artid;
            Artist = artist;
            Title = titel;
            Description = description;
            Rum = rum;
            Image = image;
            Visable = visable;
        }
        List<Artwork> Inventory;
        public Artwork()
        {
            Inventory = new List<Artwork>();
            //Inventory.Add(new Artwork() { ArtId = 1, Artist = "Picasso", Title = "Guernica" });
            //etc...
        }
    }
}
