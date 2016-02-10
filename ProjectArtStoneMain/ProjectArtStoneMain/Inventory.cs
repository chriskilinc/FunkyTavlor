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
            new Artwork() {Id = 1, Artist = "Kalle", Title = "Kvack" },
            new Artwork() {Id = 2, Artist = "Pelle", Title = "Inte Olle" },
            new Artwork() {Id = 3, Artist = "Jocke", Title = "cashhhh" },
            new Artwork() {Id = 0, Artist = "Daniil", Title = "Poop" },
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
