using Bridges.Core.Models.OfferModels;
using Bridges.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services.Offers
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public void CreateOffer(Core.Models.OfferModels.Offer offer)
        {
            _offerRepository.CreateOffer(offer);
        }

        public void DeleteOffer(Core.Models.OfferModels.Offer offer)
        {
            _offerRepository.DeleteOffer(offer);
        }

        public IEnumerable<Core.Models.OfferModels.Offer> GetOffer(OfferSearchParameter offerParameter)
        {
            return _offerRepository.GetOffer(offerParameter);
        }

        public void UpdateOffer(Core.Models.OfferModels.Offer offer)
        {
            _offerRepository.UpdateOffer(offer);
        }
    }
}
