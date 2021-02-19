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

        void AddUser(User utilisateur);

        void UpdateUser(User utilisateur);

        void DeleteUtilisateur(Guid utilisateurId);
        User GetById(Guid id);
    }
}
