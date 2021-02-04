
using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using Bridges.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime;

namespace Bridges.Infra.DAL_SQL
{
    public class CompanySQLRepository : SQLRepository, ICompanyRepository
    {
        public CompanySQLRepository(IConfiguration iconfig) : base(iconfig)
        {
        }

        public IEnumerable<Company> GetAll()
        {                        
            return this.CurrentSession.Query<Company>();
        }
    }
}

