using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using MvcEticaret.Models;

namespace MvcEticaret.ViewComponents 
{
    public class ProductItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, int starCount, double oldPrice, double price, string imageUrl, bool isSale)
        {
            var product = new Product()
            {
                Title = title,
                Price = price,
                ImageUrl = imageUrl,
                IsSale = isSale,
                OldPrice = oldPrice,
                StarCount = starCount
            };

            return View(product);
        }
    }
}



