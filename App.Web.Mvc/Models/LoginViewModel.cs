using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} cannot be empty!")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(100)]
        [Required(ErrorMessage = "{0} cannot be empty!")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string? redirectUrl { get; set; }
    }
}
