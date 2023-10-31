using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Models
{
    public class PostCommentViewModel
    {
        public User User { get; set; }
        public PostComment Comment { get; set; }
    }
}
