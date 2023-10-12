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
    public class PostComment : BaseAuiditEntity
    {
        [Required]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post? Post { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }

        [Column(name: "Yorum", TypeName = "text")]
        public string? Comment { get; set; }

        [Column(name: "Aktif?", TypeName = "bit")]
        public bool IsActive { get; set; }

    }
    //public class PostComment
    //{
    //    public int Id { get; set; }
    //    public int PostId { get; set; }
    //    public Post Post { get; set; }
    //    public int UserId { get; set; }
    //    public User User { get; set; }
    //    public string Comment { get; set; }
    //    public bool IsActive { get; set; }
    //}
}
