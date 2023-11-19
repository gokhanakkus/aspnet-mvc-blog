using App.Web.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace App.Web.Entity.Concrete
{
    public class Page : BaseAuditEntity
    {

        [Required, MaxLength(200), Column(name: "Title", TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required, Column(name: "Content", TypeName = "text")]
        public string Content { get; set; }

        public string WhoIsMe { get; set; }
        public string MyVision { get; set; }
        public List<PageImage> PageImages { get; set; }
    }
   
}
