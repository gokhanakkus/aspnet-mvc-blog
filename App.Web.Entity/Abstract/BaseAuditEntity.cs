﻿using System;
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
        [Required, Column(name: "Published Date", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(name: "Update Date", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; } 

        [Column(name: "Deletion Date", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; } 
    }
}
