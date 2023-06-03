using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    
    public class BaseAdminController : Controller
    {
        [Area("Admin")]
        public IActionResult BaseAdminIndex()
        {
            return View();
        }
    }
}
