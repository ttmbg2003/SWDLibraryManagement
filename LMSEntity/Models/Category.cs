using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public string Id { get; set; } = null!;
        public string Cname { get; set; } = null!;
        public int? Status { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
