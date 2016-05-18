using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using MvcArtStone.Models;
using MvcArtStone.Repository;

namespace MvcArtStone.LogicBehind
{
    public class ArtworkLogic
    {
        private readonly ArtworkRepository _repository;

        public ArtworkLogic()
        {
            _repository = new ArtworkRepository();
        }

        //public void AddCompany(Artwork Artwork)
        //{
        //    //TODO: Do validation checks
        //    if(Artwork.Title == null)
        //        throw new NullReferenceException("Artwork Title can not be null!");

        //    //torepo
        //}
        public IEnumerable<Artwork> GetArtworkskInFatList()
        {
            var artlist = ArtworkRepository.GetPaintingsAsList();
            return artlist;
        }

        public Artwork GetSingleArtworkById(string id)
        {
            string PartitionKey = id.Split('_')[0];
            string RowKey = id.Split('_')[1];

            Artwork singleArtwork = _repository.GetSingleArtwork(PartitionKey, RowKey);
            return singleArtwork;
        }

        public static void AddArtwork(ArtworkInsertModel model)
        {
            string name = string.Empty;
            if (model.ImgUrl != null)
            {
                var fileEnding = model.ImgUrl.Split('.').Last();

                name = Guid.NewGuid() + "." + fileEnding;
            }

            //if (model.File.InputStream != null)
            //{
                ArtworkRepository.AddArtwork(model, name);
            //}

        }
    }
}
