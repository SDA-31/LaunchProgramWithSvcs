using System.Collections.Generic;

namespace Launch_Program_Scs
{
    internal static class ListExtention
    {
        public static string PopFirst(this List<string> s) // Returns first element with deleting
        {
            var tmp = s[0];
            s.RemoveAt(0);
            return tmp;
        }

        public static List<string> Range(this List<string> s, int index1 = 0, int index2 = 0) // Returns list in specified range
        {
            var tmp = new List<string>();
            for (int i = index1; i < index2 + 1; i++)
                tmp.Add(s[i]);
            return tmp;
        }
    }
}
