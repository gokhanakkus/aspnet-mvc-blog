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
    public class Settings : BaseAuditEntity
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }

        [Required, MaxLength(200), Column(name: "Name", TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required, MaxLength(400), Column(name: "Value", TypeName = "nvarchar")]
        public string Value { get; set; }
    }
   
}
