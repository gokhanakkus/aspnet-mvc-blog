using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
