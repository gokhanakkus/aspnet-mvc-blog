using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeletedMedia()
        {
            return View();
        }
    }
}
