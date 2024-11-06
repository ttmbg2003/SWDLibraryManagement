using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    public interface ICategoryDAO
    {
        public List<Category> GetCategories();
        void AddCategory(Category category);

        // Phương thức xóa danh mục dựa trên Id
        bool DeleteCategory(string categoryId);
        public bool VerifyBookInformation(Category category);
    }
}
