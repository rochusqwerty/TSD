using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class ExtensionMethod
    {
        public static double MemorySum(this List<Process> listOfProc)
        {
            double memsize = 0;
            foreach (var proc in listOfProc)
            {
                /*
                PerformanceCounter PC = new PerformanceCounter();
                PC.CategoryName = "Process";
                PC.CounterName = "Working Set - Private";
                PC.InstanceName = proc.ProcessName;
                memsize += Convert.ToInt32(PC.NextValue()) / (int)(1024);
                PC.Close();
                PC.Dispose();
                */
                memsize += proc.PrivateMemorySize64 / 1e+6;
            }
             
            return memsize;
        }
    }
}
