using System;

namespace task6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Helper.GcdAsync(27, 36).Result);
        }
    }
}
