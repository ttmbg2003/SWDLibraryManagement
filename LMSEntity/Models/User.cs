using System;
using System.Collections.Generic;

namespace LMSEntity.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            BorrowInformations = new HashSet<BorrowInformation>();
            Wishlists = new HashSet<Wishlist>();
        }

        public string Uid { get; set; } = null!;
        public string Rid { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Status { get; set; }

        public virtual Role RidNavigation { get; set; } = null!;
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<BorrowInformation> BorrowInformations { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
