using BridgeCore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Infra.DAL_SQL
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();
            Map(x => x.SIRET);
            Map(x => x.Name);
        }
    }
}
