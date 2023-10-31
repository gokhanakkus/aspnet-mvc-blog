using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index([FromRoute] int id, [FromRoute] string title)
        {
            List<int> Ids = (
                from CategoryPost in _context.CategoryPosts
                where CategoryPost.CategoryId == id
                select CategoryPost.PostId
                ).ToList();
            List<int> uniqueids = Ids.ToArray().Distinct().ToList();
            List<Post> posts = new List<Post>();
            List<HomeViewModel> modelnews = new List<HomeViewModel>();
            foreach (int i in uniqueids)
            {

                var homeview = new HomeViewModel()
                {
                    Category = _context.Categories.Find(id),
                    Post = _context.Posts.Where(x => x.Id == i).FirstOrDefault(),
                    PostImage = _context.PostImages.Where(x => x.PostId == i).FirstOrDefault()
                };
                modelnews.Add(homeview);


            }
            var model = new CategoryViewModel()
            {
                Category = _context.Categories.Where(c => c.Id == id).FirstOrDefault(),
                Post = modelnews
            };
            if (title != UrlFriend.SeoName(model.Category.Name))
            {
                return RedirectToAction("Index", new { id = id, title = UrlFriend.SeoName(model.Category.Name) });
            }
            return View(model);
        }
    }
}
