using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetByLogin(string pseudo);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        User GetById(Guid id);
    }
}
