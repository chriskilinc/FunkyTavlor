using System;
using MvcArtStone.Repository;

namespace MvcArtStone.LogicBehind
{
    public class CompanyBusiness
    {
        private readonly ArtworkRepository _repository;

        public CompanyBusiness()
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

    }
}
