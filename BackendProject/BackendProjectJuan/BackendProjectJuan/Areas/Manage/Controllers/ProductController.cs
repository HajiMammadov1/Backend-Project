using BackendProjectJuan.Helpers;
using BackendProjectJuan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class ProductController : Controller
    {
        private readonly JuanContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(JuanContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, bool? isDeleted = null)
        {
            ViewBag.IsDeleted = isDeleted;

            var products = _context.Products.Include(x => x.Brand).Include(x => x.ProductImages)
                .Include(x => x.Category).Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .AsQueryable();

            if (isDeleted != null)
                products = products.Where(x => x.IsDeleted == isDeleted);

            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Product>.Create(products, page, pageSize));
        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult Create()
        {
            ViewBag.Colors = _context.Colors.Where(x => !x.IsDeleted).ToList();
            ViewBag.Brands = _context.Brands.Where(x => !x.IsDeleted).ToList();
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Colors = _context.Colors.Where(x => !x.IsDeleted).ToList();
            ViewBag.Brands = _context.Brands.Where(x => !x.IsDeleted).ToList();
            ViewBag.Category = _context.Categories.Where(x => !x.IsDeleted).ToList();

            if (!ModelState.IsValid)
                return View();

            if (product.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image file is required");
            }
            else
            {
                if (product.ImageFile.ContentType != "image/jpeg" && product.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Photo must be in png or jpeg format");
                    return View();
                }

                if (product.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Photo sizze must be less than 2 mb");
                    return View();
                }
            }

            if (!_context.Brands.Any(x => x.Id == product.BrandId && !x.IsDeleted))
            {
                ModelState.AddModelError("BrandId", "Brand is not found");
            }

            if (!_context.Categories.Any(x => x.Id == product.CategoryId && !x.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Category is not found");
            }

            product.ProductImages = new List<ProductImage>();
            product.ProductColors = new List<ProductColor>();

            if (product.ColorIds != null)
            {
                foreach (var colorId in product.ColorIds)
                {
                    if (_context.Colors.Any(x => x.Id == colorId))
                    {
                        ProductColor productColor = new ProductColor
                        {
                            ColorId = colorId
                        };
                        product.ProductColors.Add(productColor);
                    }
                    else
                    {
                        ModelState.AddModelError("ColorIds", "Color  is not found");
                    }
                }
            }

            ProductImage productImage = new ProductImage
            {
                PosterStatus = true,
                Image = FileManager.Save(_env.WebRootPath, "uploads/products", product.ImageFile)
            };
            product.ProductImages.Add(productImage);

            product.CreatedAt = DateTime.UtcNow.AddHours(4);

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).Include(x => x.ProductColors).Include(x => x.Brand).Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            ViewBag.Brands = _context.Brands.Where(x => !x.IsDeleted).ToList();
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
            ViewBag.Colors = _context.Colors.ToList();

            product.ColorIds = product.ProductColors.Select(x => x.ColorId).ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            Product existProduct = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == product.Id);

            if (existProduct == null) return NotFound();

            if (!_context.Brands.Any(x => x.Id == product.BrandId && !x.IsDeleted))
            {
                ModelState.AddModelError("BrandId", "Brand is not found");
            }

            if (!_context.Categories.Any(x => x.Id == product.CategoryId && !x.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "CAtegory is not found");
            }

            if (product.ImageFile != null && product.ImageFile.ContentType != "image/png" && product.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Photo must be in png or jpeg format");
                return View();
            }

            if (product.ImageFile != null && product.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Photo size must be less than 2 mb");
                return View();
            }

            ProductImage poster = existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

            if (product.ImageFile != null)
            {
                string newPosterImg = FileManager.Save(_env.WebRootPath, "uploads/products", product.ImageFile);

                if (poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/products", poster.Image);
                    poster.Image = newPosterImg;
                }
                else
                {
                    poster = new ProductImage { Image = newPosterImg, PosterStatus = true };
                    existProduct.ProductImages.Add(poster);
                }
            }

            if (product.ColorIds != null)
            {
                foreach (var colorId in product.ColorIds)
                {
                    var currentColor = _context.ProductColors.Where(x => x.ProductId == product.Id).FirstOrDefault(x => x.ColorId == colorId);

                    if (currentColor == null)
                    {
                        ProductColor productColor = new ProductColor
                        {
                            ProductId = product.Id,
                            ColorId = colorId
                        };
                        _context.ProductColors.Add(productColor);
                    }
                    else
                    {
                        _context.ProductColors.Where(x => x.ProductId == product.Id).ToList().Remove(currentColor);
                    }
                }
            }

            _context.ProductColors.RemoveRange(_context.ProductColors.Where(x => x.ProductId == product.Id).ToList());

            existProduct.Name = product.Name;
            existProduct.Desc = product.Desc;
            existProduct.BrandId = product.BrandId;
            existProduct.CategoryId = product.CategoryId;
            existProduct.CostPrice = product.CostPrice;
            existProduct.SalePrice = product.SalePrice;
            existProduct.DiscountPercent = product.DiscountPercent;
            existProduct.Rate = product.Rate;
            existProduct.IsAvailable = product.IsAvailable;
            existProduct.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Product existProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id && !x.IsDeleted);

            if (existProduct == null)
                return RedirectToAction("error");

            existProduct.IsDeleted = true;
            existProduct.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Restore(int id)
        {
            Product existProduct = _context.Products.FirstOrDefault(x => x.Id == id && x.IsDeleted);

            if (existProduct == null)
                return NotFound();


            existProduct.IsDeleted = false;
            existProduct.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
