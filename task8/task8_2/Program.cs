using System;
using System.Collections.Generic;

namespace task8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Data", "hello data!");
            dictionary.Add("info", "hello info!");
            dictionary.Add("lalala", "hello lalala!");
            dictionary.Add("NAME", "hello name!");
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            SimpleBinder simpleBinder = SimpleBinder.GetInstance();
            Console.WriteLine("Search results: ");
            foreach (var item in simpleBinder.Bind(new Foo(), dictionary))
            {
                Console.WriteLine(item);
            }
        }
    }
}
