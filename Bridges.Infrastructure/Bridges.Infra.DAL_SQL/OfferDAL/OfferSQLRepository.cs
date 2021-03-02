using Bridges.Core.Models.OfferModels;
using Bridges.Core.ServiceInterface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Infra.DAL_SQL.OfferDAL
{
    public class OfferSQLRepository : SQLRepository ,IOfferRepository
    {

        public OfferSQLRepository(IConfiguration iconfig) : base(iconfig)
        {

        }

        public void CreateOffer(Offer offer)
        {
            using (var transaction = CurrentSession.BeginTransaction())
            {
                this.CurrentSession.Save(offer);
                transaction.Commit();
            }
        }

        public void DeleteOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetOffer(OfferSearchParameter offer)
        {
            throw new NotImplementedException();
        }

        public void UpdateOffer(Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
