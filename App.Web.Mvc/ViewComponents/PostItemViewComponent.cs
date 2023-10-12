using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class PostItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AppDbContext context)
        {
            //var database = new DataBase();
            //var postItem = database.PostItem;
            var postItem = context.Posts;
            return View(postItem);

        }
    }
}
