using System.Collections.Generic;
using BridgeCore.Models;

namespace Bridges.Core.ServiceInterface
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
    }
}