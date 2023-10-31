using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class HomeViewModel
    {
        public Category Category { get; set; }
        public Post? Post { get; set; }
        public PostImage? PostImage { get; set; }
    }
}
