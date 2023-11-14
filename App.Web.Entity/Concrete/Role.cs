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
    public class Role : BaseEntity
    {
        [Required, MinLength(1), MaxLength(100), Column(name: "Role", TypeName = "nvarchar")]
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
