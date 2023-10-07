using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : BaseAdminController
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DeletedCategory()
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
