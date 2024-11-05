using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    internal class BookCopyDAO : IBookCopyDAO
    {
        public void AddBookCopy(BookCopy bookCopy)
        {
            LMS_SWDContext.Ins.BookCopies.Add(bookCopy);
            LMS_SWDContext.Ins.SaveChanges();
        }
    }
}
