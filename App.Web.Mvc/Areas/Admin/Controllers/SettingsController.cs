using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
