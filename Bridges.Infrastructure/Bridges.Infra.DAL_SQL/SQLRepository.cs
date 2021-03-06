﻿using Microsoft.Extensions.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Bridges.Infra.DAL_SQL
{
    public class SQLRepository
    {
        private IConfiguration _configuration;

        public SQLRepository(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }      

        private static ISession _currentSession;
        public ISession CurrentSession
        {
            get
            {
                if(_currentSession == null)
                {
                    var connectionString = _configuration["ConnectionString"];
                    _currentSession = FluentNHibernateHelper.OpenSession(connectionString);
                }
                return _currentSession;
            }
        }

    }
}
