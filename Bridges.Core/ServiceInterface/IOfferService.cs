using Bridges.Core.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IOfferService
    {
        void CreateOffer(Offer offer);

        void UpdateOffer(Offer offer);

        void DeleteOffer(Offer offer);

       IEnumerable<Offer> GetOffer(OfferSearchParameter offer); 
    }
}
