using Microsoft.AspNetCore.Mvc;

namespace AdminSite.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
