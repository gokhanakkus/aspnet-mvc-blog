using App.Web.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your email address.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your message.")]
        public string Message { get; set; }
    }
}
