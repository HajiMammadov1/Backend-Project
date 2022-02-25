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
    public class ReviewController : Controller
    {
        private readonly JuanContext _context;

        public ReviewController(JuanContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var comments = _context.ProductComments.Include(x => x.Product).Include(x => x.AppUser).AsQueryable();

            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<ProductComment>.Create(comments, page, pageSize));
        }

        public IActionResult Error()
        {
            return RedirectToAction("error");
        }

        public IActionResult ReadMore(int id)
        {
            ProductComment comment = _context.ProductComments.Include(x => x.Product).Include(x => x.AppUser).FirstOrDefault(x => x.Id == id);

            if (comment == null)
                return RedirectToAction("error");

            return View(comment);
        }

        [HttpPost]
        public IActionResult Delete(ProductComment comment)
        {
            ProductComment existComment = _context.ProductComments.FirstOrDefault(x => x.Id == comment.Id);

            if (existComment == null)
                return RedirectToAction("error");

            _context.ProductComments.Remove(existComment);

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
