using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.Models.OfferModels
{
    public class OfferSearchParameter
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> ImageLinks { get; set; }

        public DateTime CreationDate { get; set; }

        public User Owner { get; set; }
    }


}
