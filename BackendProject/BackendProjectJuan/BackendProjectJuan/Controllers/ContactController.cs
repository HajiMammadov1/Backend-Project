using BackendProjectJuan.Models;
using BackendProjectJuan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly JuanContext _context;
        public ContactController(JuanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Settings = _context.Settings.ToList()
            };
            return View(homeVM);
        }
    }
}
