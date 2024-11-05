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
        public List<Category> GetCategories()
        {
            return LMS_SWDContext.Ins.Categories.ToList();
        }
    }
}
