using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
		[Route("Detay")]// page detail sayfasına route ile detay yazdım(task6)
		public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
