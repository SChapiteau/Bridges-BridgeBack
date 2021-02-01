using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.Models
{
    public class Utilisateur
    {
        public Guid Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Pseudo { get; set; }
        public RoleUtilisateur Role { get; set; }
        //public string Password { get; set; }
        public string Token { get; set; } //Notion a supprimer ( uniquement pour le front )
        public bool EstActif { get; set; }
    }

    public enum RoleUtilisateur
    {
        ADMIN = 1,
        UtilisatUTILISATEUR =2,
    }
}
