using BackendProjectJuan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly JuanContext _context;

        public OrderController(JuanContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).AsQueryable();

            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);
           
            return View(PaginatedList<Order>.Create(orders, page, pageSize));
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("error");

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (order.Id == 0)
            {
                ModelState.AddModelError("", "Error occurred");
                return View();
            }

            Order existOrder = _context.Orders.FirstOrDefault(x => x.Id == order.Id);

            if (order == null)
                return RedirectToAction("error");

            existOrder.Status = order.Status;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
