

using Utilities.Managers;

namespace FollowMyRDP
{
    partial class FollowMeService
    {

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
            components = new System.ComponentModel.Container();
            this.ServiceName = "FollowMeService";

            _mailManager = new MailManager();
            _IPAddressManager = new IPAddressManager();
            _IPAddressManager.IPAddressChanged += _IPAddressManager_IPAddressChanged;
        }

        private void _IPAddressManager_IPAddressChanged(object sender, IPAddressEventArgs args)
        {
            _mailManager.SendMail(args.IPAddress);
        }

        #endregion
    }

}
