using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMSEntity.Models;

namespace AdminSite.Controllers
{
    public class BooksController : Controller
    {
        private readonly LMS_SWDContext _context;

        public BooksController(LMS_SWDContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> ManageBookView()
        {
            var lMS_SWDContext = _context.Books.Include(b => b.CidNavigation);
            return View(await lMS_SWDContext.ToListAsync());
        }

        

        public IActionResult AddBook()
        {
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Cname");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook([Bind("BookId,Cid,Bname,Author,Quantity,QuantityInStock,TotalPage,CoverPrice,Description,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageBookView));
            }
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", book.Cid);
            return View(book);
        }

        public async Task<IActionResult> EditBook(string id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "CName", book.Cid);
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(string id, [Bind("BookId,Cid,Bname,Author,Quantity,QuantityInStock,TotalPage,CoverPrice,Description,Status")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificationBookÌnormation(book.Bname))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageBookView));
            }
            ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Cname", book.Cid);
            return View(book);
        }
        private bool VerificationBookÌnormation(string name)
        {
          return (_context.Books?.Any(e => e.Bname == name)).GetValueOrDefault();
        }
    }
}
