using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ModeratorPolicy")]
    public class AdminAboutMeController : Controller
    {
        private readonly AppDbContext _context;

        public AdminAboutMeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var page = _context.Pages.Include(p => p.PageImages).FirstOrDefault();
            return View(page);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var page = _context.Pages.FirstOrDefault();
            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Page page)
        {

            var existingPage = _context.Pages.FirstOrDefault(); 

            if (existingPage != null)
            {
              
                existingPage.Title = page.Title;
                existingPage.Content = page.Content;
                existingPage.WhoIsMe = page.WhoIsMe;
                existingPage.MyVision = page.MyVision;

                
                _context.Update(existingPage);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Düzenlenen sayfa bulunamadı.");
            }

            return View(page);
        }

        //[HttpGet]
        //public ActionResult CreateImage()
        //{
        //    ViewBag.PageId = new SelectList(_context.Pages, "Id", "Title");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateImage(PageImage collection, IFormFile ImageFile)
        //{
            
        //        if (ImageFile != null && ImageFile.Length > 0)
        //        {
        //            var image = new PageImage();
        //            image.PageId = collection.PageId;
        //            image.FileName = await FileController.FileLoaderAsync(ImageFile);

        //            _context.PageImages.Add(image);
        //            _context.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Lütfen bir resim seçin.");
        //        }

        //    ViewBag.PageId = new SelectList(_context.Pages, "Id", "Title");

        //    return View(collection);
        //}


        [HttpGet]
        public IActionResult UpdateImage()
        {

            var image = _context.PageImages.FirstOrDefault();
            if (image == null)
            {
                return NotFound();
            }

            ViewBag.PageId = new SelectList(_context.Pages.ToList(), "Id", "Title");
            return View(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage( PageImage collection, IFormFile ImageFile)
        {

            var image = _context.PageImages.FirstOrDefault();
            if (image == null)
            {
                return NotFound();
            }

            try
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    image.FileName = await FileController.FileLoaderAsync(ImageFile);
                }
                image.PageId = collection.PageId;

                _context.PageImages.Update(image);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               
            }

            ViewBag.PageId = new SelectList(_context.Pages.ToList(), "Id", "Title");
            return View(collection);
        }

    }
}
