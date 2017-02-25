namespace WindowsEventService
{
    partial class ProjectInstaller
    {
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
            System.ServiceProcess.ServiceProcessInstaller WindowsEventServiceProcessInstaller1;
            this.WindowsEventService = new System.ServiceProcess.ServiceInstaller();
            WindowsEventServiceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // WindowsEventServiceProcessInstaller1
            // 
            WindowsEventServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
            WindowsEventServiceProcessInstaller1.Password = null;
            WindowsEventServiceProcessInstaller1.Username = null;
            // 
            // WindowsEventService
            // 
            this.WindowsEventService.ServiceName = "WindowsEventService1";
            this.WindowsEventService.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.WindowsEventService_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            WindowsEventServiceProcessInstaller1,
            this.WindowsEventService});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller WindowsEventService;
    }
}