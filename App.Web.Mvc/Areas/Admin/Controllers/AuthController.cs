using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
