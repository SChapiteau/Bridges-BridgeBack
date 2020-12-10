using BridgeCore.Models;
using BridgeCore.ServiceInterface;
using System;
using System.Collections.Generic;

namespace Bridges.Infra.DAL_Static
{
    public class EntrepriseStaticRepository : IEntrepriseRepository
    {
        public IEnumerable<Entreprise> GetAll()
        {
            return new List<Entreprise> {
                new Entreprise{Nom = "Entreprise Static 1", SIRET ="11111"},
                new Entreprise{Nom = "Entreprise Static 2", SIRET ="22222"},
                new Entreprise{Nom = "Entreprise Static 3", SIRET ="33333"},
                new Entreprise{Nom = "Entreprise Static 4", SIRET ="44444"},
                new Entreprise{Nom = "Entreprise Static 5", SIRET ="55555"},
                new Entreprise{Nom = "Entreprise Static 6", SIRET ="66666"},
                new Entreprise{Nom = "Entreprise Static 7", SIRET ="77777"},
                new Entreprise{Nom = "Entreprise Static 8", SIRET ="8888"},
                new Entreprise{Nom = "Entreprise Static 9", SIRET ="99999"},
                new Entreprise{Nom = "Entreprise Static 10", SIRET ="aaaaa"},
                new Entreprise{Nom = "Entreprise Static 11", SIRET ="bbbbb"},
                new Entreprise{Nom = "Entreprise Static 12", SIRET ="ccccc"},
                new Entreprise{Nom = "Entreprise Static 12", SIRET ="ddddd"},
                new Entreprise{Nom = "Entreprise Static 14", SIRET ="eeeee"},
                new Entreprise{Nom = "Entreprise Static 15", SIRET ="fffff"},
                new Entreprise{Nom = "Entreprise Static 16", SIRET ="ggggg"},
                new Entreprise{Nom = "Entreprise Static 17", SIRET ="hhhhh"},
                new Entreprise{Nom = "Entreprise Static 18", SIRET ="iiiii"},
            };
        }
    }
}
