using System;

namespace task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());
            if (a > b)
            {
                int temp;
                temp = a;
                a = b;
                b = temp;
            }
            Console.Write("Result: ");
            int amount = 0;
            for (int i = a; i <= b; i++)
            {
                int counter = 0;
                char[] arr = convertTo3(i).ToCharArray();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == '2')
                        counter++;
                }
                if (counter == 2)
                {
                    Console.Write(i + " ");
                    amount++;
                }
            }
            if (amount == 0)
                Console.Write("There are no such numbers");
        }

        public static string convertTo3(int a)
        {
            string s = "";
            while (a > 0 || a < 0)
            {
                int t = a % 3;
                a /= 3;
                s += t.ToString();
            }
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return (new string(arr));
        }
    }
}