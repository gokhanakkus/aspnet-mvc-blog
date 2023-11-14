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
    public class Category : BaseEntity
    {
        public int? ParentId { get; set; }

        [Required, MaxLength(100), Column(name: "Ad", TypeName = "nvarchar")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200), Column(name: "Açıklama", TypeName = "nvarchar")]
        public string? Description { get; set; }
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
