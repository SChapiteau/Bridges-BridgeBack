using System;
using System.Collections.Generic;
using System.Text;
using BridgeCore.Models;

namespace BridgeCore.ServiceInterface
{
    public interface IEntrepriseRepository
    {
        IEnumerable<Entreprise> GetAll();
    }
}
