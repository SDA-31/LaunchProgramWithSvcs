using System;
using System.Linq;
using System.Collections.Generic;

namespace Launch_Program_Scs
{
    internal static class ArgsProcessing
    {
        public static bool IsServices { get; set; }
        public static string[] ScsFrom(string[] a) => a[1].Split(' '); // Returns list of services
        public static string FileFrom(string[] a) => a[0]; // Returns the program name
        public static string ArgsFrom(string[] a) // Returns arguments
        {
            string ar = "";
            if (a.Length > 2)
            {
                int tmp = IsServices ? 2 : 1;
                List<string> s;
                s = a.ToList().Range(tmp, a.Length - 1);
                s[0] = s[0].Insert(0, "\""); // Inserts " in begin
                s[s.Count - 1] = s[s.Count - 1].Insert(s.Last().Length, "\""); // Inserts " in end of last value
                ar = string.Join("\" \"", s);
            }
            return ar;
        }
        public static string ArgsToStr(string[] a) // Returns all parameters as string
        {
            var ar = string.Join("\" \"", a);
            ar = ar.Insert(0, "\"");
            ar = ar.Insert(ar.Length - 1, "\"");
            return ar;
        }
    }
}
