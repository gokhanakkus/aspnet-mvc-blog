using MimeKit;
using MailKit.Net.Smtp;
using App.Web.Entity.Concrete;

namespace App.Web.Mvc.Utils
{
    public class EmailSender
    {
        public static async Task SendEmailAsync(User user)
        {
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
                await smtpClient.AuthenticateAsync("gokhan@gmail.com", "1234");

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Siliconmade Blog Sitesi", "gokhan@gmail.com"));
                message.To.Add(new MailboxAddress(user.Name, user.Email));
                message.Subject = "Şifre Sıfırlama Talebi";

                var builder = new BodyBuilder();
                builder.HtmlBody = $"Kullanıcı Bilgileri : <hr /> " +
                    $"Ad : {user.Name} <hr /> " +
                $"Email : {user.Email} <hr /> " +
                $"Bilgilerine sahip kullanıcı şifre sıfırlama talebiniz alınmıştır.  <hr />" +
                $"Devam etmek için <a href='  https://localhost:7239/Auth/UpdatePassword?newPassword= {user.Id}' >Buraya</a> tıklayınız."; //https rout düzelt

                message.Body = builder.ToMessageBody();

                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
