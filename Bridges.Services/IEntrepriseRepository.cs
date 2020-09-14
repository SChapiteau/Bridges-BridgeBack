using BridgeCore.Entreprise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services
{
    public interface IEntrepriseRepository
    {
        IEnumerable<Entreprise> GetAll();
    }
}
