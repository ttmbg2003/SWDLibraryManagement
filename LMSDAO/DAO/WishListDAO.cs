using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMSDAO.DAO {
    public class WishListDAO : IWishListDAO {
        public void AddNewWishListItem(string wid, string bid) {
            throw new NotImplementedException();
        }

        public bool CheckAvailabilityInWishList(string wid, string bid) {
            throw new NotImplementedException();
        }

        public Wishlist GetWishListItems(string rid) {
            return LMS_SWDContext.Ins.Wishlists.Include(x => x.Bids)
                .Where(x => x.Uid.Equals(rid))
                .FirstOrDefault();
        }

        public void RemoveWishListItem(string uid, string bid) {
            Wishlist wishlist = LMS_SWDContext.Ins.Wishlists
                .Where(x => x.Uid.Equals(uid))
                .FirstOrDefault();

            if (wishlist != null) {
                Book bookToRemove = wishlist.Bids
                    .FirstOrDefault(b => b.BookId == bid);

                if (bookToRemove != null) {
                    wishlist.Bids.Remove(bookToRemove);
                }
            }

            LMS_SWDContext.Ins.SaveChanges();
        }
    }
}
