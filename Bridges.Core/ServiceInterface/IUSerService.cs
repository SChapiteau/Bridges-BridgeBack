using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IUSerService
    {
        bool AddUser(User user);
        IEnumerable<User> GetAllUser();
    }
}
