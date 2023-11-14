using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class UsersController : BaseAdminController
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
  
        public ActionResult Index()
        {
            var model = _context.Users.ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_context.Roles.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            try
            {             
                    if (_context.Users.Any(x => x.Email == collection.Email))
                    {
                        ModelState.AddModelError("", "Bu Emailde kullanıcı var.");
                    }
                    else
                    {
                        User user = new();
                        user.Name = collection.Name;
                        user.Email = collection.Email;
                        user.Password = collection.Password;
                        user.City = collection.City;
                        user.RoleId = collection.RoleId;
                        user.CreatedAt = DateTime.UtcNow;
                        _context.Users.Add(user);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
            }
            catch
            {

            }
            ViewBag.RoleId = new SelectList(_context.Roles.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.Users.Find(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.RoleId = new SelectList(_context.Roles.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, User collection)
        {
            try
            {         
                    if (_context.Users.Where(x => x.Id == collection.Id).FirstOrDefault().Email != collection.Email && _context.Users.Any(x => x.Email == collection.Email))
                    {
                        ModelState.AddModelError("", "Bu Emailde kullanıcı var.");
                    }
                    else
                    {
                        User user = _context.Users.Find(collection.Id);
                        user.Name = collection.Name;
                        user.Email = collection.Email;
                        user.Password = collection.Password;
                        user.City = collection.City;
                        user.RoleId = collection.RoleId;
                        user.UpdatedAt = DateTime.UtcNow;
                        _context.Users.Update(user);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
            }
            catch
            {

            }
            ViewBag.RoleId = new SelectList(_context.Roles.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.Users.Find(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                User user = _context.Users.Find(collection.Id);
                user.DeletedAt = DateTime.UtcNow;
                _context.Users.Update(user);
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
