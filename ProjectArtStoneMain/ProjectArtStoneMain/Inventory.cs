//using ProjectArtStone;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProjectArtStoneMain
//{
//    public class Inventory
//    {
//        //Detta är en variabel
//        //public static List<Artwork> ArtworkList = new List<Artwork>()
//        //{
//        //    new Artwork() {Id = 0, Artist = "Kalle", Title = "Tavla 1" },
//        //    new Artwork() {Id = 1, Artist = "Pelle", Title = "Tavla 2" },
//        //    new Artwork() {Id = 2, Artist = "Jocke", Title = "Tavla 3" },
//        //    new Artwork() {Id = 3, Artist = "Daniil", Title = "Tavla 4" }
//        //};

//        //Använd IEnumerable<T> som är mer ABSTRACTR än List<T>

//        public IEnumerable<Artwork> GetArtworkList
//        {
//            get { return ArtworkList; }
//        }

//        public void AddArtwork(int id, string title, string artist, string room, string description)
//        {
//            ArtworkList.Add(new Artwork() { Id = id, Title = title, Artist = artist, Room = room, Description = description, Visable = true });
//        }

//        public void RemoveFromInventory(int id)
//        {
//            ArtworkList.Remove(ArtworkList.Where(x => x.Id == id).FirstOrDefault());
//        }
//    }
//}
