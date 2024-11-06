using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSEntity.Models;
using LMSDAO.DAO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace AdminSite.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierDAO supDao;

        public SuppliersController(ISupplierDAO SupplierDAO)
        {
            supDao = SupplierDAO;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
              return supDao.GetSuppliers() != null ? 
                          View(supDao.GetSuppliers()) :
                          Problem("Entity set 'LMS_SWDContext.Suppliers'  is null.");
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(supDao.GetSupplier(id));
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,Name,Email,Phone,Address")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supDao.AddSupplier(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = supDao.GetSupplier(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Sid,Name,Email,Phone,Address")] Supplier supplier)
        {
            if (id != supplier.Sid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    supDao.EditSupplier(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return null;
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            return null;
        }

        private bool SupplierExists(string id)
        {
          return supDao.VerifySupplierInformation(id);
        }
    }
}
