using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(100)]
        [Required(ErrorMessage = "{0} boş bırakılamaz!")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string? redirectUrl { get; set; }
    }
}
