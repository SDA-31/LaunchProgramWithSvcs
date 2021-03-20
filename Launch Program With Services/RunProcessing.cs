using System;
using System.Linq;
using System.Collections.Generic;
using System.ServiceProcess;
using System.ComponentModel;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;

namespace Launch_Program_Scs
{
    internal static class RunProcessing
    {
        public static void Exit(int er = 0) // Exit from program
        {
            Environment.Exit(er);
        }

        public static bool IsAdmin() // Checks the program started as administrator
        {
            var pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return pricipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void Runas(string args) // Launch program as administrator
        {
            var processInfo = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = Assembly.GetExecutingAssembly().Location,
                Arguments = args
            };
            try { Process.Start(processInfo); }
            catch (Win32Exception)
            {
                Exit(1);
            }
            Exit();
        }

        public static void Start(string file, string args = "")  // Launch application
        {
            var iStartProcess = new Process();
            iStartProcess.StartInfo.FileName = file;
            iStartProcess.StartInfo.Arguments = args;
            iStartProcess.Start();
            Exit();
        }

        public static void ServiceProcessing(List<ServiceController> scs, string[] args) // Launch services
        {
            if (scs.Count() != 0)
            {
                if (!IsAdmin())
                    Runas(ArgsProcessing.ArgsToStr(args));
                foreach (var i in scs)
                {
                    try
                    {
                        i.Start();
                        i.Refresh();
                        while (i.Status.ToString() == "StartPending")
                            i.Refresh();
                    }
                    catch { continue; }
                }
            }
        }
    }
}
