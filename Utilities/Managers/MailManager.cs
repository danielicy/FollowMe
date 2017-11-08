using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Utilities.Helpers;

namespace Utilities.Managers
{ 
    public class MailManager
    {
        private string _from;
        private string _destination;
        private string _passWord;

        public MailManager()
        {
            _from = RegistryHelper.GetRegistryValue("FROMADDRESS");
            _destination = RegistryHelper.GetRegistryValue("DESTINATIONADDRESS");
            _passWord = RegistryHelper.GetRegistryValue("PASSWORD");
        }

        public void SendMail(string ipAddress)
        {
            MailAddress fromAddress = new MailAddress(_from, "From Danieli");
            MailAddress toAddress = new MailAddress(_destination, "To You");
            string fromPassword = _passWord;//******
            string subject = "IP Address Changed";
            string body = ipAddress;


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        
 

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
