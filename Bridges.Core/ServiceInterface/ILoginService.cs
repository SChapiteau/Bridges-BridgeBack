using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface ILoginService
    {
        string Authenticate(string username, string password);
    }
}
