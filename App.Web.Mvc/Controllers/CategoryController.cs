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
            List<int> postIdsInCategory = _context.CategoryPosts
                .Where(categoryPost => categoryPost.CategoryId == id)
                .Select(categoryPost => categoryPost.PostId)
                .Where(postId => _context.Posts.Any(post => post.Id == postId && post.DeletedAt == null))
                .ToList();

            List<HomeViewModel> modelPost = postIdsInCategory
                .Select(postId => new HomeViewModel
                {
                    Category = _context.Categories.Find(id),
                    Post = _context.Posts
                        .Where(post => post.Id == postId && post.DeletedAt == null) 
                        .FirstOrDefault(),
                    PostImage = _context.PostImages.Where(image => image.PostId == postId).FirstOrDefault()
                })
                .ToList();

            var model = new CategoryViewModel
            {
                Category = _context.Categories.Find(id),
                Post = modelPost
            };

            if (title != UrlFriend.SeoName(model.Category.Name))
            {
                return RedirectToAction("Index", new { id = id, title = UrlFriend.SeoName(model.Category.Name) });
            }

            return View(model);
        }
    }
}
