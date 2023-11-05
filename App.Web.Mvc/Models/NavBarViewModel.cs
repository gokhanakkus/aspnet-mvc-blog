using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class NavBarViewModel
    {
        public ICollection<Category>? Categories { get; set; }
    }
}
