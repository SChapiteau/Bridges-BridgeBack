using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IUSerService
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUser();
        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}
