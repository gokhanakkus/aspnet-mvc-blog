using Microsoft.AspNetCore.Mvc;
using App.Web.Mvc.Models;
using App.Web.Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderItem = await _context.Posts
                .Where(x => x.IsSlider && x.DeletedAt == null)
                .Select(x => new SliderViewModel
                {
                    Title = x.Title,
                    ImageUrl = x.Images.Any() ? x.Images.FirstOrDefault().ImagePath : null,
                    Date = x.CreatedAt,
                    PostId = x.Id,
                    Content = x.Content
                })
                .ToListAsync();

            return View(sliderItem);
        }
    }
}