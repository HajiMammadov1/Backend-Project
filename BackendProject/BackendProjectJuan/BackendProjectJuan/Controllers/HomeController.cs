
using BackendProjectJuan.Models;
using BackendProjectJuan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Controllers
{
    public class HomeController : Controller
    {
        private readonly JuanContext _context;
        public HomeController(JuanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                Features = _context.Features.ToList(),
                Settings = _context.Settings.ToList(),
                Products = _context.Products.Include(x => x.Brand).Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.ProductImages).Where(x => !x.IsDeleted).ToList(),
                PromotionBrands = _context.PromotionBrands.Where(x => !x.IsDeleted).ToList(),
                TopSeller = _context.Products.Include(x => x.Brand)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.ProductImages).Where(x => !x.IsDeleted && x.DiscountPercent > 50).Take(4).ToList()
            };
            return View(homeVM);
        }

        public async Task<IActionResult> Send()
        {
            var message = "<a href='www.microsof.com'>Click</a>";

            //await EmailUtil.SendEmailAsync("hajiam@code.edu.az", "test", message);

            return RedirectToAction("Index");
        }

        

        
    }
}
