using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO {
    public class BorrowInformationDAO : IBorrowInformationDAO {
        public void InsertNewBorrow(List<string> bookCopyIds, string rid) {
            List<BookCopy> bookCopies = LMS_SWDContext.Ins.BookCopies.Where(bc => bookCopyIds.Contains(bc.Id)).ToList();
        }
    }
}
