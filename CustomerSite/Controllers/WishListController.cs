using LMSDAO.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerSite.Controllers {
    public class WishListController : Controller {
        private readonly IWishListDAO _wishListDAO;

        public WishListController(IWishListDAO wishListDAO) {
            _wishListDAO = wishListDAO;
        }

        public string currentLogin = "U001";

        public IActionResult Index() {
            return View();
        }

        public IActionResult WishListView() {

            var wishlist = _wishListDAO.GetWishListItems(currentLogin);

            if (wishlist == null) {
                return View("Error");
            }

            return View(wishlist);
        }

        public ActionResult Delete(string bid) {
            _wishListDAO.RemoveWishListItem(currentLogin, bid);

            return RedirectToAction("WishListView");
        }
    }
}
