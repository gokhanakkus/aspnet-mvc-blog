﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Data.Models
{
    public class PostEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity Users { get; set; }
    }
}