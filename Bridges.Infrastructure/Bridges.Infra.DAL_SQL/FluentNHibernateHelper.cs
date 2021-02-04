using Bridges.Core.Models;
using Bridges.Infra.DAL_SQL.Utilisateurs;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Infra.DAL_SQL
{
    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession(string connectionString)
        {
            
            ISessionFactory sessionFactory = Fluently.Configure()
                                                     .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())

                .Mappings(m =>m.FluentMappings
                                .AddFromAssemblyOf<UserMap>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }
    }
}
