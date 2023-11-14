using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;

        public SettingsController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = _context.Settings.ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.Users.ToList(), "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Settings collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Hatalı girdiler var. Lütfen kontrol ediniz.");
                }
                else
                {
                    Settings setting = new();
                    setting.Name = collection.Name;
                    setting.Value = collection.Value;
                    setting.UserId = collection.UserId;
                    setting.CreatedAt = DateTime.UtcNow;
                    _context.Settings.Add(setting);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            ViewBag.UserId = new SelectList(_context.Users.ToList(), "Id", "Email");
            return View();
        }

        public ActionResult Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.Settings.Find(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.UserId = new SelectList(_context.Users.ToList(), "Id", "Email");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, Settings collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Hatalı girdiler var. Lütfen kontrol ediniz.");
                }
                else
                {
                    Settings setting = _context.Settings.Find(collection.Id);
                    setting.Name = collection.Name;
                    setting.Value = collection.Value;
                    setting.UserId = collection.UserId;
                    setting.UpdatedAt = DateTime.UtcNow;
                    _context.Settings.Update(setting);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            ViewBag.UserId = new SelectList(_context.Users.ToList(), "Id", "Email");
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.Settings.Find(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Settings collection)
        {
            try
            {
                Settings setting = _context.Settings.Find(collection.Id);
                setting.DeletedAt = DateTime.UtcNow;
                _context.Settings.Update(setting);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
