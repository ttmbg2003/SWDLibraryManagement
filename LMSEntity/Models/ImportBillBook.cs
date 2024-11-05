using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class ImportBillBook
    {
        public string ImId { get; set; } = null!;
        public string Bid { get; set; } = null!;
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public string? Note { get; set; }

        public virtual Book BidNavigation { get; set; } = null!;
        public virtual ImportBill Im { get; set; } = null!;
    }
}
