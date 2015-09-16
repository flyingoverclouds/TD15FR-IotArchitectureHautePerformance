using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Orleans.Host;
using Orleans.Runtime.Configuration;
using System.IO;

namespace CityPowerSilo
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        OrleansAzureSilo silo;


        public override bool OnStart()
        {
            
            ServicePointManager.DefaultConnectionLimit = 12;

            //base.OnStart();
            try
            {
                silo = new OrleansAzureSilo();

                Trace.TraceInformation("CityPowerSilo start .....");

                //string appRoot = Environment.GetEnvironmentVariable("RoleRoot");
                //appRoot = Path.Combine(appRoot + @"\", @"approot\");
                //Trace.TraceInformation("APPROOT = " + appRoot);
                //string configFileName = Path.Combine(appRoot, "OrleansConfiguration.xml");
                //Trace.TraceInformation("Config file name = " + configFileName);
                //var r = System.IO.File.OpenText(configFileName);
                //OrleansConfiguration cfg = new OrleansConfiguration(r);


                return silo.Start(RoleEnvironment.DeploymentId, RoleEnvironment.CurrentRoleInstance);
            }
            catch(Exception ex)
            {
                Trace.TraceError("Startsilo FAILED : " + ex.ToString());
                return false;
            }
           
        }

        public override void Run()
        {
            silo.Run();
        }


        public override void OnStop()
        {
            Trace.TraceInformation("CityPowerSilo is stopping");

            silo.Stop();

            base.OnStop();

            Trace.TraceInformation("CityPowerSilo has stopped");
        }


        
    }
}
