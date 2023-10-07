using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : BaseAdminController
    { 
        public IActionResult Index()
        {
            return View();
        }
 
    }
}
