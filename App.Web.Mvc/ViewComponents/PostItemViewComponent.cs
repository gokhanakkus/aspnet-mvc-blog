﻿using App.Web.Data.Concrete;
using App.Web.Entity.Concrete;
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
            var postItems = await _context.Posts
                .Include(x => x.Images)
                .Where(x => x.DeletedAt == null)
                .ToListAsync();

            var models = postItems.Select(x => new PostItemViewModel
            {
                Title = x.Title,
                Name = x.Content,
                Date = x.CreatedAt,
                PostId = x.Id,
                ImageUrl = x.Images.FirstOrDefault()?.ImagePath
            }).ToList();

            return View(models);
        }
    }
}
