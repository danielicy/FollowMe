using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.Managers;

namespace FollowMe.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SendMail()
        {

            MailObject mailObject = new MailObject();

            

            /*mailObject.Sender = "A********Z@s******.com";
           mailObject.Reciever = "X*******@T********p.com";
           mailObject.Password = "*********";
           mailObject.Host = "smtp.live.com";*/




            MailManager _mailManager = new MailManager(mailObject);
            _mailManager.SendMail("Hi There");

        }
    }
}
