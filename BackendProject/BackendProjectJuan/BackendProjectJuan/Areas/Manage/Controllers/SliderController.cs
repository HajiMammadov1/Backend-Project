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
    public class SliderController : Controller
    {
        private readonly JuanContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(JuanContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            string pageSizeStr = _context.Settings.FirstOrDefault(x => x.Key == "PageSize").Value;
            int pageSize = string.IsNullOrWhiteSpace(pageSizeStr) ? 3 : int.Parse(pageSizeStr);

            return View(PaginatedList<Slider>.Create(_context.Sliders.AsQueryable(), page, pageSize));
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
        public IActionResult Create(Slider slider)
        {
            if (slider.ImageFile == null)
                ModelState.AddModelError("ImageFile", "Image is required");

            if (!ModelState.IsValid)
                return View();

            if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpg")
            {
                ModelState.AddModelError("ImageFile", "File type must be jpeg or png");
                return View();
            }

            if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
                return View();
            }

            if (slider.ImageFile.FileName.Length > 64)
            {
                string oldName = slider.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                slider.Image = Guid.NewGuid().ToString() + newName;
            }

            else
            {
                slider.Image = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/sliders", slider.Image);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                slider.ImageFile.CopyTo(stream);
            }


            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null)
                return RedirectToAction("error");

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existSlider == null)
                return RedirectToAction("index");

            if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/jpg")
            {
                ModelState.AddModelError("ImageFile", "File type must be png or jpeg or jpg");
            }

            if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "File size must be less than 2 mb");
            }

            if (slider.ImageFile.FileName.Length > 64)
            {
                string oldName = slider.ImageFile.FileName;
                string newName = oldName.Substring(0, 64);

                slider.Image = Guid.NewGuid().ToString() + newName;
            }
            else
            {
                slider.Image = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
            }

            string path = Path.Combine(_env.WebRootPath, "uploads/sliders", slider.Image);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                slider.ImageFile.CopyTo(stream);
            }

            if (existSlider.Image != null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "uploads/sliders", existSlider.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            existSlider.Image = slider.Image;

            if (slider.Image == null)
            {
                slider.Image = existSlider.Image;
            }

            if (!ModelState.IsValid)
                return RedirectToAction("error");

            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.BtnText = slider.BtnText;
            existSlider.BtnUrl = slider.BtnUrl;
            existSlider.Desc = slider.Desc;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            return View(slider);
        }

        [HttpPost]
        public IActionResult Delete(Slider slider)
        {
            Slider existSlider = _context.Sliders.FirstOrDefault(X => X.Id == slider.Id);

            if (existSlider == null)
                return NotFound();

            string oldPath = Path.Combine(_env.WebRootPath, "uploads/sliders", existSlider.Image);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Sliders.Remove(existSlider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }



    }
}
