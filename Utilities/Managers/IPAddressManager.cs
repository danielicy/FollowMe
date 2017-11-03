using System;
using System.Net;
using System.Net.Sockets;
using Utilities.Helpers;
using System.Threading;

namespace Utilities.Managers
{
    public class IPAddressManager
    {
        #region private embers
        private string _currentIpAddress;
        const string IP_REGISTRY_KEY = "Current_IP";
        #endregion

        public event IPAddressEventHAndler IPAddressChanged;

        public IPAddressManager()
        {
            Init();
        }

        private void Init()
        {
            do
            {
                CheckIPAddress();

                //waits for 10 minutes
                Thread.Sleep(new TimeSpan(0, 10, 0));

            }
            while (true);
        }

        private string GetIP4Address()
        {
            string IP4Address = String.Empty;
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            return IP4Address;
        }
      
        private void CheckIPAddress()
        {
            string currentIpAddress = GetIP4Address();
            if (GETIPAddressFromRegistry() == currentIpAddress)
            {
                RegistryHelper.SetRegistryKey(IP_REGISTRY_KEY, currentIpAddress);
                IPAddressChanged.Invoke(this, new IPAddressEventArgs() { IPAddress = currentIpAddress });
            }
        }


        private string GETIPAddressFromRegistry()
        {
            return RegistryHelper.GetRegistryValue("Current_IP_Address");            
        }

    }

    public class IPAddressEventArgs :  EventArgs
    {
        public string IPAddress { get; set; }
    }

    public delegate void IPAddressEventHAndler(object sender, IPAddressEventArgs args);
}
