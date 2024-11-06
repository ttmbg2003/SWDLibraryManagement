using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    internal class CategoryDAO : ICategoryDAO
    {
        public void AddCategory(Category category)
        {
            LMS_SWDContext.Ins.Categories.Add(category);
            LMS_SWDContext.Ins.SaveChanges();
        }

        public bool DeleteCategory(string categoryId)
        {
            // Tìm danh mục cần xóa dựa trên Id
            var category = LMS_SWDContext.Ins.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return false; // Không tìm thấy danh mục với Id đã cho
            }

            // Xóa danh mục khỏi cơ sở dữ liệu
            LMS_SWDContext.Ins.Categories.Remove(category);
            LMS_SWDContext.Ins.SaveChanges();
            return true; // Xóa thành công
        }

        public List<Category> GetCategories()
        {
            return LMS_SWDContext.Ins.Categories.ToList();
        }

        public bool VerifyBookInformation(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
