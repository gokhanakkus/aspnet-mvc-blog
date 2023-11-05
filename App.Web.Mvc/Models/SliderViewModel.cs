namespace App.Web.Mvc.Models
{
    public class SliderViewModel
    {
        public string? Content { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }

        public int PostId { get; set; }
    }
}