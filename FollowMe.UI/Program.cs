

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

        public Wrapper(string[] args)
        {
            _mailManager = new MailManager();
            _IPAddressManager = new IPAddressManager();           
           
            
            _IPAddressManager.IPAddressChanged += _IPAddressManager_IPAddressChanged;
            _IPAddressManager.Init();
        }

        private void _IPAddressManager_IPAddressChanged(object sender, IPAddressEventArgs args)
        {
            _mailManager.SendMail(args.IPAddress);
        }
    }
}
