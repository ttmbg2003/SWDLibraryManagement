using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class Blog
    {
        public string Bid { get; set; } = null!;
        public string StaffId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }

        public virtual User Staff { get; set; } = null!;
    }
}
