using System;
using System.Linq;
using System.Collections.Generic;

namespace Launch_Program_Scs
{
    internal static class ArgsProcessing
    {
        public static bool IsServices { get; set; }
        public static string[] ScsFrom(string[] a) => a[1].Split(' '); // Возвращает список сервисов
        public static string FileFrom(string[] a) => a[0]; // Возвращает имя программы
        public static string ArgsFrom(string[] a) // Возвращает аргументы
        {
            string ar = "";
            if (a.Length > 2)
            {
                int tmp = IsServices ? 2 : 1;
                List<string> s;
                s = a.ToList().Range(tmp, a.Length - 1);
                s[0] = s[0].Insert(0, "\""); // Вставка " в начало
                s[s.Count - 1] = s[s.Count - 1].Insert(s.Last().Length, "\""); // Вставка " в конец последнего параметра
                ar = string.Join("\" \"", s);
            }
            return ar;
        }
        public static string ArgsToStr(string[] a) // Возвращает все параметры в виде string
        {
            var ar = string.Join("\" \"", a);
            ar = ar.Insert(0, "\"");
            ar = ar.Insert(ar.Length - 1, "\"");
            return ar;
        }
    }
}
