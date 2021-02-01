using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using System.Collections.Generic;

namespace Bridges.Services
{
    public class Annuaire : IAnnuaire
    {
        private readonly IEntrepriseRepository enterpriseRepository;

        public Annuaire(IEntrepriseRepository enterpriseRepository)
        {
            this.enterpriseRepository = enterpriseRepository;
        }
        public IEnumerable<Entreprise> GetAll()
        {
            return enterpriseRepository.GetAll();

        }
    }
}
