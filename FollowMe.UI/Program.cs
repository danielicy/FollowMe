﻿

using System.Configuration;
using Utilities.Helpers;
using Utilities.Managers;

namespace FollowMe.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper wraper = new Wrapper(args);
        }
    }

    public class Wrapper
    {
        private IPAddressManager _IPAddressManager;
        private MailManager _mailManager;
        private System.Diagnostics.EventLog eventLog1;
        public Wrapper(string[] args)
        {


            if (RegistryHelper.GetRegistryValue("FROMADDRESS") == null)
                RegistryHelper.SetRegistryKey("FROMADDRESS", ConfigurationManager.AppSettings["SenderMail"]);

            if (RegistryHelper.GetRegistryValue("DESTINATIONADDRESS") == null)
                RegistryHelper.SetRegistryKey("DESTINATIONADDRESS", ConfigurationManager.AppSettings["RecieverMail"]);

            if (RegistryHelper.GetRegistryValue("PASSWORD") == null)
                RegistryHelper.SetRegistryKey("PASSWORD", ConfigurationManager.AppSettings["Password"]);

            eventLog1 = new System.Diagnostics.EventLog();
            _mailManager = new MailManager(eventLog1);
            _IPAddressManager = new IPAddressManager(eventLog1);           
           
            
            _IPAddressManager.IPAddressChanged += _IPAddressManager_IPAddressChanged;
            _IPAddressManager.Init();
        }

        private void _IPAddressManager_IPAddressChanged(object sender, IPAddressEventArgs args)
        {
            _mailManager.SendMail(args.IPAddress);
        }
    }
}
