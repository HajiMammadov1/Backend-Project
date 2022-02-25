using BackendProjectJuan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CategoryController : Controller
    {
        private readonly JuanContext _context;

        public CategoryController(JuanContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, bool? isDeleted = null)
        {
            ViewBag.IsDeleted = isDeleted;

            var categories = _context.Categories.AsQueryable();

            if (isDeleted != null)
                categories = categories.Where(x => x.IsDeleted == isDeleted);


            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Category>.Create(categories, page, pageSize));


        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category categories)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("error");

            categories.CreatedAt = DateTime.UtcNow.AddHours(4);

            _context.Categories.Add(categories);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (category == null)
                return RedirectToAction("error");

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id && !x.IsDeleted);

            if (existCategory == null)
                return RedirectToAction("error");

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existCategory.Name = category.Name;
            existCategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id && !x.IsDeleted);

            if (existCategory == null)
                return RedirectToAction("error");

            //_context.Categories.Remove(existBrand);

            existCategory.IsDeleted = true;

            existCategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Restore(int id)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id && x.IsDeleted);

            if (existCategory == null)
                return NotFound();


            existCategory.IsDeleted = false;
            existCategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
