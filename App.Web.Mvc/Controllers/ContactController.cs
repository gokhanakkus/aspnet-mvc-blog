using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class ContactController : Controller
    {
		[Route("Iletisim")]
		public IActionResult Index()
        {
            return View();
        }
    }
}
