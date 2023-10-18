using System.ComponentModel.DataAnnotations;
using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class Auth
    {
        [EmailAddress, DataType(DataType.EmailAddress), Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Email { get; set; }

        [MaxLength(100), DataType(DataType.Password), Required(ErrorMessage = "{0} boş bırakılamaz!")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string? redirectUrl { get; set; }
        public User User { get; set; }
        
    }
}