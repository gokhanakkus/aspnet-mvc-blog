using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class BlogDetailViewModel
    {
        public List<PostCommentViewModel>? PostComments { get; set; }
        public Post Post { get; set; }
        public Category PostCategory { get; set; }
        public PostImage? PostImage { get; set; }
        public PostComment? PostComment { get; set; }
    }
}
