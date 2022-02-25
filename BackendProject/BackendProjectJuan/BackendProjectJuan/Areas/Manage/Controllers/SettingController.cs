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
    public class SettingController : Controller
    {
        private readonly JuanContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(JuanContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {

            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = pageSizeStr == null ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Setting>.Create(_context.Settings.AsQueryable(), page, pageSize));

            
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
        public IActionResult Create(Setting setting)
        {
            if (!ModelState.IsValid)
                return View();

            if (setting.ImageFile != null)
            {
                if (setting.ImageFile.ContentType != "image/jpeg" && setting.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "File type must be jpeg or png");
                    return View();
                }

                if (setting.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
                    return View();
                }

                if (setting.ImageFile.FileName.Length > 64)
                {
                    string oldName = setting.ImageFile.FileName;
                    string newName = oldName.Substring(0, 64);

                    setting.Value = Guid.NewGuid().ToString() + newName;
                }

                else
                {
                    setting.Value = Guid.NewGuid().ToString() + setting.ImageFile.FileName;
                }

                string path = Path.Combine(_env.WebRootPath, "uploads/settings", setting.Value);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.ImageFile.CopyTo(stream);
                }
            }

            _context.Settings.Add(setting);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);

            if (setting == null)
                return RedirectToAction("error");

            return View(setting);

        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);

            if (existSetting == null)
                return RedirectToAction("index");

            if (setting.ImageFile != null)
            {
                if (setting.ImageFile.ContentType != "image/png" && setting.ImageFile.ContentType != "image/jpeg" && setting.ImageFile.ContentType != "image/jpg")
                {
                    ModelState.AddModelError("ImageFile", "File type must be png or jpeg or jpg");
                }

                if (setting.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
                }

                if (setting.ImageFile.FileName.Length > 64)
                {
                    string oldName = setting.ImageFile.FileName;
                    string newName = oldName.Substring(0, 64);

                    setting.Value = Guid.NewGuid().ToString() + newName;
                }
                else
                {
                    setting.Value = Guid.NewGuid().ToString() + setting.ImageFile.FileName;
                }

                string path = Path.Combine(_env.WebRootPath, "uploads/settings", setting.Value);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.ImageFile.CopyTo(stream);
                }

                if (existSetting.Value != null)
                {
                    string oldPath = Path.Combine(_env.WebRootPath, "uploads/settings", existSetting.Value);

                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                existSetting.Value = setting.Value;
            }

            if (setting.Value == null)
            {
                setting.Value = existSetting.Value;
            }

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existSetting.Key = setting.Key;
            existSetting.Value = setting.Value;
           
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);

            return View(setting);
        }

        [HttpPost]
        public IActionResult Delete(Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(X => X.Id == setting.Id);

            if (existSetting == null)
                return NotFound();

            string oldPath = Path.Combine(_env.WebRootPath, "uploads/settings", existSetting.Value);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Settings.Remove(existSetting);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


    }
}
