using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            ImportBills = new HashSet<ImportBill>();
        }

        public string Sid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<ImportBill> ImportBills { get; set; }
    }
}
