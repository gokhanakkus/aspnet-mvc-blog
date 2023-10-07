using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Data.Models
{
    public class CategoryPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int PostId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Categories { get; set; }

        [ForeignKey(nameof(PostId))]
        public PostEntity Posts { get; set; }

    }
}
