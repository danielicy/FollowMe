using Utilities.Managers;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System;
using Utilities.Helpers;
using System.Configuration;

namespace FollowMyRDP
{

    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public long dwServiceType;
        public ServiceState dwCurrentState;
        public long dwControlsAccepted;
        public long dwWin32ExitCode;
        public long dwServiceSpecificExitCode;
        public long dwCheckPoint;
        public long dwWaitHint;
    };

    public partial class FollowMeService : ServiceBase
    {
        private IPAddressManager _IPAddressManager;
        private MailManager _mailManager;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        public FollowMeService(string[] args)
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }

           
          
            if(RegistryHelper.GetRegistryValue("FROMADDRESS") ==null)
            RegistryHelper.SetRegistryKey("FROMADDRESS", ConfigurationManager.AppSettings["SenderMail"]);

            if (RegistryHelper.GetRegistryValue("DESTINATIONADDRESS") == null)
                RegistryHelper.SetRegistryKey("DESTINATIONADDRESS", ConfigurationManager.AppSettings["RecieverMail"]);

            if (RegistryHelper.GetRegistryValue("PASSWORD") == null)
                RegistryHelper.SetRegistryKey("PASSWORD", ConfigurationManager.AppSettings["Password"]);
                    

            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

           
        }

        private void _IPAddressManager_IPAddressChanged(object sender, IPAddressEventArgs args)
        {
            _mailManager.SendMail(args.IPAddress);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
               // eventLog1.WriteEntry("In OnStart");

                // Update the service state to Start Pending.  
                ServiceStatus serviceStatus = new ServiceStatus();
                serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
                serviceStatus.dwWaitHint = 100000;
                SetServiceStatus(this.ServiceHandle, ref serviceStatus);

                // Update the service state to Running.  
                serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
                SetServiceStatus(this.ServiceHandle, ref serviceStatus);
                _mailManager = new MailManager(eventLog1);
                _IPAddressManager = new IPAddressManager(eventLog1);
                _IPAddressManager.IPAddressChanged += _IPAddressManager_IPAddressChanged;
                _IPAddressManager.Init();

                eventLog1.WriteEntry("OnStart Susccesfully");
                eventLog1.Log = "FollowMeService started Susccesfully";

            }
            catch(Exception ex)
            {
                eventLog1.WriteEntry("failed onStart: " + ex.Message);
            }
          
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }
    }
}
