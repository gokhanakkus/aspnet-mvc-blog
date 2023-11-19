using App.Web.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class PostCRUDViewModel
    {
        [MaxLength(200)]
        [MinLength(1)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [MinLength(200)]
        [MaxLength(2000)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "IsSlider?")]
        public bool IsSlider { get; set; }

        [Display(Name = "Categories")]
        public List<Category>? Categories { get; set; }
        public int[]? CategoryIds { get; set; }
    }
}
