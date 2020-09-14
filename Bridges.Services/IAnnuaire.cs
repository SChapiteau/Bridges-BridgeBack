using System.Collections.Generic;
using BridgeCore.Entreprise;

namespace Bridges.Services
{
    public interface IAnnuaire
    {
        IEnumerable<Entreprise> GetAll();
    }
}