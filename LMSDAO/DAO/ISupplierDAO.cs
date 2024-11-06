using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    public interface ISupplierDAO
    {
        public List<Supplier> GetSuppliers();
        public Supplier GetSupplier(string Sid);
        public void AddSupplier(Supplier sup);
        public void EditSupplier(Supplier sup);
        public bool VerifySupplierInformation(string sup);
    }
}
