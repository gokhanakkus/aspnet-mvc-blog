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
    public class PostImage : BaseEntity
    {
        [Required]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post? Post { get; set; }

        [MaxLength(600), Column(name: "Resim", TypeName = "nvarchar")]
        public string? ImagePath { get; set; }
    }
    //public class PostImage
    //{
    //    public int Id { get; set; }
    //    public int PostId { get; set; }
    //    public Post Post { get; set; }
    //    public string ImagePath { get; set; }
    //}
}