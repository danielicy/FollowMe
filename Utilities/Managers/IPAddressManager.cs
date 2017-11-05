using System;
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
            /* foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
             {
                 if (IPA.AddressFamily == AddressFamily.InterNetwork)
                 {
                     IP4Address = IPA.ToString();
                     break;
                 }
             }*/

            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
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
