using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Core.Models.OfferModels
{
    public class Offer
    {
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        //public virtual IEnumerable<string> ImageLinks { get; set; }
        public virtual string ImageLinks { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual User Owner { get; set; }

        public virtual bool IsVisible { get; set; }

        public virtual bool IsValid() // A remplacer par un validateur
        {
            return !string.IsNullOrEmpty(Title)
                && !string.IsNullOrEmpty(Description);
                //&& Owner != null;
        }
    }


}
