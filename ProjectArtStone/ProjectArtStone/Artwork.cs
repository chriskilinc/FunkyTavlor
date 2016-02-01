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
        public string Titel { get; set; }
        public string Description { get; set; }
        public double Rum { get; set; }
        public string ImagePath { get; set; }

        public Artwork(int artid, string titel, string description, double rum)
        {
            ArtId = artid;
            Titel = titel;
            Description = description;
            Rum = rum;
        }

        public Artwork()
        {
        }
    }
}
