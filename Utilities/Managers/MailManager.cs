using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Utilities.Helpers;

namespace Utilities.Managers
{ 
    public class MailManager
    {
        private EventLog eventLog1;

        private string _from;
        private string _destination;
        private string _passWord;
        private string _host;
        public MailManager(EventLog log):this()
        {
            eventLog1 = log;
           
        }

        public MailManager( )
        {            
            _from = RegistryHelper.GetRegistryValue("FROMADDRESS");
            _destination = RegistryHelper.GetRegistryValue("DESTINATIONADDRESS");
            _passWord = RegistryHelper.GetRegistryValue("PASSWORD");
            _host = "smtp.gmail.com";
        }

        public MailManager( MailObject mailObject)
        {
            _from = mailObject.Sender;
            _destination = mailObject.Reciever;
            _passWord = mailObject.Password;
            _host = mailObject.Host;
        }

       

        public void SendMail(string ipAddress)
        {
            //eventLog1.WriteEntry("Sending Mail....");
            MailAddress fromAddress = new MailAddress(_from, "From Danieli");
            MailAddress toAddress = new MailAddress(_destination, "To You");
            string fromPassword = _passWord;//******
            string subject = "IP Address Changed";
            string body = ipAddress;


            var smtp = new SmtpClient
            {
                Host = _host,
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

           // eventLog1.WriteEntry("Sent Mail");
        }
        
 

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }
    }

    public class MailObject
    {
        public string Sender { get; set; }     
        public string Password { get; set; }
        public string Reciever { get; set; }
        public string Host { get; set; }
    }
}
