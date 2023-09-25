using App.Web.Mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class PostItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var database = new DataBase();
            var postItem = database.PostItem;
            return View(postItem);

        }
    }
}
