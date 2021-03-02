using Bridges.Core.Models;
using Bridges.Core.Models.OfferModels;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridges.Infra.DAL_SQL.UserDAL
{
    public class OfferMap : ClassMap<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();
            Map(x => x.Title);            
            Map(x => x.Description);
            Map(x => x.CreationDate);
            Map(x => x.ImageLinks);
            Map(x => x.IsVisible);
            References(x => x.Owner, "UserId").Cascade.None();
        }
    }
}
