using App.Web.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Entity.Concrete
{
    public class PageImage : BaseEntity
    {
        public string FileName { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}
