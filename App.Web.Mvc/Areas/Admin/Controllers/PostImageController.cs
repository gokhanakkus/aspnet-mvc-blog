using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Policy = "ModeratorPolicy")]
	public class PostImageController : Controller
	{
		private readonly AppDbContext _context;

		public PostImageController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			var model = _context.PostImages.Include("Post").ToList();
			return View(model);
		}

		public ActionResult Detail(int id)
		{
			var model = _context.PostImages.Include("Post").Where(x => x.PostId == id).ToList();
			return View(model);
		}

		// GET: NewsImageController/Create
		public ActionResult Create()
		{
			ViewBag.PostId = new SelectList(_context.Posts.ToList(), "Id", "Title");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PostImage collection, IFormFile ImagePath)
		{
			try
			{
				var image = new PostImage();
				image.PostId = collection.PostId;
				image.ImagePath = await FileController.FileLoaderAsync(ImagePath);
				_context.PostImages.Add(image);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{

			}
			ViewBag.PostId = new SelectList(_context.Posts.ToList(), "Id", "Title");
			return View(collection);
		}

		public ActionResult Update(int? id)
		{
			if (id is null)
			{
				return BadRequest();
			}
			var model = _context.PostImages.Find(id.Value);
			if (model == null)
			{
				return NotFound();
			}
			ViewBag.PostId = new SelectList(_context.Posts.ToList(), "Id", "Title");
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Update(int id, PostImage collection, IFormFile ImagePath)
		{
			try
			{
				var image = _context.PostImages.Find(id);
				if (image == null)
				{
					return NotFound();
				}
				if (ImagePath is not null)
				{
					image.ImagePath = await FileController.FileLoaderAsync(ImagePath);
				}
				image.PostId = collection.PostId;
				_context.PostImages.Update(image);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{

			}
			ViewBag.PostId = new SelectList(_context.Posts.ToList(), "Id", "Title");
			return View(collection);
		}


		public ActionResult Delete(int? id)
		{
			if (id is null)
			{
				return BadRequest();
			}
			var model = _context.PostImages.Include("Post").Where(x => x.Id == id.Value).FirstOrDefault();
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, PostImage collection)
		{
			try
			{
				var image = _context.PostImages.Find(id);
				if (image == null)
				{
					return NotFound();
				}
				_context.PostImages.Remove(image);
				FileController.FileRemover(collection.ImagePath);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{

			}
			return View(collection);
		}
	}
}
