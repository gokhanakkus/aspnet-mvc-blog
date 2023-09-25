using Microsoft.AspNetCore.Mvc;
using App.Web.Mvc.Models;
using App.Web.Mvc.Data;

namespace App.Web.Mvc.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var database = new DataBase();
            var sliderItem = database.SliderItems; 
            return View(sliderItem);
            
        }
    }
}