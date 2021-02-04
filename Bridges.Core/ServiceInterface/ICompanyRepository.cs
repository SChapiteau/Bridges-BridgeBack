using System;
using System.Collections.Generic;
using System.Text;
using BridgeCore.Models;

namespace Bridges.Core.ServiceInterface
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
    }
}
