using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class Wishlist
    {
        public Wishlist()
        {
            Bids = new HashSet<Book>();
        }

        public string Id { get; set; } = null!;
        public string Uid { get; set; } = null!;
        public DateTime? DateTime { get; set; }

        public virtual User UidNavigation { get; set; } = null!;

        public virtual ICollection<Book> Bids { get; set; }
    }
}
