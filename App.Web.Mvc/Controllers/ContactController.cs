using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class ContactController : Controller
    {
		//[Route("Iletisim")]
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // İletişim formunu gösteren eylem
        public IActionResult Index()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        // İletişim formundan verileri alacak ve işleyecek eylem
        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            //if (ModelState.IsValid)
            //{
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
                    //return RedirectToAction("Error");
                }
            //}

            return View(model);
        }

        // İletişim formunun gönderildikten sonra teşekkür sayfası
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
