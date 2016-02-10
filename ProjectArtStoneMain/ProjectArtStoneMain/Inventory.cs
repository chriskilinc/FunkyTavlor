using ProjectArtStone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStoneMain
{
    public class Inventory
    {
        //Detta är en variabel
        public List<Artwork> ArtworkList = new List<Artwork>()
        {
            new Artwork() {Id = 1, Artist = "Kalle", Title = "Tavla 1" },
            new Artwork() {Id = 2, Artist = "Pelle", Title = "Tavla 2" },
            new Artwork() {Id = 3, Artist = "Jocke", Title = "Tavla 3" },
            new Artwork() {Id = 4, Artist = "Daniil", Title = "Tavla 4" },
        };

        //Använd IEnumerable<T> som är mer ABSTRACTR än List<T>

        public IEnumerable<Artwork> GetArtworkList
        {
            get { return ArtworkList; }
        }

        public void RemoveFromInventory(int id)
        {
            ArtworkList.Remove(ArtworkList.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
