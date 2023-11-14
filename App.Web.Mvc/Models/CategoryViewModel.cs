using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class CategoryViewModel
    {
        public Category? Category { get; set; }
        public List<HomeViewModel>? Post { get; set; }
    }
}