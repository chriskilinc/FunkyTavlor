using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public bool Visable { get; set; }
        //String Format
        public string Presentation
        {
            get { return $"{Title} av {Artist} i rum {Room}"; }
        }

        public override string ToString()
        {
            return Presentation;

        }
    }
}
