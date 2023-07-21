using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}