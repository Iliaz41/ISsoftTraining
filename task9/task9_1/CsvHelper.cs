using System;
using System.Collections.Generic;
using System.IO;

namespace task9_1
{
    public class CsvHelper
    {
        public static Dictionary<Employee, List<Vacation>> ReadFile(string fileName)
        {
            Dictionary<Employee, List<Vacation>> dictionary = new Dictionary<Employee, List<Vacation>>();
            foreach (string item in File.ReadLines(fileName))
            {
                (Employee, Vacation) pair = ParseString(item);
                if (pair != default)
                {
                    if (dictionary.ContainsKey(pair.Item1))
                    {
                        dictionary[pair.Item1].Add(pair.Item2);
                    }
                    else
                    {
                        List<Vacation> lst = new List<Vacation>();
                        lst.Add(pair.Item2);
                        dictionary.Add(pair.Item1, lst);
                    }
                }
            }
            return dictionary;
        }

        private static (Employee, Vacation) ParseString(string item)
        {
            char[] delchar = { ',', ',' };
            string[] ch = item.Split(delchar);
            string name = ch[0];
            DateTime from = new DateTime();
            DateTime to = new DateTime();
            from = DateTime.Parse(ch[1], System.Globalization.CultureInfo.InvariantCulture);
            to = DateTime.Parse(ch[2], System.Globalization.CultureInfo.InvariantCulture);
            var duration = (to - from).Duration();
            if (duration != TimeSpan.Zero)
            {
                return (new Employee(name), new Vacation(from, to));
            }
            return default;
        }
    }
}
