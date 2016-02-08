using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArtStoneMain
{
    class Program
    {
        List<Artwork> Inventory;
        public Program()
        {
            Inventory = new List<Artwork>();
            Inventory.Add(new Artwork() { ArtworkId = 1, Artist = "Picasso", Title = "Guernica" });
            //etc...
            //Använd DataBindning för att koppla Inventory till kontrollen ni anv för att visa konstverken
            //Alla operationer (lägg till, redigera, ta bort = CRUD) jobbar mot Inventory
            //Senare är det enkelt att ersätta Inventory med en riktig DB (och till molnet)
            //för en skateboard räcker detta
            //EXTRA
            //Kan vi se till att spara Inventory, när programmet avslutas alt ha en sparaknapp
            //är ett stort plus!
            //TIPS: Kolla hur man kan spara hela listan (Inventory) direkt till disk
            //genom att serialisera den.
            //https://msdn.microsoft.com/en-us/library/c5sbs8z9(v=vs.110).aspx
            //exemplet anv en HashTable men vi har en List, annars samma...
            //testa genom att skapa knappar för att spara och läsa in
            //när programmet startar ska man då kunna läsa in data från fil
            //och sedan spara uppdaterad data till fil
        }
    }
    public class Artwork
    {
        public int ArtworkId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}
