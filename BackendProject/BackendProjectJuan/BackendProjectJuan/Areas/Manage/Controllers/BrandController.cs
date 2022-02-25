using BackendProjectJuan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BrandController : Controller
    {
        private readonly JuanContext _context;

        public BrandController(JuanContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, bool? isDeleted = null)
        {
            ViewBag.IsDeleted = isDeleted;

            var brands = _context.Brands.Include(x => x.Products).AsQueryable();

            if (isDeleted != null)
                brands = brands.Where(x => x.IsDeleted == isDeleted);


            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 6 : int.Parse(pageSizeStr);

            return View(PaginatedList<Brand>.Create(brands, page, pageSize));


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
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("error");

            brand.CreatedAt = DateTime.UtcNow.AddHours(4);

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (brand == null)
                return RedirectToAction("error");

            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id && !x.IsDeleted);

            if (existBrand == null)
                return RedirectToAction("error");

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existBrand.Name = brand.Name;
            existBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id && !x.IsDeleted);

            if (existBrand == null)
                return RedirectToAction("error");

            //_context.Brands.Remove(existBrand);

            existBrand.IsDeleted = true;

            existBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Restore(int id)
        {
            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == id && x.IsDeleted);

            if (existBrand == null)
                return NotFound();


            existBrand.IsDeleted = false;
            existBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
