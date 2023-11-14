using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ModeratorPolicy")]
    public class AdminContactController : Controller
    {
        private readonly AppDbContext _context;

        public AdminContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contactMessages = _context.ContactMessages.Where(x => x.DeletedAt == null).ToList();
            return View(contactMessages);
        }

        public IActionResult DeletedMessages()
        {
            var deletedMessages = _context.ContactMessages.Where(x => x.DeletedAt != null).ToList();
            return View(deletedMessages);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = _context.ContactMessages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            message.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var message = _context.ContactMessages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            message.DeletedAt = null;
            _context.SaveChanges();

            return RedirectToAction("DeletedMessages");
        }

        [HttpPost]
        public IActionResult PermanentlyDelete(int id)
        {
            var message = _context.ContactMessages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            _context.ContactMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("DeletedMessages");
        }

    }
}