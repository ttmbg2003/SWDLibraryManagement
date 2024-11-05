using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCopies = new HashSet<BookCopy>();
            ImportBillBooks = new HashSet<ImportBillBook>();
            Wids = new HashSet<Wishlist>();
        }

        public string BookId { get; set; } = null!;
        public string Cid { get; set; } = null!;
        public string Bname { get; set; } = null!;
        public string? Author { get; set; }
        public string? Quantity { get; set; }
        public double? QuantityInStock { get; set; }
        public double? TotalPage { get; set; }
        public double? CoverPrice { get; set; }
        public string? Description { get; set; }
        public double? Status { get; set; }

        public virtual Category CidNavigation { get; set; } = null!;
        public virtual ICollection<BookCopy> BookCopies { get; set; }
        public virtual ICollection<ImportBillBook> ImportBillBooks { get; set; }

        public virtual ICollection<Wishlist> Wids { get; set; }
    }
}
