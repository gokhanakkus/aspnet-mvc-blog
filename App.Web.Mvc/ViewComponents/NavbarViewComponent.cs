using App.Web.Data.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public NavbarViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new NavBarViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }
    }
}