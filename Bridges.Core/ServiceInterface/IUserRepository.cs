using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetByPseudo(string pseudo);

        void AddUser(User utilisateur);

        void ModifierUtilisateur(User utilisateur);

        void SupprimerUtilisateur(Guid utilisateurId);        
    }
}
