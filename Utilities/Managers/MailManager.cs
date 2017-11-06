using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using Utilities.Helpers;

namespace Utilities.Managers
{ 
    public class MailManager
    {
        public void SendMail(string ipAddress)
        {
            var fromAddress = new MailAddress("****@gmail.com", "From Danieli");
            var toAddress = new MailAddress("***@hotmail.com", "To You");
            const string fromPassword = "*****";
            const string subject = "Subject";
            const string body = "Body";

            

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
        

        //        private string _from;
        //        private string _destination;
        //        private string _passWord;

        //        public MailManager()
        //        {
        //#if RELEASE
        //            _from = RegistryHelper.GetRegistryValue("FROMADDRESS_KEY");
        //            _destination = RegistryHelper.GetRegistryValue("DESTINATIONADDRESS_KEY");
        //            _passWord = RegistryHelper.GetRegistryValue("PASSWORD_KEY");
        //#endif

        //#if DEBUG
        //            _from = FROMADDRESS_KEY;
        //            _destination = DESTINATIONADDRESS_KEY;
        //            _passWord = PASSWORD_KEY;
        //#endif
        //        }

        //        public void SendMail(string IpAddress)
        //        {
        //            var fromAddress = new MailAddress(_from, "From Me");
        //            var toAddress = new MailAddress(_destination, "To You");
        //            string fromPassword = _passWord;

        //            const string subject = "IP changed";
        //            string body = IpAddress;

        //            var smtp = new SmtpClient
        //            {
        //                Host = "smtp.gmail.com",
        //                Port = 587,
        //                EnableSsl = true,
        //                DeliveryMethod = SmtpDeliveryMethod.Network,
        //                UseDefaultCredentials = false,
        //                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

        //            };

        //            smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        //            using (var message = new MailMessage(fromAddress, toAddress)
        //            {
        //                Subject = subject,
        //                Body = body
        //            })
        //            {
        //                smtp.SendAsync(message, "");
        //            }
        //        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
