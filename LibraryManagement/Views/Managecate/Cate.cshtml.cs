using LMSDAO.DAO;
using LMSEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminSite.Views.Managecate
{
    public class CateModel : PageModel
    {
        private readonly ICategoryDAO _categoryDAO;

        public CateModel(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public void OnGet()
        {
            Categories = _categoryDAO.GetCategories();
        }
    }
}
