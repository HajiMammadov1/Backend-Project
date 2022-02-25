using BackendProjectJuan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class PromotionBrandController : Controller
    {

        private readonly JuanContext _context;
        private readonly IWebHostEnvironment _env;
        public PromotionBrandController(JuanContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, bool? isDeleted = null)
        {
            ViewBag.IsDeleted = isDeleted;

            var promotionBrands = _context.PromotionBrands.AsQueryable();

            if (isDeleted != null)
                promotionBrands = promotionBrands.Where(x => x.IsDeleted == isDeleted);

            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = string.IsNullOrWhiteSpace(pageSizeStr) ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<PromotionBrand>.Create(_context.PromotionBrands.AsQueryable(), page, pageSize));

           
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
        public IActionResult Create(PromotionBrand promotionBrand)
        {
            if (promotionBrand.ImageFile == null)
                ModelState.AddModelError("ImageFile", "Image is required");

            if (!ModelState.IsValid)
                return View();

            if (promotionBrand.ImageFile.ContentType != "image/jpeg" && promotionBrand.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "File type must be jpeg or png");
                return View();
            }

            if (promotionBrand.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
                return View();
            }

            if (promotionBrand.ImageFile.FileName.Length > 64)
            {
                string oldName = promotionBrand.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                promotionBrand.Image = Guid.NewGuid().ToString() + newName;
            }

            else
            {
                promotionBrand.Image = Guid.NewGuid().ToString() + promotionBrand.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/promotionBrands", promotionBrand.Image);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                promotionBrand.ImageFile.CopyTo(stream);
            }

            promotionBrand.CreatedAt = DateTime.UtcNow.AddHours(4);
            _context.PromotionBrands.Add(promotionBrand);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            PromotionBrand promotionBrand = _context.PromotionBrands.FirstOrDefault(x => x.Id == id);

            if (promotionBrand == null)
                return RedirectToAction("error");

            return View(promotionBrand);
        }

        [HttpPost]
        public IActionResult Edit(PromotionBrand promotionBrand)
        {
            PromotionBrand existpromotionBrand = _context.PromotionBrands.FirstOrDefault(x => x.Id == promotionBrand.Id);

            if (existpromotionBrand == null)
                return RedirectToAction("index");

            if (promotionBrand.ImageFile.ContentType != "image/png" && promotionBrand.ImageFile.ContentType != "image/jpeg" && promotionBrand.ImageFile.ContentType != "image/jpg")
            {
                ModelState.AddModelError("ImageFile", "File type must be png or jpeg or jpg");
            }

            if (promotionBrand.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
            }

            if (promotionBrand.ImageFile.FileName.Length > 64)
            {
                string oldName = promotionBrand.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                promotionBrand.Image = Guid.NewGuid().ToString() + newName;
            }
            else
            {
                promotionBrand.Image = Guid.NewGuid().ToString() + promotionBrand.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/promotionBrands", promotionBrand.Image);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                promotionBrand.ImageFile.CopyTo(stream);
            }

            if (existpromotionBrand.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "uploads/promotionBrands", existpromotionBrand.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            existpromotionBrand.Image = promotionBrand.Image;

            if (promotionBrand.Image == null)
            {
                promotionBrand.Image = promotionBrand.Image;
            }

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            promotionBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);
            
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            PromotionBrand promotionBrand = _context.PromotionBrands.FirstOrDefault(x => x.Id == id);

            return View(promotionBrand);
        }

        [HttpPost]
        public IActionResult Delete(PromotionBrand promotionBrand)
        {
            PromotionBrand existPromotionBrand = _context.PromotionBrands.FirstOrDefault(X => X.Id == promotionBrand.Id);

            if (existPromotionBrand == null)
                return NotFound();

            //string oldPath = Path.Combine(_env.WebRootPath, "uploads/features", existPromotionBrand.Image);

            //if (System.IO.File.Exists(oldPath))
            //{
            //    System.IO.File.Delete(oldPath);
            //}

            //_context.PromotionBrands.Remove(existPromotionBrand);

            existPromotionBrand.IsDeleted = true;
            existPromotionBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Restore(int id)
        {
            PromotionBrand existPromotionBrand = _context.PromotionBrands.FirstOrDefault(x => x.Id == id && x.IsDeleted);

            if (existPromotionBrand == null)
                return NotFound();


            existPromotionBrand.IsDeleted = false;
            existPromotionBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
