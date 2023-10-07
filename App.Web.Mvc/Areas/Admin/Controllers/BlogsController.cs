using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : BaseAdminController
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DeletedPost()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
