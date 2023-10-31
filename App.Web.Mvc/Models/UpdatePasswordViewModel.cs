using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class UpdatePasswordViewModel
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
