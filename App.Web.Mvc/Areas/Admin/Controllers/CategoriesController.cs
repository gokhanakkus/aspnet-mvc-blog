using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Policy = "AdminPolicy")]
	public class CategoriesController : Controller
    {
		private readonly AppDbContext _context;

		public CategoriesController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			var model = _context.Categories.ToList();
			return View(model);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			ViewBag.ParentId = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category collection)
		{
			try
			{
					Category category = new();
					category.Name = collection.Name;
					category.Description = collection.Description;
					category.ParentId = collection.ParentId;
					_context.Categories.Add(category);
					_context.SaveChanges();

					return RedirectToAction(nameof(Index));
			}
			catch
			{
			}
			ViewBag.ParentId = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View(collection);
		}

		public ActionResult Update(int? id)
		{
			if (id is null)
			{
				return BadRequest();
			}
			var model = _context.Categories.Find(id.Value);
			if (model == null)
			{
				return NotFound();
			}
			ViewBag.ParentId = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(int id, Category collection)
		{
			try
			{
					Category category = _context.Categories.Find(collection.Id);
					category.Name = collection.Name;
					category.Description = collection.Description;
					category.ParentId = collection.ParentId;
					_context.Categories.Update(category);
					_context.SaveChanges();

					return RedirectToAction(nameof(Index));
			}
			catch
			{

			}
			ViewBag.ParentId = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View(collection);
		}

		public ActionResult Delete(int? id)
		{
			if (id is null)
			{
				return BadRequest();
			}
			var model = _context.Categories.Find(id.Value);
			if (model == null)
			{
				return NotFound();
			}
			ViewBag.ParentId = new SelectList(_context.Categories.ToList(), "Id", "Name");
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Category collection)
		{
			try
			{
				Category category = _context.Categories.Find(collection.Id);
				_context.Categories.Remove(category);
				_context.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
