using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace App.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Search([FromQuery] string q)
        //{
        //    List<int> Ids = (
        //        from CategoryPosts in _context.CategoryPosts
        //        where CategoryPosts.Category.Name.Contains(q) || CategoryPosts.Post.Content.Contains(q) || CategoryPosts.Post.Title.Contains(q)
        //        select CategoryPosts.PostId
        //        ).ToList();
        //    List<SearchViewModel> Results = new List<SearchViewModel>();
        //    List<Post> posts = new List<Post>();
        //    foreach (int i in Ids)
        //    {
        //        if (posts.Where(c => c.Id == i).FirstOrDefault() is null)
        //        {
        //            posts.Add(_context.Posts.Where(c => c.Id == i).FirstOrDefault());
        //            Results.Add(new SearchViewModel()
        //            {
        //                Post = _context.Posts.Where(c => c.Id == i).FirstOrDefault(),
        //                Category = _context.Categories.Find(_context.CategoryPosts.Where(c => c.PostId == i).FirstOrDefault().CategoryId),
        //                PostImage = _context.PostImages.Where(x => x.PostId == i).FirstOrDefault()
        //            });
        //        }
        //    }
        //    return View(Results);
        //}
        [HttpGet]
        public IActionResult Search([FromQuery] string q)
        {
            List<int> Ids = (
                from CategoryPosts in _context.CategoryPosts
                where (CategoryPosts.Category.Name.Contains(q) ||
                       CategoryPosts.Post.Content.Contains(q) ||
                       CategoryPosts.Post.Title.Contains(q)) &&
                       CategoryPosts.Post.DeletedAt == null
                select CategoryPosts.PostId
            ).ToList();

            List<SearchViewModel> Results = new List<SearchViewModel>();
            List<Post> posts = new List<Post>();

            foreach (int i in Ids)
            {
                if (posts.Where(c => c.Id == i).FirstOrDefault() is null)
                {
                    posts.Add(_context.Posts
                        .Where(c => c.Id == i && c.DeletedAt == null)
                        .FirstOrDefault());

                    Results.Add(new SearchViewModel()
                    {
                        Post = _context.Posts
                            .Where(c => c.Id == i && c.DeletedAt == null)
                            .FirstOrDefault(),
                        Category = _context.Categories
                            .Find(_context.CategoryPosts
                                .Where(c => c.PostId == i && _context.Posts.Find(i).DeletedAt == null)
                                .FirstOrDefault()
                                ?.CategoryId),
                        PostImage = _context.PostImages
                            .Where(x => x.PostId == i)
                            .FirstOrDefault()
                    });
                }
            }

            return View(Results);
        }



        //[Route("Blog")] //hatalı geçici olarak yazıldı.CategoryPosts yerine category olacak.
        //public IActionResult Detail(int id)
        //{
        //    var post = _context.Posts.Include(p => p.CategoryPosts).Include(p => p.Images).FirstOrDefault(p => p.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        var detail = new DetailViewModel
        //        {
        //            Post = post,
        //            Category = post.CategoryPosts,
        //            PostImage = post.Images
        //        };

        //        return View(detail);
        //    }
        //}

        [HttpGet]
        public IActionResult Detail([FromRoute] int id, [FromRoute] string title)
        {
            Post? post = _context.Posts.Where(c => c.Id == id).FirstOrDefault();
            if (post == null)
            {
                return NotFound();
            }
            List<PostCommentViewModel> list = new List<PostCommentViewModel>();
            foreach (var item in _context.PostComments.Where(x => x.PostId == post.Id && x.IsActive).OrderBy(x => x.CreatedAt).ToList())
            {
                var comview = new PostCommentViewModel()
                {
                    Comment = item,
                    User = _context.Users.Where(x => x.Id == item.UserId).FirstOrDefault()
                };
                list.Add(comview);
            }
            var model = new BlogDetailViewModel()
            {
                Post = post,
                PostCategory = _context.Categories.Find(_context.CategoryPosts.Where(x => x.PostId == post.Id).First().CategoryId),
                PostImage = _context.PostImages.Where(x => x.PostId == post.Id).FirstOrDefault(),
                PostComments = list,
                PostComment = null
            };
            if (title != UrlFriend.SeoName(post.Title))
            {
                return RedirectToAction("Detail", new { id = id, title = UrlFriend.SeoName(post.Title) });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Detail(BlogDetailViewModel collection, string Name, string Email, string Message, [FromRoute] int id, [FromRoute] string title)
        {
            Post post = _context.Posts.Where(c => c.Id == id).FirstOrDefault();
            if (title != UrlFriend.SeoName(post.Title))
            {
                return RedirectToAction("Detail", new { id = id, title = UrlFriend.SeoName(post.Title) });
            }
            List<PostCommentViewModel> list = new List<PostCommentViewModel>();
            foreach (var item in _context.PostComments.Where(x => x.PostId == post.Id && x.IsActive).OrderBy(x => x.CreatedAt).ToList())
            {
                var comview = new PostCommentViewModel()
                {
                    Comment = item,
                    User = _context.Users.Where(x => x.Id == item.UserId).FirstOrDefault()
                };
                list.Add(comview);
            }
            var model = new BlogDetailViewModel()
            {
                Post = post,
                PostCategory = _context.Categories.Find(_context.CategoryPosts.Where(x => x.PostId == post.Id).First().CategoryId),
                PostImage = _context.PostImages.Where(x => x.PostId == post.Id).FirstOrDefault(),
                PostComments = list,
                PostComment = null
            };
            if (Email is not null)
            {

                var kontrol = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
                if (kontrol is not null)
                {
                    var comment = new PostComment();
                    comment.UserId = kontrol.Id;
                    comment.Comment = Message;
                    comment.CreatedAt = DateTime.UtcNow;
                    comment.IsActive = true;
                    comment.PostId = post.Id;
                    _context.PostComments.Add(comment);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Detail));
                }
                else
                {
                    var user = new User();
                    user.Name = Name;
                    user.Email = Email;
                    user.CreatedAt = DateTime.UtcNow;
                    user.Password = "1234";
                    user.RoleId = 3;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                var user1 = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
                var comment1 = new PostComment();
                comment1.UserId = user1.Id;
                comment1.Comment = Message;
                comment1.CreatedAt = DateTime.UtcNow;
                comment1.IsActive = false;
                comment1.PostId = post.Id;
                _context.PostComments.Add(comment1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Detail));
            }
            var comment2 = new PostComment();
            if (HttpContext.Session.GetString("UserId") == null)
            {
                ViewBag.Message = "Lutfen mail ve ismi bos bırakmadan mesaj yaziniz!!!";
                return View(model);
            }
            var userMail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var user2 = _context.Users.Where(x => x.Email == userMail).First();
            comment2.UserId = user2.Id;
            comment2.Comment = Message;
            comment2.CreatedAt = DateTime.UtcNow;
            comment2.IsActive = true;
            comment2.PostId = post.Id;
            _context.PostComments.Add(comment2);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detail));
        }
    }
}
