using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "ModeratorPolicy")]
    public class PostCommentController : Controller
    {
        private readonly AppDbContext _context;

        public PostCommentController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = _context.PostComments.Include(x => x.User).Include(x => x.Post).OrderBy(x => x.Id).ToList();
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var model = _context.PostComments.Include(x => x.User).Include(x => x.Post).Where(x => x.PostId == id).ToList();
            return View(model);
        }

        public ActionResult Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.PostComments.Include(x => x.User).Include(x => x.Post).Where(x => x.Id == id.Value).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, PostComment collection)
        {
            try
            {
                var yorum = _context.PostComments.Find(id);
                if (yorum == null)
                {
                    return NotFound();
                }
                
                yorum.UpdatedAt = DateTime.UtcNow;
                yorum.IsActive = collection.IsActive;
                _context.PostComments.Update(yorum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                

            }
            catch
            {

            }
            return View(collection);
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _context.PostComments.Include(x => x.User).Include(x => x.Post).Where(x => x.Id == id.Value).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostComment collection)
        {
            try
            {
                var yorum = _context.PostComments.Find(id);
                if (yorum == null)
                {
                    return NotFound();
                }
                yorum.DeletedAt = DateTime.UtcNow;
                yorum.IsActive = false;
                _context.PostComments.Update(yorum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(collection);
            }
        }
    }
}
