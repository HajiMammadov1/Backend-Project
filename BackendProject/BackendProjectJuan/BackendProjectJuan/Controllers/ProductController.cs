using BackendProjectJuan.Models;
using BackendProjectJuan.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Controllers
{
    public class ProductController : Controller
    {
        private readonly JuanContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(JuanContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.Brand).Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .FirstOrDefault(x => !x.IsDeleted && x.Id == id);

            if (product == null) return RedirectToAction("error","product");

            return PartialView("_ProductModalPartial", product);
        }
        public IActionResult Index(int? colorId, int? brandId, int? categoryId, int page = 1)
        {
            var products = _context.Products.Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.Brand).Include(x => x.ProductImages).Where(x => !x.IsDeleted);

            ViewBag.BrandId = brandId;
            ViewBag.CategoryId = categoryId;
            ViewBag.PageIndex = page;

            if (colorId != null)
                products = products.Where(x => x.Id == colorId);

            if (brandId != null)
                products = products.Where(x => x.BrandId == brandId);

            if (categoryId != null)
                products = products.Where(x => x.CategoryId == categoryId);

            ViewBag.TotalPages = (int)Math.Ceiling(products.Count() / 6d);

            ProductViewModel productVM = new ProductViewModel
            {
                Products = products.Skip((page - 1) * 6).Take(6).ToList(),
                Brands = _context.Brands.Include(x => x.Products).Where(x => !x.IsDeleted).ToList(),
                Colors = _context.Colors.Include(x => x.ProductColors).ThenInclude(x => x.Color).Where(x => !x.IsDeleted).ToList(),
                Categories = _context.Categories.Include(x => x.Products).Where(x => !x.IsDeleted).ToList(),    
                Settings = _context.Settings.ToList()
            };

            return View(productVM);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AddBasket(int id)
        {
            if (!_context.Products.Any(x => x.Id == id && !x.IsDeleted))
                return RedirectToAction("error", "product");

            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                string basketItemStr = HttpContext.Request.Cookies["basket"];
                List<BasketItemViewModel> items = new List<BasketItemViewModel>();

                if (!string.IsNullOrWhiteSpace(basketItemStr))
                    items = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemStr);

                BasketItemViewModel item = items.FirstOrDefault(x => x.ProductId == id);

                if (item == null)
                {
                    item = new BasketItemViewModel { ProductId = id, Count = 1 };
                    items.Add(item);
                }
                else
                    item.Count++;

               
                basketItemStr = JsonConvert.SerializeObject(items);

                HttpContext.Response.Cookies.Append("basket", basketItemStr);

                return PartialView("_BasketPartial", _getBasket(items));
            }
            else
            {
                BasketItem item = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                if (item == null)
                {
                    item = new BasketItem
                    {
                        AppUserId = member.Id,
                        ProductId = id,
                        Count = 1,
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };
                    _context.BasketItems.Add(item);
                }
                else
                    item.Count++;

                
                _context.SaveChanges();

                var items = _context.BasketItems.Where(x => x.AppUserId == member.Id).ToList();

                return PartialView("_BasketPartial", _getBasket(items));


            }
            
        }

        private BasketViewModel _getBasket(List<BasketItemViewModel> basketItems)
        {
            BasketViewModel basketVM = new BasketViewModel
            {
                BasketItems = new List<ProductBasketItemViewModel>(),
                TotalPrice = 0
            };

            foreach (var item in basketItems)
            {
                Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                ProductBasketItemViewModel bookBasketItem = new ProductBasketItemViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                basketVM.BasketItems.Add(bookBasketItem);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                basketVM.TotalPrice += totalPrice * item.Count;

            }

            return basketVM;
        }

        private BasketViewModel _getBasket(List<BasketItem> basketItems)
        {
            BasketViewModel basketVM = new BasketViewModel
            {
                BasketItems = new List<ProductBasketItemViewModel>(),
                TotalPrice = 0
            };

            foreach (var item in basketItems)
            {
                Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                ProductBasketItemViewModel bookBasketItem = new ProductBasketItemViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                basketVM.BasketItems.Add(bookBasketItem);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                basketVM.TotalPrice += totalPrice * item.Count;

            }

            return basketVM;
        }
        public IActionResult DeleteBasket(int id)
        {
            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                string basketItemsStr = HttpContext.Request.Cookies["basket"];
                List<BasketItemViewModel> items = new List<BasketItemViewModel>();

                if (!string.IsNullOrWhiteSpace(basketItemsStr))
                    items = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(basketItemsStr);

                BasketItemViewModel item = items.FirstOrDefault(x => x.ProductId == id);

                items.Remove(item);

                basketItemsStr = JsonConvert.SerializeObject(items);

                HttpContext.Response.Cookies.Append("basket", basketItemsStr);

                return RedirectToAction("index", "home");
            }
            else
            {
                BasketItem item = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                _context.BasketItems.Remove(item);

                _context.SaveChanges();

                return RedirectToAction("index", "home");
            }
            

        }

        public IActionResult Detail(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.Brand).Include(x => x.Category)
                .Include(x => x.ProductComments).ThenInclude(x => x.AppUser)
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (product == null)
                return RedirectToAction("error");

            ProductDetailvViewModel productVM = new ProductDetailvViewModel
            {
                Product = product,
                Comment = new ProductComment {ProductId = id },
                RelatedProducts = _context.Products.Include(x => x.ProductImages).Where(x => x.CategoryId == product.CategoryId).Take(4).ToList()
            };

            return View(productVM);
        }

        public IActionResult Comment(ProductComment comment)
        {
            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
                return RedirectToAction("login", "account");

            Product product = _context.Products.Include(x => x.ProductImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.Brand).Include(x => x.Category)
                .Include(x => x.ProductComments).ThenInclude(x => x.AppUser)
                .FirstOrDefault(x => x.Id == comment.ProductId && !x.IsDeleted);


            if (product == null)
                return RedirectToAction("error");

            if (!ModelState.IsValid)
            {
                ProductDetailvViewModel productVM = new ProductDetailvViewModel
                {
                    Product = product,
                    Comment = comment,
                    RelatedProducts = _context.Products.Include(x => x.ProductImages).Where(x => x.CategoryId == product.CategoryId).Take(4).ToList()
                };

                return View("Detail", productVM);
            }

            
            comment.AppUserId = member.Id;
            comment.CreatedAt = DateTime.UtcNow.AddHours(4);

            product.ProductComments.Add(comment);
            product.Rate = (int)Math.Ceiling(product.ProductComments.Sum(x => x.Rate) / (double)product.ProductComments.Count);

            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = comment.ProductId });
            
        }

        


    }
}
