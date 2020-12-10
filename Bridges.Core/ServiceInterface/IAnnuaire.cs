using System.Collections.Generic;
using BridgeCore.Models;

namespace BridgeCore.ServiceInterface
{
    public interface IAnnuaire
    {
        IEnumerable<Entreprise> GetAll();
    }
}