using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class Auth : Controller
    {
		[Route("KayıtOl")]
		public IActionResult Register()
        {
            return View();
        }

		[Route("GirisYap")]
		public IActionResult Login(string redirectUrl)
        {
            return View();
        }

		[Route("SifremiUnuttum")]
		public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
