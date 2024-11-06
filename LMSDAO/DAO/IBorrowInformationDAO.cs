using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO {
    public interface IBorrowInformationDAO {
        public void InsertNewBorrow(List<string> bookCopyIds, string rid);
    }
}
