using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        private readonly AppDbContext _context;

        public PageController(AppDbContext context)
        {
            _context = context;
        }

        [Route("AboutMe")]
		public IActionResult Detail()
        {
            var page = _context.Pages.Include(p => p.PageImages).FirstOrDefault();
            
                var viewModel = new AboutMeViewModel
                {
                    Title = page.Title,
                    Content = page.Content,
                    WhoIsMe = page.WhoIsMe,
                    MyVision = page.MyVision,
                    PageImages = page.PageImages.ToList() 
                };
                return View(viewModel);
            
        }
    }
}
