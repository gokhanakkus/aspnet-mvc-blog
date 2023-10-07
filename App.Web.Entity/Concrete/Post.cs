using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Entity.Concrete
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostThumbnailImage { get; set; }
        public string PostImage { get; set; }
        public DateTime PostCreateDate { get; set; }
        public bool PostStatus { get; set;}
    }
}
