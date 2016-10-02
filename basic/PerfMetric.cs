using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace basic
{
    class PerfMetric
    {
        public static void DisaplyCPUUsage()
        {
            // CPUINFO
            const string categoryName = "Processor Information";
            const string counterName = "% Processor Time";
            const string instanceName = "_Total";

            var pc = new PerformanceCounter(categoryName, counterName, instanceName);

            while (true)
            {
                Console.WriteLine("Total CPU usage of {1}: {0}", pc.NextValue(), Environment.MachineName);
                Thread.Sleep(200);
            }
        }
       

}
}
