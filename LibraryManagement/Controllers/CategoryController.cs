using Microsoft.AspNetCore.Mvc;
using LMSDAO.DAO;
using LMSEntity.Models;
using Microsoft.EntityFrameworkCore; // Namespace chứa lớp CategoryDAO

namespace AdminSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LMS_SWDContext _context;

        public CategoryController(LMS_SWDContext context)
        {
            _context = context;
        }

        // GET: Categoriess/ManageCategoryView
        public async Task<IActionResult> ManageCategoryView(string sortOrder, string sortBy)
        {
            var categories = from c in _context.Categories select c;

            // Kiểm tra trường sắp xếp
            if (sortBy == "Id")
            {
                // Sắp xếp ID theo thứ tự tăng dần hoặc giảm dần
                categories = (sortOrder == "desc") ? categories.OrderByDescending(c => Convert.ToInt32(c.Id)) : categories.OrderBy(c => Convert.ToInt32(c.Id));
            }
            else if (sortBy == "Cname")
            {
                // Sắp xếp theo tên Cname
                categories = (sortOrder == "desc") ? categories.OrderByDescending(c => c.Cname) : categories.OrderBy(c => c.Cname);
            }

            // Trả về view với danh sách đã sắp xếp
            return View(await categories.ToListAsync());
        }

        // GET: Category/AddCategory
        public IActionResult AddCategory()
        {
            return View();
        }

        // POST: Category/AddCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Category category)
        {
            // Kiểm tra xem CategoryName đã tồn tại hay chưa
            if (await _context.Categories.AnyAsync(c => c.Cname == category.Cname))
            {
                ModelState.AddModelError("Cname", "Category name already exists.");
                return View(category);
            }

            // Nếu không có lỗi, thêm Category mới vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();

                // Gửi thông báo thành công qua TempData
                TempData["SuccessMessage"] = "Category added successfully!";
                return RedirectToAction("ManageCategoryView");
            }

            return View(category);
        }

        // GET: Category/EditCategory/5
        public async Task<IActionResult> EditCategory(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/EditCategory/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(string id, [Bind("Id,Cname,Status")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ManageCategoryView));
            }
            return View(category);
        }

        // GET: Category/DeleteCategory/5
        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/DeleteCategory/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ManageCategoryView));
        }

        private bool CategoryExists(string id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
