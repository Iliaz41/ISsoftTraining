using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace task7_1
{
    public class Helper
    {
        private Employee employees = new Employee();

        public void ReadFile()
        {
            int amount = 0;
            foreach (string item in File.ReadLines("data.csv"))
            {
                amount++;
                ParseString(item, amount);
            }
        }

        private void ParseString(string item, int amount)
        {
            if (item.Length == 0 || item == null) 
            {
                Console.WriteLine($"Empty string № {amount}");
            }
            char[] delchar = { ',', ',' };
            string[] ch = item.Split(delchar);
            string name = ch[0];
            DateTime from = new DateTime();
            DateTime to = new DateTime();
            from = DateTime.Parse(ch[1], System.Globalization.CultureInfo.InvariantCulture);
            to = DateTime.Parse(ch[2], System.Globalization.CultureInfo.InvariantCulture);
            employees.Add(name, from, to);
        }

        public void ShowAverageDuration()
        {
            Console.WriteLine($"Average duration for all employees: {employees.AverageDuration()}");
        }

        public void ShowAverageEmployeeDuration()
        {
            foreach (var element in employees.AverageEmployeeDuration())
            {
                Console.WriteLine($"Average duration for {element.Item1} : {element.Item2}");
            }
        }

        public void SaveJson()
        {
            List<Item> totalLst = new List<Item>();
            foreach(var element in employees.AverageEmployeeDuration())
            {
                var item = new Item
                {
                    Name = element.Item1,
                    Duration = Math.Round(element.Item2.Days + element.Item2.Hours / 24.0, 1)
                };
                totalLst.Add(item);
            }
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };
            var json = JsonSerializer.Serialize(totalLst, options);
            File.WriteAllText("persons.json", json);
        }
    }
}
