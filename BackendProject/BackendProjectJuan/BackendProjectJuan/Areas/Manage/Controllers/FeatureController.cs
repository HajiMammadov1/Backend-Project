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
    public class FeatureController : Controller
    {

        private readonly JuanContext _context;
        private readonly IWebHostEnvironment _env;
        public FeatureController(JuanContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = string.IsNullOrWhiteSpace(pageSizeStr) ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Feature>.Create(_context.Features.AsQueryable(), page, pageSize));

           
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
        public IActionResult Create(Feature feature)
        {
            if (feature.ImageFile == null)
                ModelState.AddModelError("ImageFile", "Image is required");

            if (!ModelState.IsValid)
                return View();

            if (feature.ImageFile.ContentType != "image/jpeg" && feature.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "File type must be jpeg or png");
                return View();
            }

            if (feature.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
                return View();
            }

            if (feature.ImageFile.FileName.Length > 64)
            {
                string oldName = feature.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                feature.Icon = Guid.NewGuid().ToString() + newName;
            }

            else
            {
                feature.Icon = Guid.NewGuid().ToString() + feature.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/features", feature.Icon);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                feature.ImageFile.CopyTo(stream);
            }


            _context.Features.Add(feature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);

            if (feature == null)
                return RedirectToAction("error");

            return View(feature);
        }

        [HttpPost]
        public IActionResult Edit(Feature feature)
        {
            Feature existFeature = _context.Features.FirstOrDefault(x => x.Id == feature.Id);

            if (existFeature == null)
                return RedirectToAction("index");

            if (feature.ImageFile.ContentType != "image/png" && feature.ImageFile.ContentType != "image/jpeg" && feature.ImageFile.ContentType != "image/jpg")
            {
                ModelState.AddModelError("ImageFile", "File type must be png or jpeg or jpg");
            }

            if (feature.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
            }

            if (feature.ImageFile.FileName.Length > 64)
            {
                string oldName = feature.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                feature.Icon = Guid.NewGuid().ToString() + newName;
            }
            else
            {
                feature.Icon = Guid.NewGuid().ToString() + feature.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/features", feature.Icon);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                feature.ImageFile.CopyTo(stream);
            }

            if (existFeature.Icon != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "uploads/features", existFeature.Icon);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            existFeature.Icon = feature.Icon;

            if (feature.Icon == null)
            {
                feature.Icon = existFeature.Icon;
            }

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existFeature.Title = feature.Title;
            existFeature.Desc = feature.Desc;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);

            return View(feature);
        }

        [HttpPost]
        public IActionResult Delete(Feature feature)
        {
            Feature existFeature = _context.Features.FirstOrDefault(X => X.Id == feature.Id);

            if (existFeature == null)
                return NotFound();

            string oldPath = Path.Combine(_env.WebRootPath, "uploads/features", existFeature.Icon);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Features.Remove(existFeature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
