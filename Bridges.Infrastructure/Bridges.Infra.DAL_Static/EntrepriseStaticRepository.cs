using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using System;
using System.Collections.Generic;

namespace Bridges.Infra.DAL_Static
{
    public class EntrepriseStaticRepository : ICompanyRepository
    {
        public IEnumerable<Company> GetAll()
        {
            return new List<Company> {
                new Company{Name = "Entreprise Static 1", SIRET ="11111"},
                new Company{Name = "Entreprise Static 2", SIRET ="22222"},
                new Company{Name = "Entreprise Static 3", SIRET ="33333"},
                new Company{Name = "Entreprise Static 4", SIRET ="44444"},
                new Company{Name = "Entreprise Static 5", SIRET ="55555"},
                new Company{Name = "Entreprise Static 6", SIRET ="66666"},
                new Company{Name = "Entreprise Static 7", SIRET ="77777"},
                new Company{Name = "Entreprise Static 8", SIRET ="8888"},
                new Company{Name = "Entreprise Static 9", SIRET ="99999"},
                new Company{Name = "Entreprise Static 10", SIRET ="aaaaa"},
                new Company{Name = "Entreprise Static 11", SIRET ="bbbbb"},
                new Company{Name = "Entreprise Static 12", SIRET ="ccccc"},
                new Company{Name = "Entreprise Static 12", SIRET ="ddddd"},
                new Company{Name = "Entreprise Static 14", SIRET ="eeeee"},
                new Company{Name = "Entreprise Static 15", SIRET ="fffff"},
                new Company{Name = "Entreprise Static 16", SIRET ="ggggg"},
                new Company{Name = "Entreprise Static 17", SIRET ="hhhhh"},
                new Company{Name = "Entreprise Static 18", SIRET ="iiiii"},
            };
        }
    }
}
