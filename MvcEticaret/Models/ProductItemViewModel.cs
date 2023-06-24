using Microsoft.AspNetCore.Mvc;

namespace MvcEticaret.Models;

public class ProductItemViewModel
{
    public string? Title { get; set; }
    public int StarCount { get; set; }
    public decimal OldPrice { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsSale { get; set; }

}

