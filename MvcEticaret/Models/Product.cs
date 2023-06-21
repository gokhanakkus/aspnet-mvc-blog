using Microsoft.AspNetCore.Mvc;

namespace MvcEticaret.Models;

public class Product
{
    public string Title { get; set; }
    public int StarCount { get; set; }
    public double OldPrice { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public bool IsSale { get; set; }

}

