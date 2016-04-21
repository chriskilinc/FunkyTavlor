using System;
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

        public void AddCompany(MvcArtStone.Models.Artwork Artwork)
        {
            //TODO: Do validation checks
            if(Artwork.Title == null)
                throw new NullReferenceException("Artwork Title can not be null!");

            //torepo
        }

        public static void AddArtwork(Artwork model)
        {
            if (model != null)
            {
                ArtworkRepository.AddArtwork(model);
            }
           
        }
    }
}
