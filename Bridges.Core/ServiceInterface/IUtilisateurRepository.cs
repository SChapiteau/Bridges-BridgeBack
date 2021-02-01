using Bridges.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.ServiceInterface
{
    public interface IUtilisateurRepository
    {
        IEnumerable<Utilisateur> GetAll();

        Utilisateur GetByPseudo(string pseudo);

        void AjoutUtilisateur(Utilisateur utilisateur);

        void ModifierUtilisateur(Utilisateur utilisateur);

        void SupprimerUtilisateur(Guid utilisateurId);
    }
}
