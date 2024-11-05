using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class BorrowInformation
    {
        public BorrowInformation()
        {
            Bcps = new HashSet<BookCopy>();
        }

        public string Oid { get; set; } = null!;
        public string Rid { get; set; } = null!;
        public string StaffId { get; set; } = null!;
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? TotalAmount { get; set; }
        public string? Note { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Status { get; set; }

        public virtual User Staff { get; set; } = null!;

        public virtual ICollection<BookCopy> Bcps { get; set; }
    }
}
