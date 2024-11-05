using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class BookCopy
    {
        public BookCopy()
        {
            Brs = new HashSet<BorrowInformation>();
        }

        public string Id { get; set; } = null!;
        public string? Bid { get; set; }
        public string? Condition { get; set; }
        public int? Status { get; set; }

        public virtual Book? BidNavigation { get; set; }

        public virtual ICollection<BorrowInformation> Brs { get; set; }
    }
}
