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
            message.From.Add(new MailboxAddress("Blog Website", "projectmailservicegokhan@gmail.com"));
            message.To.Add(new MailboxAddress(user.Name, user.Email));
            message.Subject = "Password Reset Request";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"User Information : <hr /> " +
                $"Name : {user.Name} <hr /> " +
                $"Email : {user.Email} <hr /> " +
                $"A password reset request has been received for the user with the above information. <hr />" +
                $"To proceed, click <a href='https://localhost:7239/Auth/UpdatePassword?newPassword={user.Id}' >Here</a> tıklayınız."
            };

            smtpClient.Send(message);
            smtpClient.Disconnect(true);
        }
    }
}
