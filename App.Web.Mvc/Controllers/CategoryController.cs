﻿using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        [Route("kategori")]
        public IActionResult Index(int id, int page)
        {
            return View();
        }
    }
}
