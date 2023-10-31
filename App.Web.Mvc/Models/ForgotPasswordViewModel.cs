using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Email { get; set; }
    }
}
