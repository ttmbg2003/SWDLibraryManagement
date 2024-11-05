using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    internal class BookDAO : IBookDAO
    {
        public void AddBook(Book book)
        {
            LMS_SWDContext.Ins.Books.Add(book);
            LMS_SWDContext.Ins.SaveChanges();
        }

        public void EditBook(Book book)
        {
            LMS_SWDContext.Ins.Books.Update(book);
            LMS_SWDContext.Ins.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return LMS_SWDContext.Ins.Books.ToList();

        }

        public bool VerifyBookInformation(Book book)
        {
            var b = LMS_SWDContext.Ins.Books.FirstOrDefault(x=>x.Bname==book.Bname);
            if(b != null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
