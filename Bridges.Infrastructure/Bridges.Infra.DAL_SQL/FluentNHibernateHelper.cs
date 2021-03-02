using Bridges.Core.Models;
using Bridges.Infra.DAL_SQL.OfferDAL;
using Bridges.Infra.DAL_SQL.UserDAL;
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
            //UpdateDatabase(connectionString);

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m =>m.FluentMappings
                                .AddFromAssemblyOf<UserMap>()
                                .AddFromAssemblyOf<OfferMap>()
                                .AddFromAssemblyOf<CompanyMap>())

                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

        private static void UpdateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings
                                .AddFromAssemblyOf<UserMap>()
                                .AddFromAssemblyOf<CompanyMap>())
                .BuildConfiguration();

            //var exporter = new SchemaExport(configuration);
            var updater = new SchemaUpdate(configuration);
            //Console.WriteLine(exporter.t)
            updater.Execute(true, true);

            
        }
    }
}
