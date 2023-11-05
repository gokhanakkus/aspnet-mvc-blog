using App.Web.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Entity.Concrete
{
    public class User : BaseAuditEntity
    {

        [Required, MaxLength(200), Column(TypeName = "nvarchar"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password), Column(name: "Şifre", TypeName = "nvarchar")]
        public string Password { get; set; }

        [Required, MaxLength(100), Column(name: "Ad", TypeName = "nvarchar")]
        public string Name { get; set; }

        [MaxLength(100), Column(name: "Şehir", TypeName = "nvarchar")]
        public string? City { get; set; }

        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }
    }

}
