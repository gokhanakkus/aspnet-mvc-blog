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

        [Route("KayıtOl")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("KayıtOl")]
        [HttpPost]
        public async Task<IActionResult> Register(Models.User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Boş geçilemeyecek alanları lütfen doldurun!");
                }
                else
                {
                    var kullanici = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                    if (kullanici != null)
                    {
                        ModelState.AddModelError("", "Bu maili kullanan bir kullanıcı zaten var");
                        return RedirectToAction(nameof(ForgotPassword));
                    }
                    else
                    {
                        var kullanici1 = new Entity.Concrete.User
                        {
                            Email = user.Email,
                            Name = user.Name,
                            Password = user.Password,              
                            RoleId = 3,
                            CreatedAt = DateTime.Now
                        };
                        await _context.Users.AddAsync(kullanici1);
                        await _context.SaveChangesAsync();
                        return Redirect("/Auth/Login");
                    }

                }
            }
            catch (Exception)
            {

            }
            return View();
        }

        [Route("GirisYap")]
        [HttpGet]
        public IActionResult Login([FromQuery] string redirectUrl)
        {
            string url = HttpUtility.UrlDecode(redirectUrl);
            var model = new Auth() { redirectUrl = url };
            return View(model);
        }

        [Route("GirisYap")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Auth user)
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
                    new Claim(ClaimTypes.Email, kullanici.Email),
                };

                        if (kullanici.RoleId == 1 || kullanici.RoleId == 3)
                        {
                            kullaniciyetkileri.Add(new Claim("Role", "Admin"));
                        }
                        else if (kullanici.RoleId == 2)
                        {
                            kullaniciyetkileri.Add(new Claim("Role", "User"));
                        }

                        var kullanicikimligi = new ClaimsIdentity(kullaniciyetkileri, "Login");
                        ClaimsPrincipal claimsPrincipal = new(kullanicikimligi);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        HttpContext.Session.SetInt32("UserId", kullanici.Id);

                        if (kullanici.RoleId == 1 || kullanici.RoleId == 3)
                        {
                            return Redirect(_configuration.GetConnectionString("Admin"));
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

        [Route("SifremiUnuttum")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(Auth forgotPassword)
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
                await EmailSender.SendEmailAsync(kullanici);

                ViewBag.Message = "Emailinize sifre degistirme talebinize iliskin mesaj gonderilmistir.";

                return View();

            }
        }

        [Route("SifreYenileme")]
        public IActionResult UpdatePassword([FromQuery] int newPassword)
        {
            var kullanici = _context.Users.Where(x => x.Id == newPassword).FirstOrDefault();

            if (kullanici != null)
            {
                var model = new Auth()
                {
                    User = new App.Web.Mvc.Models.User
                    {
                        // Kullanıcı bilgilerini dönüştürüyoruz
                        Email = kullanici.Email,
                        Name = kullanici.Name,
                        
                    },
                    Password = null
                };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View(new Auth());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePasswordAsync(Auth model)
        {
            var kullanici = _context.Users.Where(x => x.Email == model.User.Email).FirstOrDefault();

            if (kullanici != null)
            {
                kullanici.Password = model.Password;
                kullanici.UpdatedAt = DateTime.Now;
                _context.Update(kullanici);
                await _context.SaveChangesAsync();
                return Redirect("/Auth/Login");
            }
            else
            {
                // Kullanıcı bulunamadığında yapılması gereken durumu ele alabilirsiniz, örneğin bir hata mesajı gösterme.
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View(model);
            }
        }
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Remove("UserId");
            }
            catch (Exception)
            {
                HttpContext.Session.Clear();

            }
            return Redirect("/Home/Index");
        }
    }
}
