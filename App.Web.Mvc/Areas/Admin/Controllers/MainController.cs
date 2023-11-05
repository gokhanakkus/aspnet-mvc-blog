using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ModeratorPolicy")]
	public class MainController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
