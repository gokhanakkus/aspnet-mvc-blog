using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
