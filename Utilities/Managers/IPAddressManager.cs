using System;
using System.Net;
using System.Net.Sockets;

namespace Utilities.Managers
{
    public class IPAddressManager
    {
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

        private bool WriteIPToRegistry(string IPAddres)
        {
            return false;
        }

       

    }
}
