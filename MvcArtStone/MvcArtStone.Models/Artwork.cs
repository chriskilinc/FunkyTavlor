﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace MvcArtStone.Models
{
    public class Artwork : TableEntity
    {
        public Artwork()
        {
            
        }

        public Artwork(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {
            this.PartitionKey = Title;
            this.RowKey = Id.ToString();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime AddedDate { get; set; }
        public byte InStorage { get; set; }
    }
}
