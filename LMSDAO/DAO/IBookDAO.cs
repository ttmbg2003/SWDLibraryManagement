using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    public interface IBookDAO
    {
        public List<Book> GetBooks();
        public void AddBook(Book book);
        public void EditBook(Book book);
        public bool VerifyBookInformation(Book book);
    }
}
