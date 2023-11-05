using App.Web.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Adınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesajınızı giriniz.")]
        public string Message { get; set; }
    }
}
