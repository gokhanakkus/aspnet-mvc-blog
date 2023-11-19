using App.Web.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Entity.Concrete
{
    public class Post : BaseAuditEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [MaxLength(200), Column(name: "Title", TypeName = "nvarchar")]
        public string Title { get; set; }

        [MinLength(200), MaxLength(4000), Column(name: "Content", TypeName = "nvarchar")]
        public string Content { get; set; }
        public bool IsSlider { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
        public virtual ICollection<PostImage> Images { get; set; }    
    }

}
