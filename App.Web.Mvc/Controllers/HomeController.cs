using App.Web.Data.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var gonderi = _context.Posts.OrderByDescending(x => x.CreatedAt).First();
            var catid = _context.CategoryPosts.Where(x => x.PostId == gonderi.Id).First().CategoryId;
            var model = new HomeViewModel()
            {
                Post = gonderi,
                Category = _context.Categories.Find(catid),
                PostImage = _context.PostImages.Where(x => x.PostId == gonderi.Id).FirstOrDefault()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}