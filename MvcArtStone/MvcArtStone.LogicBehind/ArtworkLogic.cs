﻿using System;
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

        public void EditArtworkByModel(Artwork model)
        {
            ArtworkRepository.EditArtworkByModel(model);
        }


        public Artwork GetSingleArtworkById(string id)
        {
            Artwork singleArtwork = _repository.GetSingleArtworkById(id);
            return singleArtwork;
        }

        public static void DeleteArtworkwithId(Guid? id)
        {
            if (id != Guid.Empty)
            {
                ArtworkRepository.DeleteSingleArtworkWithId(id);
            }                       
        }



        public static void AddArtwork(ArtworkInsertModel model)
        {
            ArtworkRepository.AddArtwork(model);
        }

        public IEnumerable<Artwork> SearchArtworks(string searchString)
        {
            return ArtworkRepository.SearchArtworks(searchString);
        }
    }
}
