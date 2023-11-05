using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
            var contactMessages = _context.ContactMessages.ToList();
            return View(contactMessages);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = _context.ContactMessages.Find(id);

            if (message == null)
            {
                return NotFound();
            }

            _context.ContactMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
