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

        [MaxLength(200), Column(name: "Başlık", TypeName = "nvarchar")]
        public string Title { get; set; }

        [MinLength(200), MaxLength(2000), Column(name: "İçerik", TypeName = "nvarchar")]
        public string Content { get; set; }
        public bool IsSlider { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
        public virtual ICollection<PostImage> Images { get; set; }
    }
    //public class Post
    //{
    //    public int Id { get; set; }
    //    public int UserId { get; set; }
    //    public User User { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }
    //    public List<CategoryPost> CategoryPosts { get; set; }
    //    public List<PostImage> Images { get; set; }
    //    public List<PostComment> Comments { get; set; }
    //}
}
