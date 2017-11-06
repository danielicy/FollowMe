

using Utilities.Managers;

namespace FollowMe.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper wraper = new Wrapper();
        }
    }

    public class Wrapper
    {
        private IPAddressManager _IPAddressManager;
        

        public Wrapper()
        {            
            _IPAddressManager = new IPAddressManager();           
           
            _IPAddressManager.Init();
        }
        
    }
}
