using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsEventService.Core;

namespace WindowsEventService
{
    public partial class WindowsEventService1 : ServiceBase
    {
        Thread EventListener;

        public WindowsEventService1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CoreEvents coreEvent = new CoreEvents();

            EventListener = new Thread(new ThreadStart(coreEvent.Execute));

            EventListener.Start();
        }

        protected override void OnStop()
        {
            EventListener.Interrupt();

            EventListener.Join();
        }
    }
}
