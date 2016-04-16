using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcArtStone.Models
{
    public class Artwork
    {
        public string Title { get; set; }
        public string Artsit { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime AddedDate { get; set; }
        public byte InStorage { get; set; }
    }
}
