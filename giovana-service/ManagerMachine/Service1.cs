using ManagerMachine.Infra;
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

namespace ManagerMachine
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;

        public Service1()
        {
             Helper.Manager();
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer = new Timer(timer1_TickAsync, null, 0, 300000);
        }

        private async void timer1_TickAsync(object state)
        {
          //  await Helper.Manager();
        }

        protected override void OnStop()
        {
        }
    }
}
