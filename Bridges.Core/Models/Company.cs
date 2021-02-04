using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeCore.Models
{
    public class Company
    {
        public virtual Guid Id { get; set; }
        public virtual string SIRET { get; set; }

        public virtual string Name { get; set; }
    }
}
