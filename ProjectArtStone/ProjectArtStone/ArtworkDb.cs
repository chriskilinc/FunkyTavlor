using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStone
{
    public class ArtworkDb
    {
        public static List<Artwork> Artlist { get; set; }
        public static List<Artwork> GetArts()
        {
            var list = new List<Artwork>()
            {
                new Artwork() {ArtId = 1, Titel="Pingviner på is", Description="Det är pingviner på is", Rum=3.14 },
                new Artwork() {ArtId = 2, Titel="Pingviner under is", Description="Pingviner i vattnet under isen", Rum=3.14 },
                new Artwork() {ArtId = 3, Titel="Örnens blick", Description="Örn som tittar in i kameran", Rum=4.20 }
            };
            return list;            
        }
    }    
}
