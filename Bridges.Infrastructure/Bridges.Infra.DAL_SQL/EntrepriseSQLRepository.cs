
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
    public class EntrepriseSQLRepository : SQLRepository, IEntrepriseRepository
    {
        public EntrepriseSQLRepository(IConfiguration iconfig) : base(iconfig)
        {
        }

        public IEnumerable<Entreprise> GetAll()
        {
            return CurrentConnection.Query<Entreprise>("Select * From Entreprise").ToList();            
        }
    }
}
