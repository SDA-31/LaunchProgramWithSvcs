using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Launch_Program_Scs
{
    class Program
    {
        static void Main(string[] args) // Entry point
        {
            List<ServiceController> sc = null;
            try
            {
                if (args.Length == 0)
                    throw new Exception();
                sc = (from i in ArgsProcessing.ScsFrom(args) select new ServiceController(i)).ToList();
                sc = sc.Where(n => n.Status.ToString().Equals("Stopped")).ToList();
                if (sc.Count != 0)
                    ArgsProcessing.IsServices = true;
                else
                    throw new Exception();
            }
            catch { sc = null; }
            if (ArgsProcessing.IsServices)
                RunProcessing.ServiceProcessing(sc, args);
            if (args.Length > 0)
                RunProcessing.Start(ArgsProcessing.FileFrom(args), ArgsProcessing.ArgsFrom(args));
        }
    }
}
