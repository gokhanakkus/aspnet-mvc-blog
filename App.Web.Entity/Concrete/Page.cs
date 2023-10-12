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
    public class Page : BaseAuiditEntity
    {

        [Required, MaxLength(200), Column(name: "Başlık", TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required, Column(name: "İçerik", TypeName = "text")]
        public string Content { get; set; }

        [Column(name: "Aktif?", TypeName = "bit")]
        public bool IsActive { get; set; }
    }
    //public class Page
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }
    //    public bool IsActive { get; set; }
    //}
}
