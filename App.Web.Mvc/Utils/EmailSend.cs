using App.Web.Entity.Concrete;
using MimeKit;
using MailKit.Net.Smtp;

namespace App.Web.Mvc.Utils
{
    public class EmailSend
    {
        public static async Task SendMailAsync(User user)
        {
            SmtpClient smtpClient = new();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("projectmailservicegokhan@gmail.com", "bxfofccwnjyiyrug");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Blog Sitesi", "projectmailservicegokhan@gmail.com"));
            message.To.Add(new MailboxAddress(user.Name, user.Email));
            message.Subject = "Şifre Sıfırlama Talebi";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Kullanıcı Bilgileri : <hr /> " +
                $"Ad : {user.Name} <hr /> " +
                $"Email : {user.Email} <hr /> " +
                $"Bilgilerine sahip kullanıcı şifre sıfırlama talebiniz alınmıştır.  <hr />" +
                $"Devam etmek için <a href='https://localhost:7239/Auth/UpdatePassword?newPassword={user.Id}' >Buraya</a> tıklayınız."
            };

            smtpClient.Send(message);
            smtpClient.Disconnect(true);
        }
    }
}
