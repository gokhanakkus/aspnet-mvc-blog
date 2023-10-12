using Microsoft.AspNetCore.Mvc;
using App.Web.Mvc.Models;
using App.Web.Data.Concrete;

namespace App.Web.Mvc.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AppDbContext context)
        {
            //var database = new DataBase();
            //var sliderItem = database.SliderItems;
            var sliderItem = context.SliderItems; 
            return View(sliderItem);
            
        }
    }
}