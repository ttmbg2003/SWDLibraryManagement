using LMSEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSDAO.DAO
{
    public class SupplierDAO : ISupplierDAO
    {
        private readonly LMS_SWDContext _context;
        public SupplierDAO(LMS_SWDContext context)
        {
            _context = context;
        }

        public void AddSupplier(Supplier sup)
        {
            LMS_SWDContext.Ins.Suppliers.Add(sup);
            LMS_SWDContext.Ins.SaveChanges();
        }

        public void EditSupplier(Supplier sup)
        {
            var supplier = LMS_SWDContext.Ins.Suppliers.FirstOrDefault(x => x.Sid.Equals(sup.Sid));
            if (supplier != null)
            {
                LMS_SWDContext.Ins.Entry(supplier).CurrentValues.SetValues(sup);
            }
            LMS_SWDContext.Ins.SaveChanges();
        }

        public Supplier GetSupplier(string Sid)
        {
            return LMS_SWDContext.Ins.Suppliers.FirstOrDefault(x => x.Sid.Equals(Sid));
        }

        public List<Supplier> GetSuppliers()
        {
            return LMS_SWDContext.Ins.Suppliers.ToList();
        }

        public bool VerifySupplierInformation(string sup)
        {
            var s = LMS_SWDContext.Ins.Suppliers.FirstOrDefault(x=> x.Sid.Equals(sup));
            if(s != null)
            {
                return true;
            }
            return false;
        }
    }
}
