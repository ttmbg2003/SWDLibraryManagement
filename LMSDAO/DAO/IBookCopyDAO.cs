using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    public interface IBookCopyDAO
    {
        public void AddBookCopy(BookCopy bookCopy);
    }
}
