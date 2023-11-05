using App.Web.Data;
using App.Web.Entity.Concrete;
using App.Web.Data.Concrete;
using App.Web.Mvc.Models;
using App.Web.Mvc.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using NuGet.ContentModel;
using System.Reflection.Metadata;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Boş geçilemeyecek alanları lütfen doldurun!");
                //}
                //else
                //{
                    var kullanici = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                    if (kullanici != null)
                    {
                        ModelState.AddModelError("", "Bu maili kullanan bir kullanıcı zaten var");
                        return RedirectToAction(nameof(ForgotPassword));
                    }
                    else
                    {
                        var kullanici1 = new User
                        {
                            Email = user.Email,
                            Name = user.Name,
                            Password = user.Password,
                            City = user.City,
                            RoleId = 3,
                            CreatedAt = DateTime.Now
                        };
                        await _context.Users.AddAsync(kullanici1);
                        await _context.SaveChangesAsync();
                        return Redirect("/Auth/Login");
                    }

                //}
            }
            catch (Exception)
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult Login([FromQuery] string redirectUrl)
        {
            string url = HttpUtility.UrlDecode(redirectUrl);
            var model = new LoginViewModel() { redirectUrl = url };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            try
            {
                string url = HttpUtility.UrlDecode(user.redirectUrl);
                user.redirectUrl = url;
                if (user == null)
                {
                    ModelState.AddModelError("", "Boş geçilemez!");
                }
                if (ModelState.IsValid)
                {
                    var kullanici = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                    if (kullanici == null)
                    {
                        ModelState.AddModelError("", "Hatalı giriş yaptınız.");
                    }
                    else
                    {
                        var kullaniciyetkileri = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,kullanici.Email),

                        };
                        if (kullanici.RoleId == 1)
                            kullaniciyetkileri.Add(new Claim("Role", "Admin"));
                        else if (kullanici.RoleId == 2)
                            kullaniciyetkileri.Add(new Claim("Role", "Moderator"));
                        else if (kullanici.RoleId == 3)
                            kullaniciyetkileri.Add(new Claim("Role", "User"));
                        var kullanicikimligi = new ClaimsIdentity(kullaniciyetkileri, "Login");
                        ClaimsPrincipal claimsPrincipal = new(kullanicikimligi);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        HttpContext.Session.SetInt32("UserId", kullanici.Id);
                        if (kullanici.RoleId == 1 || kullanici.RoleId == 2 )
                        {
                            return Redirect("../Admin/Main/Index");
                        }

                        return Redirect(string.IsNullOrEmpty(user.redirectUrl) ? "/Home/Index" : user.redirectUrl);
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");

            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Geçersiz email...");
                return View(forgotPassword);
            }
            var kullanici = _context.Users.Where(x => x.Email == forgotPassword.Email).FirstOrDefault();
            if (kullanici == null)
            {
                ModelState.AddModelError("", "Bu mailde bir kullanıcı yok!");
                return View(forgotPassword);
            }
            else
            {
                await EmailSend.SendMailAsync(kullanici);

                ViewBag.Message = "Emailinize sifre degistirme talebinize iliskin mesaj gonderilmistir.";

                return View();

            }
        }

        [HttpGet]
        public IActionResult UpdatePassword([FromQuery] int newPassword)
        {
            var kullanici = _context.Users.Where(x => x.Id == newPassword).FirstOrDefault();
            var model = new UpdatePasswordViewModel()
            {
                User = kullanici,
                Password = null
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model)
        {
            var kullanici = _context.Users.Where(x => x.Email == model.User.Email).FirstOrDefault();
            kullanici.Password = model.Password;
            kullanici.UpdatedAt = DateTime.Now;
            _context.Update(kullanici);
            await _context.SaveChangesAsync();
            return Redirect("/Auth/Login");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                HttpContext.Session.Remove("UserId");
				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}
            catch (Exception)
            {
                HttpContext.Session.Clear();

            } 
            return RedirectToAction("Index", "Home");
        }
    }
}
