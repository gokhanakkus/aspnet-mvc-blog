using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        // GET: BlogsController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: BlogsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
