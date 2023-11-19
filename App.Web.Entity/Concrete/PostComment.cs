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
    public class PostComment : BaseAuditEntity
    {
        public int PostId { get; set; }

        public virtual Post? Post { get; set; }

        public int UserId { get; set; }

        public virtual User? User { get; set; }

        [Column(name: "Comment", TypeName = "text")]
        public string? Comment { get; set; }

        [Column(name: "Active?", TypeName = "bit")]
        public bool IsActive { get; set; }

    }
}
