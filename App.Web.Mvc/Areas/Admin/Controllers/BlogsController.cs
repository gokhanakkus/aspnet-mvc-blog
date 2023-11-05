using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ModeratorPolicy")]
    public class BlogsController : BaseAdminController
    {
        private readonly AppDbContext _context;

        public BlogsController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var userMail = User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            var model = _context.Posts.ToList();
            var kullanici = _context.Users.Where(x => x.Email == userMail).FirstOrDefault();
            if (kullanici.RoleId == 2)
            {
                var modelmod = _context.Posts.Where(x => x.UserId == kullanici.Id).ToList();
                return View(modelmod);
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new PostCRUDViewModel();
            List<int> ids = new List<int>();
            model.Categories = _context.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCRUDViewModel collection)
        {
            try
            {
                var post = new Post();
                var UserMail = User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
                var user = _context.Users.Where(x => x.Email == UserMail).FirstOrDefault();
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Lütfen girdileri kontrol ediniz!");
                //}
                //else
                //{
                    post.Title = collection.Title;
                    post.Content = collection.Content;
                    post.IsSlider = collection.IsSlider;
                    post.CreatedAt = DateTime.UtcNow;
                    post.UserId = user.Id;
                    _context.Posts.Add(post);
                    _context.SaveChanges();
                    if (collection.CategoryIds is not null)
                    {
                        foreach (var item in collection.CategoryIds)
                        {
                            var categorypost = new CategoryPost();
                            categorypost.CategoryId = item;
                            categorypost.PostId = post.Id;
                            _context.Add(categorypost);
                        }
                        _context.SaveChanges();
                    }
                    return RedirectToAction(nameof(Index));
                //}


            }
            catch
            {

            }
            collection.Categories = _context.Categories.ToList();
            return View(collection);
        }

        public ActionResult Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var post = _context.Posts.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            var model = new PostCRUDViewModel();
            model.IsSlider = post.IsSlider;
            model.Content = post.Content;
            model.Title = post.Title;
            model.Categories = _context.Categories.ToList();
            List<int> ids = _context.CategoryPosts.Where(x => x.PostId == id.Value).Select(x => x.CategoryId).ToList();
            model.CategoryIds = ids.ToArray();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, PostCRUDViewModel collection)
        {
            try
            {
                var post = _context.Posts.Find(id);
                if (post == null)
                {
                    return NotFound();
                }
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Lütfen girdileri kontrol ediniz!");
                //}
                //else
                //{
                    post.Title = collection.Title;
                    post.Content = collection.Content;
                    post.IsSlider = collection.IsSlider;
                    post.UpdatedAt = DateTime.UtcNow;
                    _context.Posts.Update(post);

                    List<int> ids = _context.CategoryPosts.Where(x => x.PostId == id).Select(x => x.Id).ToList();
                    foreach (var item in ids)
                    {
                        _context.CategoryPosts.Remove(_context.CategoryPosts.Find(item));
                    }
                    _context.SaveChanges();
                    if (collection.CategoryIds is not null)
                    {
                        foreach (var item in collection.CategoryIds)
                        {
                            var categorypost = new CategoryPost();
                            categorypost.CategoryId = item;
                            categorypost.PostId = post.Id;
                            _context.Add(categorypost);
                        }
                        _context.SaveChanges();
                    }
                    return RedirectToAction(nameof(Index));
                //}


            }
            catch
            {

            }
            collection.Categories = _context.Categories.ToList();
            return View(collection);
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var post = _context.Posts.Find(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            var model = new PostCRUDViewModel();
            model.IsSlider = post.IsSlider;
            model.Content = post.Content;
            model.Title = post.Title;
            model.Categories = _context.Categories.ToList();
            List<int> ids = _context.CategoryPosts.Where(x => x.PostId == id.Value).Select(x => x.CategoryId).ToList();
            model.CategoryIds = ids.ToArray();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostCRUDViewModel collection)
        {
            try
            {
                var post = _context.Posts.Find(id);
                if (post == null)
                {
                    return NotFound();
                }
                post.DeletedAt = DateTime.UtcNow;
                _context.Posts.Update(post);

                List<int> ids = _context.CategoryPosts.Where(x => x.PostId == id).Select(x => x.Id).ToList();
                foreach (var item in ids)
                {
                    _context.CategoryPosts.Remove(_context.CategoryPosts.Find(item));
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));



            }
            catch
            {

            }
            collection.Categories = _context.Categories.ToList();
            return View(collection);
        }
    }
}
