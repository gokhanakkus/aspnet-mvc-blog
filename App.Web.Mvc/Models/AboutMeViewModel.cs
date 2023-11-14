using App.Web.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class AboutMeViewModel
    {
        [Required, MaxLength(200), Column(name: "Başlık", TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required, Column(name: "İçerik", TypeName = "text")]
        public string Content { get; set; }
        public string WhoIsMe { get; set; }
        public string MyVision { get; set; }
        public List<PageImage> PageImages { get; set; }
    }
}
