using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PostController : Controller
    {
		[Route("Icerik")]
		public IActionResult Index()
        {
            return View();
        }
    }
}
