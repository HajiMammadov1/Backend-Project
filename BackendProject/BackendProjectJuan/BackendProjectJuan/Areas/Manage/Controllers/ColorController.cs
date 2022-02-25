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
    public class ColorController : Controller
    {
        private readonly JuanContext _context;

        public ColorController(JuanContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, bool? isDeleted = null)
        {
            ViewBag.IsDeleted = isDeleted;

            var colors = _context.Colors.AsQueryable();

            if (isDeleted != null)
                colors = colors.Where(x => x.IsDeleted == isDeleted);


            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Color>.Create(colors, page, pageSize));


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
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("error");

            color.CreatedAt = DateTime.UtcNow.AddHours(4);

            _context.Colors.Add(color);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Color color = _context.Colors.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (color == null)
                return RedirectToAction("error");

            return View(color);
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            Color existColor = _context.Colors.FirstOrDefault(x => x.Id == color.Id && !x.IsDeleted);

            if (existColor == null)
                return RedirectToAction("error");

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existColor.Name = color.Name;
            existColor.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Color color = _context.Colors.FirstOrDefault(x => x.Id == id);

            return View(color);
        }

        [HttpPost]
        public IActionResult Delete(Color color)
        {
            Color existColor = _context.Colors.FirstOrDefault(x => x.Id == color.Id && !x.IsDeleted);

            if (existColor == null)
                return RedirectToAction("error");

            //_context.Colors.Remove(existBrand);

            existColor.IsDeleted = true;

            existColor.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Restore(int id)
        {
            Color existColor = _context.Colors.FirstOrDefault(x => x.Id == id && x.IsDeleted);

            if (existColor == null)
                return NotFound();


            existColor.IsDeleted = false;
            existColor.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
