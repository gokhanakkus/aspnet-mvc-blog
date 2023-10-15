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
            //var database = new DataBase();
            //var sliderItem = database.SliderItems;
            var sliderItem = await _context.SliderItems
                .Select(x => new SliderViewModel
                {
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Date = x.Date,
                    Name = x.Name
                })
                .ToListAsync(); 
            return View(sliderItem);
            
        }
    }
}