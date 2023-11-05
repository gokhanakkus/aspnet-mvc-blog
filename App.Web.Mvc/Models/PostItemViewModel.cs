using App.Web.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Web.Mvc.Models
{
    public class PostItemViewModel
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}