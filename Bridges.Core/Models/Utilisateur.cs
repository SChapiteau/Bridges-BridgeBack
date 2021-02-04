using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.Models
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual RoleUtilisateur Role { get; set; }
        //public string Password { get; set; }
        public virtual string Token { get; set; } //Notion a supprimer ( uniquement pour le front )
        public virtual bool IsActive { get; set; }
    }

    public enum RoleUtilisateur
    {
        ADMIN = 1,
        UtilisatUTILISATEUR =2,
    }
}
