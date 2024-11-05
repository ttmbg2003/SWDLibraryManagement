using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class ImportBill
    {
        public ImportBill()
        {
            ImportBillBooks = new HashSet<ImportBillBook>();
        }

        public string Id { get; set; } = null!;
        public string Sid { get; set; } = null!;
        public int? TotalAmount { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? Date { get; set; }

        public virtual Supplier SidNavigation { get; set; } = null!;
        public virtual ICollection<ImportBillBook> ImportBillBooks { get; set; }
    }
}
