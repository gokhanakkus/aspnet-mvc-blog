using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
                try
                {
                    var contactMessage = new ContactMessage
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Message = model.Message
                    };

                    _context.ContactMessages.Add(contactMessage);
                    _context.SaveChanges();

                    return RedirectToAction("ThankYou");
                }
                catch (Exception ex)
                {
                   
                }
            
            return View(model);
        }

        // İletişim formunun gönderildikten sonra teşekkür sayfası
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
