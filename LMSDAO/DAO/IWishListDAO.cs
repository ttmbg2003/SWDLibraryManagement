using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO {
    public interface IWishListDAO {
        public Wishlist GetWishListItems(string rid);
        public void RemoveWishListItem(string rid, string bid);
        public bool CheckAvailabilityInWishList(string wid, string bid);
        public void AddNewWishListItem(string wid, string bid);
    }
}
