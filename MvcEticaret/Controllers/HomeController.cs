using Microsoft.AspNetCore.Mvc;
using MvcEticaret.Models;
using System.Collections.Generic;

namespace MvcEticaret.Controllers 
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var products = new List<Product>();

            products.Add(new Product() { Title = "Ürün 1", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 2", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 3", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 4", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 5", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 6", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });
            products.Add(new Product() { Title = "Ürün 7", IsSale = true, OldPrice = 30, StarCount = 3, ImageUrl = "", Price = 50 });

            return View(products);
        }

    }

}



