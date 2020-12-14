using System.Collections.Generic;
using BridgeCore.Models;

namespace Bridges.Core.ServiceInterface
{
    public interface IAnnuaire
    {
        IEnumerable<Entreprise> GetAll();
    }
}