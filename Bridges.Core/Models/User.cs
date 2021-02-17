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
        public virtual UserRole Role { get; set; }
        public virtual string Password { get; set; }
        public virtual string Token { get; set; } //Notion a supprimer ( uniquement pour le front )
        public virtual bool IsActive { get; set; }

        public virtual bool isValid()
        {
            if (string.IsNullOrWhiteSpace(Login)) return false;
            if (string.IsNullOrWhiteSpace(Password)) return false;

            return true;
        }
    }

    public enum UserRole
    {
        ADMIN = 1,
        Consumer =2,
    }
}
