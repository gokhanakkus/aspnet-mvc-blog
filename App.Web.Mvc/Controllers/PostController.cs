using App.Web.Data.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [Route("Icerik")]
		public IActionResult Index()
        {
            return View();
        }
    }
}
