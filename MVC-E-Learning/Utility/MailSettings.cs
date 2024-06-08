using System.Net.Mail;
using System.Net;
using DAL.Models;

namespace MVC_E_Learning.Utility
{
    public class MailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("alaa.mahmoud226ass@gmail.com", "tzti wzqg ydvw kmch");

            client.Send("alaa.mahmoud226ass@gmail.com", email.Recipient, email.Subject, email.Body);
        }
    }
}
