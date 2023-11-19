using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var kullanici = _context.Users.FirstOrDefault(x => x.Email == userMail);

            if (kullanici != null && kullanici.RoleId == 2)
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
                var userMail = User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
                var user = _context.Users.FirstOrDefault(x => x.Email == userMail);

                post.Title = collection.Title;
                post.Content = collection.Content;
                post.IsSlider = collection.IsSlider;
                post.CreatedAt = DateTime.UtcNow;
                post.UserId = user.Id;
                _context.Posts.Add(post);
                _context.SaveChanges();

                if (collection.CategoryIds != null && collection.CategoryIds.Any())
                {
                    foreach (var categoryId in collection.CategoryIds)
                    {
                        var categoryPost = new CategoryPost
                        {
                            CategoryId = categoryId,
                            PostId = post.Id
                        };
                        _context.Add(categoryPost);
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
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

            var model = new PostCRUDViewModel
            {
                IsSlider = post.IsSlider,
                Content = post.Content,
                Title = post.Title,
                Categories = _context.Categories.ToList(),
                CategoryIds = _context.CategoryPosts.Where(x => x.PostId == id.Value).Select(x => x.CategoryId).ToArray()
            };

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

                post.Title = collection.Title;
                post.Content = collection.Content;
                post.IsSlider = collection.IsSlider;
                post.UpdatedAt = DateTime.UtcNow;
                _context.Posts.Update(post);

                var existingCategoryIds = _context.CategoryPosts
                    .Where(x => x.PostId == id)
                    .Select(x => x.Id)
                    .ToList();

                foreach (var categoryId in existingCategoryIds)
                {
                    _context.CategoryPosts.Remove(_context.CategoryPosts.Find(categoryId));
                }

                _context.SaveChanges();

                if (collection.CategoryIds != null && collection.CategoryIds.Any())
                {
                    foreach (var categoryId in collection.CategoryIds)
                    {
                        var categoryPost = new CategoryPost
                        {
                            CategoryId = categoryId,
                            PostId = post.Id
                        };
                        _context.Add(categoryPost);
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
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

            var model = new PostCRUDViewModel
            {
                IsSlider = post.IsSlider,
                Content = post.Content,
                Title = post.Title,
                Categories = _context.Categories.ToList(),
                CategoryIds = _context.CategoryPosts.Where(x => x.PostId == id.Value).Select(x => x.CategoryId).ToArray()
            };

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

                var existingCategoryIds = _context.CategoryPosts
                    .Where(x => x.PostId == id)
                    .Select(x => x.Id)
                    .ToList();

                foreach (var categoryId in existingCategoryIds)
                {
                    _context.CategoryPosts.Remove(_context.CategoryPosts.Find(categoryId));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PermanentlyDelete(int id)
        {
            try
            {
                var postCommentIds = _context.PostComments
                    .Where(pc => pc.PostId == id)
                    .Select(pc => pc.Id)
                    .ToList();

                foreach (var postCommentId in postCommentIds)
                {
                    var postComment = _context.PostComments.Find(postCommentId);
                    _context.PostComments.Remove(postComment);
                }
                _context.SaveChanges();

                var post = _context.Posts.Find(id);

                if (post != null && post.DeletedAt != null)
                {
                    var relatedImagesBefore = _context.PostImages.Where(pi => pi.PostId == id).ToList();
                    Console.WriteLine($"Related Images Before Deletion: {relatedImagesBefore.Count}");

                    var relatedImages = _context.PostImages.Where(pi => pi.PostId == id).ToList();
                    _context.PostImages.RemoveRange(relatedImages);

                    var relatedImagesAfter = _context.PostImages.Where(pi => pi.PostId == id).ToList();
                    Console.WriteLine($"Related Images After Deletion: {relatedImagesAfter.Count}");

                    _context.Posts.Remove(post);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(DeletedPosts));
            }
            catch (Exception ex)
            {
                
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult DeletedPosts()
        {
            var deletedPosts = _context.Posts.Where(x => x.DeletedAt != null).ToList();
            return View(deletedPosts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restore(int id)
        {
            var post = _context.Posts.Find(id);

            if (post != null && post.DeletedAt != null)
            {
                post.DeletedAt = null;
                _context.Posts.Update(post);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(DeletedPosts));
        }
    }
}
