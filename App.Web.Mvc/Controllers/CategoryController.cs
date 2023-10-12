using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Travel(int id, int page)
        {
            return View();
        }
        public IActionResult Weekends(int id, int page)
        {
            return View();
        }
        public IActionResult Lifestyle(int id, int page)
        {
            return View();
        }
        public IActionResult Explore(int id, int page)
        {
            return View();
        }
        public IActionResult Health(int id, int page)
        {
            return View();
        }
    }
}
