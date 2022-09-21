using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace MyLib
{
    class JsonHelper
    {
        public static void SaveJson(string fileName, List<(string, string)> lst)
        {
            List<Item> totalLst = new List<Item>();
            foreach (var el in lst)
            {
                var item = new Item
                {
                    Name = el.Item1,
                    Value = el.Item2
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
            File.WriteAllText(fileName, json);
        }
    }
}
