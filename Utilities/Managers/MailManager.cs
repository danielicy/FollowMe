using System.ComponentModel;
using System.Net;
using System.Net.Mail;


namespace Utilities.Managers
{
    public class MailManager
    {
        public void SendMail()
        {
            var fromAddress = new MailAddress("****@gmail.com", "From Me");
            var toAddress = new MailAddress("***@hotmail.com", "To You");
            const string fromPassword = "********";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

            };

            smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.SendAsync(message, "");
            }
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
