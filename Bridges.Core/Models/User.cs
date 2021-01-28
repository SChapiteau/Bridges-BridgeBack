using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
