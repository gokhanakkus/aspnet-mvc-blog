using Microsoft.AspNetCore.Mvc;
using MvcEticaret.Models;
using System.Collections.Generic;

namespace MvcEticaret.Controllers 
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var products = new List<ProductItemViewModel>();
            
            products.Add(new ProductItemViewModel() { Title = "Fender American Professional II Stratocaster", IsSale = true, OldPrice = 3500, StarCount = 5, ImageUrl = "/images/fender1.jpg", Price = 3000 });
            products.Add(new ProductItemViewModel() { Title = "Jackson Corey Beaulieu Artist Serisi USA KV7 Abanoz", IsSale = false, OldPrice = 8000, StarCount = 2, ImageUrl = "/images/fender2.jpg", Price = 7500 });
            products.Add(new ProductItemViewModel() { Title = "EVH Wolfgang USA Abanoz", IsSale = true, OldPrice = 2900, StarCount = 3, ImageUrl = "/images/evhwolfgang.jpg", Price = 2500 });
            products.Add(new ProductItemViewModel() { Title = "Music Man 618-J2-50-00-MB-BM John Petrucci Majesty 7", IsSale = false, OldPrice = 8500, StarCount = 0, ImageUrl = "/images/musicman.jpg", Price = 7050 });
            products.Add(new ProductItemViewModel() { Title = "Gibson 1959 Les Paul Standard Reissue VOS Dirty Lemon", IsSale = false, OldPrice = 11000, StarCount = 2, ImageUrl = "/images/lespaul.jpg", Price = 10500 });
            products.Add(new ProductItemViewModel() { Title = "Fender Custom Shop W21 Limited Edition 1960 Telecaster Custom Heavy Relic", IsSale = true, OldPrice = 13000, StarCount = 5, ImageUrl = "/images/fender3.png", Price = 11000 });
            products.Add(new ProductItemViewModel() { Title = "Gibson 1958 Les Paul Standard Reissue VOS Bourbon Burst", IsSale = false, OldPrice = 30000, StarCount = 0, ImageUrl = "/images/gibson.jpg", Price = 25000 });
            products.Add(new ProductItemViewModel() { Title = "Gibson Les Paul Custom Ebony Klavye Gloss Ebony", IsSale = true, OldPrice = 32000, StarCount = 5, ImageUrl = "/images/gibson2.jpg", Price = 30000 });
            
            return View(products);
        }

    }

}



