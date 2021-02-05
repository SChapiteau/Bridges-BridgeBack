using Bridges.Core.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Infra.DAL_SQL.Utilisateurs
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Firstname);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.Role).CustomType(typeof(UserRole));
            Map(x => x.IsActive);            

            //Table("User");
        }
    }
}
