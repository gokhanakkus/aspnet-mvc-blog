using App.Web.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class PostCRUDViewModel
    {
        [MaxLength(200)]
        [MinLength(1)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [MinLength(200)]
        [MaxLength(2000)]
        [Display(Name = "İçerik")]
        public string Content { get; set; }

        [Display(Name = "SliderMi?")]
        public bool IsSlider { get; set; }

        [Display(Name = "Kategoriler")]
        public List<Category>? Categories { get; set; }
        public int[]? CategoryIds { get; set; }
    }
}
