using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace ProjectArtStone
{
    public class Artwork : TableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }  // ?????????????????????????????????? ? vis Able ? ????????? ???????????????????
        //String Format
        public string Presentation
        {
            get { return $"{Title} av {Artist} i rum {Room}"; }
        }

        public Artwork(string title, int id)
        {
            this.PartitionKey = title;
            this.RowKey = id.ToString();
        }

        //public override string ToString()
        //{
        //    return P;

        //}
    }
}
