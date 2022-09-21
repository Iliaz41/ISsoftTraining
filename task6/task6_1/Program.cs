using System;
using System.Threading;

namespace task6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cache cache = new Cache(7);
            cache.Set("a", 17465);
            cache.Set("a", 77);
            cache.Set("v", "sssss");
            cache.Set("q", 53256);
            cache.Set("w", "xcvvbcxbx");
            cache.Set("g", true);
            cache.Set("t", true);
            cache.Set("h", true);
            cache.Set("k", true);
            cache.Monitor();
            cache.Get("v");
            cache.Get("q");
            cache.Get("t");
            cache.Remove("w");
            foreach (var item in cache)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
