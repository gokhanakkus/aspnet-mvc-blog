using App.Web.Data.Concrete;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.ViewComponents
{
    public class PostItemViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public PostItemViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var database = new DataBase();
            //var postItem = database.PostItem;
            var postItems = await _context.Posts
                .Include(x => x.Images)
                .ToListAsync();

            var models = postItems.Select(x => new PostItemViewModel
            {
                Title = x.Title,
                Name = x.Content,
                Date = x.CreatedAt,
                ImageUrl = x.Images.FirstOrDefault()?.ImagePath
            }).ToList();

            return View(models);

        }
    }
}
