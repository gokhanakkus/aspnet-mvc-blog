using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : BaseAdminController
    {
        public IActionResult Profile()
        {
            return View();
        } 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }

    }
}
