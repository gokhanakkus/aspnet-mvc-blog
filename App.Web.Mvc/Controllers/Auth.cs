using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class Auth : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        
        public IActionResult Login(string redirectUrl)
        {
            return View();
        }
        
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
