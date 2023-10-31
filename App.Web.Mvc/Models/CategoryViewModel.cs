using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class CategoryViewModel
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string CategoryId { get; set; }
        //public string CategoryName { get; set; }
        //public string CategoryDescription { get; set; }
        public Category? Category { get; set; }
        public List<HomeViewModel>? Post { get; set; }

    }
}