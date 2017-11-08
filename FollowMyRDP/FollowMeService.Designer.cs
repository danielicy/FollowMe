

using Utilities.Managers;

namespace FollowMyRDP
{
    partial class FollowMeService
    {

        private System.Diagnostics.EventLog eventLog1;
        private IPAddressManager _IPAddressManager;
        private MailManager _mailManager;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            // 
            // FollowMeService
            // 
            this.ServiceName = "FollowMeService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();

        }

        private void _IPAddressManager_IPAddressChanged(object sender, IPAddressEventArgs args)
        {
            _mailManager.SendMail(args.IPAddress);
        }

        #endregion

        
    }

}
