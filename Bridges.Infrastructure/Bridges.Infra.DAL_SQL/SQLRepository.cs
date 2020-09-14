using Microsoft.Extensions.Configuration;
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

        private static SqlConnection _currentConnection;
        
        public SqlConnection CurrentConnection
        {
            get {
                if (_currentConnection == null)
                {
                    var connectionString = _configuration["ConnectionString"];
                    _currentConnection = new SqlConnection(connectionString);
                }
                return _currentConnection;
            }
        }
    }
}
