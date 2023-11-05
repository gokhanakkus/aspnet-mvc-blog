using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Entity.Abstract
{
    public abstract class BaseAuditEntity : BaseEntity, IAuiditEntity
    {
        [Required, Column(name: "Yayınlanma Tarihi", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(name: "Güncelleme Tarihi", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; } 

        [Column(name: "Silinme Tarihi", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; } 
    }
}
